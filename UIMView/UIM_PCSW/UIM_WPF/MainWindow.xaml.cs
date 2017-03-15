using FieldTalk.Modbus.Master;
using log4net;
using log4net.Config;
using MBEventLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Input;
using UIM_WPF;
using UIM_WPF.Helper;
using UIM_WPF.modals;

namespace UIM_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // this  is for the tree
        private List<ParameterTable> livelstTree = new List<ParameterTable>();
        private List<ParameterTable> paramslstTree = new List<ParameterTable>();
        TreeViewItem treeDVMainNode = new TreeViewItem(); //Data Virtualization tree
        TreeViewItem treeParamsMainNode = new TreeViewItem(); //Params Tree
        TreeViewItem treeLiveMainNode = new TreeViewItem(); //Live Tree

        // ->Signal Chart
        private List<KeyValuePair<string, float>> chartABlist = new List<KeyValuePair<string, float>>();
        private List<KeyValuePair<string, float>> chartBAlist = new List<KeyValuePair<string, float>>();
        // <-Signal Chart

        //
        private BackgroundWorker bgWorkerDignosticSignal = new BackgroundWorker();
        private BackgroundWorker bgWorkerLiveData = new BackgroundWorker();
        ParamManager mparamManager = new ParamManager();

        // Modbus communication variables
        MBEventLib.MBMasterComm mMBComm = new MBMasterComm();
        private MbusMasterFunctions mConnection;
        private UInt16 mModbusSlaveID;
        private bool isStarted = false;
        private static readonly ILog logger = LogManager.GetLogger(typeof(MainWindow));


        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            DOMConfigurator.Configure();
            if(!File.Exists(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), Constants.FILENAME)))
            {
                MessageBox.Show("File Not Present");
                return;

            }
            int ret = mparamManager.ParseMeterXML(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), Constants.FILENAME));
            if (Constants.RET_OK != ret)
            {
                MessageBox.Show("Parsing Failed");
                return;
            }
            BuildNodes();
            //    InitSignalTimer();
            comboboxComPort.SelectedIndex = 4; // 8 = 9;
            comboboxParity.SelectedIndex = 1; // 1 = even
            comboboxStopBit.SelectedIndex = 0;
            comboboxDatabit.SelectedIndex = 0;
            comboboxBaudRate.SelectedIndex = 2; //2 = 19200 6 = 115.2
            comboboxProtocol.SelectedIndex = 0;
            //cmbTcpProtocol.SelectedIndex = 0;
            comboboxRetries.SelectedIndex = 0;
            bgWorkerDignosticSignal.WorkerReportsProgress = true;
            bgWorkerDignosticSignal.WorkerSupportsCancellation = true;
            bgWorkerLiveData.WorkerReportsProgress = true;
            bgWorkerLiveData.WorkerSupportsCancellation = true;

            //For the display of operation progress to UI.     
            bgWorkerDignosticSignal.DoWork += workerDignosticSignal_DoWork;
            bgWorkerDignosticSignal.ProgressChanged += workerDignosticSignal_ProgressChanged;
            bgWorkerDignosticSignal.RunWorkerCompleted += workerDignosticSignal_RunWorkerCompleted;

            bgWorkerLiveData.DoWork += bgWorkerLiveData_DoWork;
            bgWorkerLiveData.ProgressChanged += bgWorkerLiveData_ProgressChanged;
            bgWorkerLiveData.RunWorkerCompleted += bgWorkerLiveData_RunWorkerCompleted;

            Utils.InitModbusGroups(ref mparamManager, txtboxDeviceID.Text);
        }

        private void bgWorkerLiveData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("LiveData Completed");
        }

        private void bgWorkerLiveData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            dataGridlive.ItemsSource = livelstTree;
            dataGridparamas.ItemsSource = paramslstTree;
        }

        private void bgWorkerLiveData_DoWork(object sender, DoWorkEventArgs e)
        {
            if (bgWorkerLiveData.CancellationPending == true)
            {
                e.Cancel = true;
                return;

            }
            else
            {
                while (true)
                {
                    // COde has to go  here
                }
            }

        }

        private void workerDignosticSignal_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 25)
            {
                ((LineSeries)chartAB.Series[0]).ItemsSource = null;
                ((LineSeries)chartAB.Series[0]).ItemsSource = chartABlist;
                labellastUpdated.Content = DateTime.Now.ToString();
            }
            else if (e.ProgressPercentage == 50)
            {
                ((LineSeries)chartBA.Series[0]).ItemsSource = null;
                ((LineSeries)chartBA.Series[0]).ItemsSource = chartBAlist;
                Mouse.OverrideCursor = Cursors.Arrow;
                labellastUpdated.Content = DateTime.Now.ToString();
            }
            else if (e.ProgressPercentage == 99)
            {
                foreach (ParameterTable pt in paramslstTree)
                {
                    switch (pt.ModbusID)
                    {
                        case Constants.SIGNUMPOINTS_MODBUSID:
                            txtboxnumPoints.Text = pt.Value1;
                            break;
                        case Constants.SIGPATHMASK_MODBUSID:
                            txtboxPathMask.Text = pt.Value1;
                            break;
                        case Constants.SIGSTART_MODBUSID:
                            txtboxstartPT.Text = pt.Value1;
                            break;
                        case Constants.SIGTYPES_MODBUSID:
                            txtboxSygType.Text = pt.Value1;
                            break;
                        default:
                            break;
                    }
                }
                dataGridlive.ItemsSource = livelstTree;
                dataGridparamas.ItemsSource = paramslstTree;
                labellastUpdated.Content = DateTime.Now.ToString();
            }
            progrsbarDiangnosticSignal.Value = e.ProgressPercentage;

        }

        private void workerDignosticSignal_DoWork(object sender, DoWorkEventArgs e)
        {
            if (bgWorkerDignosticSignal.CancellationPending == true)
            {
                e.Cancel = true;
                return;

            }
            else
            {
                while (isStarted)
                {
                    // Mouse.OverrideCursor = Cursors.Wait;
                    chartABlist.Clear();
                    chartBAlist.Clear();
                    Utils.QueueSignalMessages(ref chartABlist, mConnection, Constants.SIGNAL_START_REGISTER_AB);
                    bgWorkerDignosticSignal.ReportProgress(25);
                    // Add code for second chart
                    Utils.QueueSignalMessages(ref chartBAlist, mConnection, Constants.SIGNAL_START_REGISTER_BA);
                    bgWorkerDignosticSignal.ReportProgress(50);
                    Utils.UpdateLiveAndParamsData(mparamManager, mConnection, ref livelstTree, ref paramslstTree, ref bgWorkerDignosticSignal);
                    bgWorkerDignosticSignal.ReportProgress(99);
                    Thread.Sleep(Constants.LIVE_TIMER_INTERVAL_SECS);

                }

            }

        }

        private void workerDignosticSignal_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                progrsbarDiangnosticSignal.Value = 100;
                //  ((LineSeries)chartAB.Series[0]).ItemsSource = null;
            }

        }
        /*
        * It buids the tree and fills the data grid
        * 
        * 
        */
        private void BuildNodes()
        {
            if (!File.Exists(Constants.FILENAME))
            {
                MessageBox.Show("XML File Not Present");
                return;
            }

            Utils.PopulateTreeAndGrids(mparamManager, ref treeDVMainNode, ref treeParamsMainNode, ref treeLiveMainNode, ref livelstTree, ref paramslstTree);
            treeViewlive.Items.Add(treeLiveMainNode);
            treeViewparams.Items.Add(treeParamsMainNode);
            treeViewDataVrtlsn.Items.Add(treeDVMainNode);
            dataGridlive.ItemsSource = livelstTree;
            dataGridparamas.ItemsSource = paramslstTree;
        }
        /*
         *TO mast Any test box to accept only numbers 
         */
        private void TextBlock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        /*
         *Reg ex to only Accept text value 
         */
        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }
        /*
         * Open the serail port and display the configuration used
         */
        private void buttonopenserialport_Click(object sender, RoutedEventArgs e)
        {
            //
            //First we must instantiate class if we haven//t done so already
            //
            Mouse.OverrideCursor = Cursors.Wait;

            if (mConnection == null)
            {
                mMBComm.OnComm += mMBComm_OnComm;
                try
                {
                    mConnection = new MbusRtuMasterProtocol();
                }
                catch (OutOfMemoryException ex)
                {
                    MessageBox.Show("Could not instantiate serial protocol class! Error was " + ex.Message);
                    return;
                }
            }
            else //Already instantiated, close protocol, reinstantiate
            {
                if (mConnection.isOpen())
                    mConnection.closeProtocol();
                mConnection = null;
                try
                {
                    mConnection = new MbusRtuMasterProtocol();
                }
                catch (OutOfMemoryException ex)
                {
                    MessageBox.Show("Could not instantiate serial protocol class! Error was " + ex.Message);
                    return;
                }
            }
            //
            //Here we configure the protocol
            //
            Int32 retryCnt, pollDelay, timeOut, baudRate, parity = 0, dataBits = 0, stopBits = 0, res;
            try
            {
                retryCnt = Int32.Parse(comboboxRetries.Text);
            }
            catch (Exception ex)
            {
                retryCnt = 0;
            }
            try
            {
                pollDelay = Int32.Parse(txtboxPollDelay.Text);
            }
            catch (Exception ex)
            {
                pollDelay = 0;
            }
            try
            {
                timeOut = Int32.Parse(txtboxTimeout.Text);
            }

            catch (Exception ex)
            {
                timeOut = 1000;
            }

            try
            {
                baudRate = Int32.Parse(comboboxBaudRate.Text);
            }
            catch (Exception ex)
            {
                baudRate = 19200;
            }
            switch (comboboxParity.SelectedIndex)
            {
                case 0:
                    parity = MbusSerialMasterProtocol.SER_PARITY_NONE;
                    break;
                case 1:
                    parity = MbusSerialMasterProtocol.SER_PARITY_EVEN;
                    break;
                case 2:
                    parity = MbusSerialMasterProtocol.SER_PARITY_ODD;
                    break;
            }
            switch (comboboxDatabit.SelectedIndex)
            {
                case 0:
                    dataBits = MbusSerialMasterProtocol.SER_DATABITS_8;
                    break;
                case 1:
                    dataBits = MbusSerialMasterProtocol.SER_DATABITS_7;
                    break;
            }
            switch (comboboxStopBit.SelectedIndex)
            {
                case 0:
                    stopBits = MbusSerialMasterProtocol.SER_STOPBITS_1;
                    break;
                case 1:
                    stopBits = MbusSerialMasterProtocol.SER_STOPBITS_2;
                    break;
            }
            mConnection.timeout = timeOut;
            mConnection.retryCnt = retryCnt;
            mConnection.pollDelay = pollDelay;
            // Note: The following CType() cast is required as the mConnection object is declared
            // as the superclass of MbusSerialMasterProtocol. That way mConnection can
            // represent different protocol types.
            res = ((MbusSerialMasterProtocol)mConnection).openProtocol(comboboxComPort.Text, baudRate, dataBits, stopBits, parity);
            Mouse.OverrideCursor = Cursors.Arrow;
            if (res == BusProtocolErrors.FTALK_SUCCESS)
            {
                mModbusSlaveID = Convert.ToUInt16(txtboxDeviceID.Text);
                mConnection.configureSwappedFloats();
                //mConnection.configureCountFromOne(mModbusSlaveID);
                MessageBox.Show("Serial port opened successfully with parameters: " + comboboxComPort.Text + ", " + baudRate + " baud, " + dataBits + " data bits, " + stopBits + " stop bits, parity " + parity);
            }
            else
            {
                MessageBox.Show("Could not open protocol, error was: " + BusProtocolErrors.getBusProtocolErrorText(res));
            }

        }
        /*
         *No functions assigned 
         */
        private void buttonRetrive_Click(object sender, RoutedEventArgs e)
        {

        }
        /*    Update the 2 charts and grid
         *    Now grid is handled on a single worker will be moved to seperate ones
         *    Chart 1:
                    500 registers starting at Modbus reg  40001
               Chart 2:
                    500 registers starting at Modbus reg 42049
        */
        private void buttonSignalsStart_Click(object sender, RoutedEventArgs e)
        {
            // Will start the timer when all is complete and timer will call the Queue function.
            if (null == mConnection)
            {
                MessageBox.Show("Connection is not open. Open the serial port first ");

                return;
            }
            // QueueSignalMessages();
            isStarted = true;
            //   Mouse.OverrideCursor = Cursors.Wait;
            /*  if (bgWorkerLiveData.IsBusy == false)
              {

                    bgWorkerLiveData.RunWorkerAsync();
              }*/

            if (bgWorkerDignosticSignal.IsBusy == false)
            {

                bgWorkerDignosticSignal.RunWorkerAsync();
            }
        }
        /*
         * Stop the worker thread. Now onwards when bckGround worker wont execute the data execution part 
         */

        private void buttonSignalsStop_Click(object sender, RoutedEventArgs e)
        {
            isStarted = false;
            Mouse.OverrideCursor = Cursors.Wait;
            bgWorkerDignosticSignal.CancelAsync();
            Mouse.OverrideCursor = Cursors.Arrow;
            MessageBox.Show("Data Acessing Stopped");

        }
        /*
         * Logic not yet desided
         */
        private void buttonSignalsUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
        static void mMBComm_OnComm(object sender, EventArgs e)
        {
            Console.WriteLine("The threshold was reached.");
        }

        /*
         *Chear the 2 charts. 
         */
        private void buttonClearChart_Click(object sender, RoutedEventArgs e)
        {
            ((LineSeries)chartAB.Series[0]).ItemsSource = null;
            ((LineSeries)chartBA.Series[0]).ItemsSource = null;

        }
        /*
         * When the focus is changes the grid is updated with data source. May not be needed in future since when processing is completed
         * Worker thread will update the data grid .
         */
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    dataGridlive.ItemsSource = livelstTree;

                    break;
                case 2:
                    dataGridparamas.ItemsSource = paramslstTree;
                    break;
                default:
                    break;
            }
        }
    }
}
