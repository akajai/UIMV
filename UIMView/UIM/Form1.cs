using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using FieldTalk.Modbus.Master;
using MBEventLib;

namespace UIM
{
    public partial class Form1 : Form
    {
        MBEventLib.MBMasterComm mMBComm = new MBMasterComm();
        int ErrCount = 0;
        private int mMaxErrors = 0;
        private ParamManager mParamManager;
        private MbusMasterFunctions mConnection;
        private MbusMasterFunctionsasyc mConnectionasyn;
        private bool mbObjectChangedByCode = false;
        private TextBox mDirtyTextBox = null;
        private UInt16 mModbusSlaveID;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ToolTip1.SetToolTip(txtPollDelay, "Delay in milliseconds between two consecutive Modbus operations, 0 to disable")
            //ToolTip1.SetToolTip(cmbRetry, "How many times do we retry operation if it fails first time?")
            //ToolTip1.SetToolTip(cmbSerialProtocol, "Serial protocol choice: ASCII or RTU")
            //ToolTip1.SetToolTip(cmbTcpProtocol, "Ethernet protocol choice: MODBUS/TCP or Encapsulated RTU over TCP")
            cmbComPort.SelectedIndex = 3; // 8 = 9;
            cmbParity.SelectedIndex = 1; // 1 = even
            cmbStopBits.SelectedIndex = 0;
            cmbDataBits.SelectedIndex = 0;
            cmbBaudRate.SelectedIndex = 2; //2 = 19200 6 = 115.2
            cmbSerialProtocol.SelectedIndex = 0;
            //cmbTcpProtocol.SelectedIndex = 0;
            cmbRetry.SelectedIndex = 0;
            this.timTestMSG.Interval = 900;
            //cmbCommand.SelectedIndex = 0;
        }

        private void cmdOpenSerial_Click(object sender, EventArgs e)
        {
            //
            //First we must instantiate class if we haven//t done so already
            //
            if (mConnection == null)
            {
                mMBComm.OnComm += mMBComm_OnComm;
                try
                {
                    mConnection = new MbusRtuMasterProtocol();
                }
                catch (OutOfMemoryException ex)
                {
                    lblResult.Text = "Could not instantiate serial protocol class! Error was " + ex.Message;
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
                    lblResult.Text = "Could not instantiate serial protocol class! Error was " + ex.Message;
                    return;
                }
            }
            //
            //Here we configure the protocol
            //
            Int32 retryCnt, pollDelay, timeOut, baudRate, parity = 0, dataBits = 0, stopBits = 0, res;
            try
            {
                retryCnt = Int32.Parse(cmbRetry.Text);
            }
            catch (Exception ex)
            {
                retryCnt = 0;
            }
            try
            {
                pollDelay = Int32.Parse(txtPollDelay.Text);
            }
            catch (Exception ex)
            {
                pollDelay = 0;
            }
            try {
                timeOut = Int32.Parse(txtTimeout.Text); }

            catch (Exception ex)
            {
                timeOut = 1000;
            }

            try
            {
                baudRate = Int32.Parse(cmbBaudRate.Text);
            }
            catch (Exception ex)
            {
                baudRate = 19200;
            }
            switch (cmbParity.SelectedIndex)
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
            switch (cmbDataBits.SelectedIndex)
            {
            case 0:
                dataBits = MbusSerialMasterProtocol.SER_DATABITS_8;
                break;
            case 1:
                dataBits = MbusSerialMasterProtocol.SER_DATABITS_7;
                break;
            }
            switch (cmbStopBits.SelectedIndex)
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
            res = ((MbusSerialMasterProtocol) mConnection).openProtocol(cmbComPort.Text, baudRate, dataBits, stopBits, parity);
            if (res == BusProtocolErrors.FTALK_SUCCESS)
            {
                mModbusSlaveID = Convert.ToUInt16(txtDeviceID.Text);
                mConnection.configureSwappedFloats();
                //mConnection.configureCountFromOne(mModbusSlaveID);
                lblResult.Text = "Serial port opened successfully with parameters: " + cmbComPort.Text + ", " + baudRate + " baud, " + dataBits + " data bits, " + stopBits + " stop bits, parity " + parity;
                //mParamManager = new ParamManager();
                //mParamManager.ParseMeterXML("C:\\Dev\\UUU\\Data\\UIMParamData.xml");
            }
            else
                lblResult.Text = "Could not open protocol, error was: " + BusProtocolErrors.getBusProtocolErrorText(res);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            // Creates all the text boxes and labels based on the XML. Creates a hash table
            // of modbus reg id's and corresponding text controls for the value.
            mParamManager = new ParamManager();
            // mParamManager.ParseMeterXML("C:\\Dev\\UIM\\Data\\1.0.1_ParamsWClassNames.xml");//C:\\Dev\\UUU\\Data\\UIMParamData.xml");
            mParamManager.ParseMeterXML(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "1.0.1_ParamsWClassNames.xml"));

            FlowLayoutPanel pnlLiveData = pnlLiveData1;
            FlowLayoutPanel pnlParams = pnlParam1_1;
            FlowLayoutPanel subPnl = null;
            bool bLiveDataGroupWritten = false;
            bool bParamGroupWritten = false;
            TextBox lbl;
            int liveDataRow = 0, paramDataRow = 0;
            int panelHeight = 16;
            pnlLiveData.Controls.Clear();
            // Pending make param groups enumeratable.
            for (int i = 0; i < mParamManager.mParamContainer.ParameterGroups.Count(); i++)
            {
                bLiveDataGroupWritten = false;
                bParamGroupWritten = false;
                ParamManager.ParameterGroup pg = mParamManager.mParamContainer.ParameterGroups[i];
                // Pending make parameters enumeratable.
                for (int j = 0; j < pg.Parameters.Count(); j++) // (Parameter param in pg.Parameters)
                {
                    ParamManager.Parameter param = pg.Parameters[j];
                    if (param.ModbusID != 0)
                    {
                        if (param.RW == "R") // && param.Type == "D")
                        {
#if true                    // Add the Group Name the first time through.
                            if (!bLiveDataGroupWritten)
                            {   
                                subPnl = new FlowLayoutPanel();
                                subPnl.Margin = new Padding(0,0,0,0);
                                subPnl.FlowDirection = FlowDirection.LeftToRight;
                                subPnl.Height = panelHeight;
                                pnlLiveData.Controls.Add(subPnl);
                                subPnl.Width = 630;
                                bLiveDataGroupWritten = true;
                                // Add the name.
                                lbl = new TextBox();
                                lbl.Text = pg.Name;
                                lbl.TextAlign = HorizontalAlignment.Left;
                                lbl.BackColor = pnlLiveData.BackColor;
                                lbl.Font = new Font(lbl.Font, FontStyle.Bold);
                                lbl.BorderStyle = BorderStyle.None;
                                lbl.Height = 13;
                                lbl.Width = 78;
                                lbl.Enabled = false;
                                subPnl.Controls.Add(lbl);
                                liveDataRow++;
                            }
                            // Add the param name, value boxes and unit string.
                            // Loop through all the elements in the value array.
                            for (int k = 0; k < Convert.ToInt16(param.Elements); k++)
                            {   // Create a new row every 4 element vaues and add a label for the param name.
                                // we only put the name in the first row, we will add a blank label to the
                                // other rows to maintain spacing.
                                if (k % 4 == 0)
                                {
                                    liveDataRow++; 
                                    subPnl = new FlowLayoutPanel();
                                    subPnl.FlowDirection = FlowDirection.LeftToRight;
                                    subPnl.Margin = new Padding(0, 0, 0, 0);
                                    pnlLiveData.Controls.Add(subPnl);
                                    subPnl.Width = 630;
                                    subPnl.Height = panelHeight;
                                    // Add the name.
                                    lbl = new TextBox();
                                    //lbl.Font = new System.Drawing.Font("Lucida Console", 8, FontStyle.Regular);
                                    
                                    if (k == 0) // The first time we add the name of the param in the label.
                                    {
                                        lbl.Text = param.Name;
                                    }
                                    lbl.TextAlign = HorizontalAlignment.Right;
                                    lbl.BorderStyle = BorderStyle.None;
                                    lbl.BackColor = subPnl.BackColor;
                                    lbl.Height = 13;
                                    lbl.Width = 90;
                                    //lbl.Enabled = false;
                                    lbl.ForeColor = Color.FromArgb(0, 0, 0);
                                    subPnl.Controls.Add(lbl);
                                }
                                // Add a value box for each element.
                            //for (int k = 0; k < Convert.ToInt16(param.Elements); k++)
                            //{
                                lbl = new TextBox();
                                lbl.Height = 13;
                                lbl.Width = 100;
                                lbl.TextAlign = HorizontalAlignment.Right;
                                lbl.BackColor = pnlLiveData.BackColor;
                                lbl.BorderStyle = BorderStyle.None;
                                lbl.Font = new System.Drawing.Font("Lucida Console", 8, FontStyle.Regular);
                                int modbusID = 0;
                                switch (param.Type)
                                {
                                case "D": // Skip 2 regs for float 32.
                                    modbusID = param.ModbusID + 2 * k;
                                    break;
                                case "X":
                                case "UI":
                                case "I": // If its a Int32 skip 2, (0x100 in options)
                                    if ((param.Options & (UInt32) UIM.ParamManager.ParamOptions.eModbusULong) != 0)
                                    {
                                        modbusID = param.ModbusID + 2 * k;
                                    }
                                    else // Int16, skip just one register.
                                    {
                                       modbusID = param.ModbusID + k;
                                    }
                                    break;
                                }
                                subPnl.Controls.Add(lbl);
                                mParamManager.mRegisterControlHash.Add(modbusID, lbl);
                            }
                            // Add the unit string.
                            lbl = new TextBox();
                            lbl.Width = 30;
                            lbl.Height = 13;
                            lbl.Text = ""; // "unit";
                            lbl.BackColor = subPnl.BackColor;
                            lbl.BorderStyle = BorderStyle.None;
                            lbl.Enabled = false;
                            subPnl.Controls.Add(lbl);
                            
                            // If we get to 46 rows go to the next panel.
                            if (liveDataRow >= 38)
                            {
                                liveDataRow = 0;
                                if (pnlLiveData != pnlLiveData2)
                                {
                                    pnlLiveData = pnlLiveData2;
                                    //liveDataRow = 0;
                                }
                                //else
                                    //return;
                            }
#endif
                        } // End Read only.
                        else //if (param.Type == "UI" || param.Type == "X")
                        { // ReadWrite
                            if (!bParamGroupWritten)
                            {
                                subPnl = new FlowLayoutPanel();
                                subPnl.Margin = new Padding(0, 0, 0, 0);
                                subPnl.FlowDirection = FlowDirection.LeftToRight;
                                subPnl.Height = panelHeight;
                                pnlParams.Controls.Add(subPnl);
                                subPnl.Width = 630;
                                bParamGroupWritten = true;
                                // Add the name.
                                Label lbl1;
                                lbl1 = new Label(); //TextBox();
                                lbl1.Text = pg.Name;
                                lbl1.TextAlign = ContentAlignment.MiddleLeft;// HorizontalAlignment.Left;
                                lbl1.BackColor = pnlLiveData1.BackColor;
                                lbl1.Font = new Font(lbl1.Font, FontStyle.Bold);
                                lbl1.BorderStyle = BorderStyle.None;
                                lbl1.Enabled = false;
                                lbl1.Height = 13;
                                lbl1.Width = 78;
                                subPnl.Controls.Add(lbl1);
                                paramDataRow++;
                            }
                            for (int k = 0; k < Convert.ToInt16(param.Elements); k++)
                            {   // New row every 4 params.
                                if (k % 4 == 0)
                                {
                                    paramDataRow++;
                                    subPnl = new FlowLayoutPanel();
                                    subPnl.FlowDirection = FlowDirection.LeftToRight;
                                    subPnl.Margin = new Padding(0, 0, 0, 0);
                                    pnlParams.Controls.Add(subPnl);
                                    subPnl.Width = 630;
                                    subPnl.Height = panelHeight;
                                    // Add the name.
                                    lbl = new TextBox();
                                    if (k == 0)
                                    {
                                        lbl.Text = param.Name;
                                    }
                                    lbl.TextAlign = HorizontalAlignment.Right;
                                    lbl.BorderStyle = BorderStyle.None;
                                    lbl.BackColor = subPnl.BackColor;
                                    lbl.Height = 13;
                                    lbl.Width = 80;
                                    lbl.Enabled = false; 
                                    subPnl.Controls.Add(lbl);
                                }
                            // Add a value box for each element.
                            //for (int k = 0; k < Convert.ToInt16(param.Elements); k++)
                            //{
                                lbl = new TextBox();
                                lbl.TextChanged += ModbusTextBox_TextChanged;
                                lbl.Leave += ModbusTextBox_Leave;
                                lbl.Height = 13;
                                lbl.Width = 100;
                                lbl.TextAlign = HorizontalAlignment.Right;
                                //lbl.BackColor = pnlLiveData.BackColor;
                                lbl.BorderStyle = BorderStyle.None;
                                lbl.Font = new System.Drawing.Font("Lucida Console", 9, FontStyle.Regular);
                                int modbusID = 0;
                                switch (param.Type)
                                {
                                    case "D":
                                        modbusID = param.ModbusID + 2 * k;
                                        break;
                                    case "X":
                                    case "UI":
                                    case "I":
                                        if ((Convert.ToInt16(param.Options) & 0x0100) != 0)
                                        {
                                            modbusID = param.ModbusID + 2 * k;
                                        }
                                        else
                                        {
                                            modbusID = param.ModbusID + k;
                                        }
                                        break;
                                }
                                lbl.Tag = modbusID.ToString();
                                //mbObjectChangedByCode = true;
                                //lbl.Text = modbusID.ToString();
                                //mbObjectChangedByCode = false;
                                
                                subPnl.Controls.Add(lbl);
                                mParamManager.mRegisterControlHash.Add(modbusID, lbl);

                            }
                            // Add the unit string.
                            lbl = new TextBox();
                            lbl.Width = 30;
                            lbl.Height = 13;
                            lbl.Text = "";// "unit";
                            lbl.BackColor = subPnl.BackColor;
                            lbl.BorderStyle = BorderStyle.None;
                            lbl.Enabled = false;
                            subPnl.Controls.Add(lbl);
                            // If we get to 46 rows go to the next panel.
                            if (paramDataRow >= 35)
                            {
                                bParamGroupWritten = false;
                                if (pnlParams == pnlParam1_1)
                                {
                                    pnlParams = pnlParam1_2;
                                }
                                else if (pnlParams == pnlParam1_2)
                                {
                                    pnlParams = pnlParam2_1;
                                }
                                else if (pnlParams == pnlParam2_1)
                                {
                                    pnlParams = pnlParam2_2;
                                }
                                else if (pnlParams == pnlParam2_2)
                                {
                                    return;
                                }
                                else
                                {
                                    //return;
                                }
                                paramDataRow = 0;
                            }
                        } // Read Write.
                    } // Modbus ID
                } // For Param.
            } // For Group.

           mParamManager.InitModbusMsgGroups(Convert.ToUInt16(this.txtDeviceID.Text));
           timModbusMessage.Enabled = true;

//            mParamManager = new ParamManager();
//            mParamManager.ParseMeterXML("C:\\Dev\\UUU\\Data\\UIMParamData.xml");
        }

        private void timModbusMessage_Tick(object sender, EventArgs e)
        {
            int iCount = 0;
            //Thread workerThread = new Thread(mMBComm.SendMsg);
            //workerThread.Start();
            //mMBComm.SendMsg();
            // Copy any repeating messages into the message q.
            foreach (ParamManager.ModbusReadHoldingMsg msg in mParamManager.mModbusMsgGroup)
            {
                mParamManager.mMessageQ.Add(msg);
            }
            // mParamManager.mModbusMsgGroup.Clear();
            foreach (ParamManager.ModbusReadHoldingMsg msg in mParamManager.mMessageQ)
            {
                if (iCount < 32)
                {
                    Int32 res = 0;
                    int count = 0;
                    do
                    {
                        res = mConnection.readMultipleRegisters(msg.SlaveID, msg.StartReg + 1, msg.ReadVals, msg.NumRegs);
                        //if (res != 0)
                        //    Thread.Sleep(500);
                    } while (res != 0 && count++ < 20);

                    //if (res != 0)
                    //{
                    //    Thread.Sleep(100);
                    //}

                    if (count > mMaxErrors)
                        mMaxErrors = count;

                    if (count >= 20)
                    {
                        lblResult.Text = "Result: " + BusProtocolErrors.getBusProtocolErrorText(res) + "\n\r"; 
                        int ggg;
                        ggg = 33;
                    }
                        

                    
                    iCount++;
                    if (res == BusProtocolErrors.FTALK_SUCCESS)
                    {

                        switch (msg.DataType)
                        {
                            case "D":
                                mParamManager.MBRegsToFloats(msg);
                                for (int i = 0; i < msg.NumVals; i++)
                                {
                                    mbObjectChangedByCode = true;
                                    TextBox tbox = (TextBox)(mParamManager.mRegisterControlHash[(int)(msg.RegIds[i])]); //;
                                    tbox.Text = msg.FloatVals[i].ToString();
                                    mbObjectChangedByCode = false;
                                }
                                break;
                            case "U16":
                                mParamManager.MBRegsToUInt16(msg);
                                for (int i = 0; i < msg.NumVals; i++)
                                {
                                    mbObjectChangedByCode = true;
                                    TextBox tbox = (TextBox)(mParamManager.mRegisterControlHash[(int)(msg.RegIds[i])]); //;
                                    tbox.Text = msg.UInt16Vals[i].ToString();
                                    mbObjectChangedByCode = false;
                                }
                                break;
                            case "I16":
                                mParamManager.MBRegsToInt16(msg);
                                for (int i = 0; i < msg.NumVals; i++)
                                {
                                    mbObjectChangedByCode = true;
                                    TextBox tbox = (TextBox)(mParamManager.mRegisterControlHash[(int)(msg.RegIds[i])]); //;
                                    tbox.Text = msg.ReadVals[i].ToString();
                                    mbObjectChangedByCode = false;
                                }
                                break;
                            case "U32":
                                mParamManager.MBRegsToUInt32(msg);
                                for (int i = 0; i < msg.NumVals; i++)
                                {
                                    TextBox tbox = (TextBox)(mParamManager.mRegisterControlHash[(int)(msg.RegIds[i])]); //;
                                    tbox.Text = string.Format("0x{0:X8}", msg.UInt32Vals[i]);
                                }
                                break;
                        }
                    }
                    //ProcessResponse(msg);
                }
                else
                {
                    int z = 22;
                }
            }

            // DeQueue the message.
            mParamManager.mMessageQ.Clear();


            
        }

        private void btnTestDynamicFill_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
                    }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnTest_Click(sender, e);
        }

        private void pnlParam2_1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGetValue_Click(object sender, EventArgs e)
        {
            ParamManager.ModbusReadHoldingMsg msg = new ParamManager.ModbusReadHoldingMsg();
            msg.Command = 0x3;
            msg.DataType = txtDataType.Text;
            msg.DeQueue = true;
            msg.StartReg = Convert.ToUInt16(txtStartReg.Text);
            msg.NumRegs = Convert.ToUInt16(txtNumRegs.Text);
            msg.SlaveID = 1;
            msg.RegIds[0] = msg.StartReg;
            mParamManager.mMessageQ.Add(msg);
            
        }

        void ModbusTextBox_Leave(object sender, EventArgs e)
        {
            // 1 dim arrays for holding the write value
            Int16[] I16Val = new Int16[1];
            float[] FloatVal = new float[1];
            Int32[] I32Val = new Int32[1];

            // If the text box we are losing focus on is flagged as dirty.
            if (mDirtyTextBox == (TextBox)sender)
            {
                // Get the parameter from the modbus id, it is stashed in the control tag.
                UInt16 modbusID = Convert.ToUInt16(mDirtyTextBox.Tag);
                // Get the param from the param manager reg param hash.
                UInt16 testModbusID = modbusID;
                ParamManager.Parameter param = null;
                while (param == null)
                {
                    param = (ParamManager.Parameter)(mParamManager.mRegisterParamHash[(ushort)testModbusID]);
                    testModbusID -= 1;
                }

                // Need to add 1 for new offset in instrument.
                modbusID++;
                switch (param.Type)
                {
                    case "UI":
                    case "X":
                    case "I":
                        // Is 32 bit?
                        if ((param.Options & (UInt32)UIM.ParamManager.ParamOptions.eModbusULong) != 0)
                        {
                            // Here 32 bit.
                            int ggg = 22;
                        }
                        else
                        {
                            // 16 b bit.
                            mConnection.writeSingleRegister(mModbusSlaveID, modbusID + 1, Convert.ToUInt16(mDirtyTextBox.Text));
                            mConnection.readMultipleRegisters(mModbusSlaveID, modbusID, I16Val);
                            mDirtyTextBox.Text = I16Val[0].ToString();
                        }
                        break;
                    case "D":
                        FloatVal[0] = (float) Convert.ToDouble(mDirtyTextBox.Text);
                        mConnection.writeMultipleFloats(mModbusSlaveID, modbusID, FloatVal);
                        mConnection.readMultipleFloats(mModbusSlaveID, modbusID, FloatVal);
                        mDirtyTextBox.Text = FloatVal[0].ToString();
                        break;
                }

                mDirtyTextBox = null;
                //mConnection.readInputFloats(mModbusSlaveID, 11151, FloatVal);

                //mConnection.writeMultipleFloats(mModbusSlaveID, 11151, FloatVal);

                //mConnection.configureSwappedFloats();
                //mConnection.readMultipleFloats(mModbusSlaveID, 11151, FloatVal);

                //mConnection.readMultipleRegisters(1, 12142, ReadVal); 
                //mConnection.writeSingleRegister(1, 12142, 2);
                //mConnection.readMultipleRegisters(1, 12142, ReadVal);
                
                int z;
                z = 32;
            }
        }

        private void ModbusTextBox_TextChanged(object sender, EventArgs e)
        {
            // Only send msg for text changed by user.
            if (!mbObjectChangedByCode)
            {
                TextBox tb = (TextBox) sender;
                mDirtyTextBox = tb;
                int z;
                z = 32;
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {

            Int32 res = 0;
            ParamManager.ModbusReadHoldingMsg msg = new ParamManager.ModbusReadHoldingMsg();
            msg.SlaveID = Convert.ToUInt16(this.txtDeviceID.Text);
            //msg.StartReg = 12186 ;
            msg.StartReg = 40002;
            //msg.StartReg = 12222;
            msg.NumRegs = 120;
            txtMSGResponse.Text = "";
            Int16[] z = new Int16[1];
            Int32[] z32 = new Int32[1];
            z32[0] = 1;
            z[0] = 1;
            mConnection.timeout = 2000;
            //Int32 resz = mConnection.writeSingleRegister(0x1, 30003, 1);
            //resz = mConnection.writeMultipleLongInts(1, 30003,z32,2);
            float[] FloatVal = new float[1];
            //mConnection.readMultipleFloats(mModbusSlaveID, 11325, FloatVal);
            //mConnection.writeMultipleFloats(mModbusSlaveID, 11325, FloatVal);
            //mConnection.readMultipleFloats(mModbusSlaveID, 11325, FloatVal);
            //mConnection.writeSingleRehedfffggister(mModbusSlaveID, 12070, 1);
                ParamManager pm = new ParamManager();
            //res = mConnection.readInputFloats
            res = mConnection.readMultipleRegisters(msg.SlaveID, msg.StartReg, msg.ReadVals, msg.NumRegs);
           // mConnectionasyn = new MbusMasterFunctionsasyc();
            //mConnectionasyn.readMultipleRegistersasyc(mConnection,msg);
            pm.MBRegsToInt16(msg);
            pm.MBRegsToUInt16(msg);
            pm.MBRegsToFloats(msg);
            pm.MBRegsToUInt32(msg);
            txtMSGResponse.Text = "Result: " + BusProtocolErrors.getBusProtocolErrorText(res) + " " + ErrCount + "\n\r";
            int g = 21;
            if (res != BusProtocolErrors.FTALK_SUCCESS)
            {
             ErrCount++; 
             int h = 21;
            }
        }

        private void timTestMSG_Tick(object sender, EventArgs e)
        {
            EventArgs z;
            timTestMSG.Enabled = false;
            int count = Convert.ToInt32(txtMSGCount.Text);
            count++;
            txtMSGCount.Text = count.ToString();
            btnSendMessage_Click(null, (EventArgs) null);
            timTestMSG.Enabled = true;
        }

        private void chkTestTimerEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTestTimerEnable.Checked == true)
            {
                txtMSGCount.Text = "0";
                timTestMSG.Enabled = true;
            }
            else
            {
                timTestMSG.Enabled = false;
            }
        }
        
        static void mMBComm_OnComm(object sender, EventArgs e)
        {
            Console.WriteLine("The threshold was reached.");
        }

        void WriteSignalsToFile()
        {
            //System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\Dev\\UUU\\Data\\sig2.csv", false);
            Int32 res;
            ParamManager.ModbusReadHoldingMsg msg = new ParamManager.ModbusReadHoldingMsg();
            ParamManager pm = new ParamManager();
            msg.SlaveID = Convert.ToUInt16(this.txtDeviceID.Text);
            msg.StartReg = 40001;
            msg.NumRegs = 50;
            txtMSGResponse.Text = "";

            for (int i = 0; i < 10; i++)
            {
                res = 0;
                int count = 0;
                do
                {
                    res = mConnection.readMultipleRegisters(msg.SlaveID, msg.StartReg, msg.ReadVals, msg.NumRegs);
                    count++;
                } while (res != 0 && count < 3);
                if (count > 1)
                {
                    int z = 21;
                }
                pm.MBRegsToInt16(msg);
                txtMSGResponse.Text = "Result: " + BusProtocolErrors.getBusProtocolErrorText(res) + " " + ErrCount + "\n\r";
#if false
                if (res == BusProtocolErrors.FTALK_SUCCESS)
                {
                    for (int j = 0; j < 125; j++)
                    {
                        sw.Write(msg.ReadVals[j].ToString());
                    
                        if (i == 3 && j == 124)
                        {
                            sw.WriteLine("");
                        }
                        else
                        {
                            sw.Write(",");
                        }
                    }
                }
#endif
                msg.StartReg += 50;
            }

           // sw.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WriteSignalsToFile();
        }
            
    }
}
 




#if false
public event MPCFileCreatedDelegate MPCFileCreated;
this.RaiseMPCFileCreated(this.mFileName, addfile);
public void RaiseMPCFileCreated(string sFileName, bool addfile)
        {
            Debug.WriteLine(string.Format("Created MPC File: {0}", this.mFileName));
            if (this.MPCFileCreated != null)
            {
                this.MPCFileCreated(this, sFileName, addfile);
            }
        }
Then in the listener...
this.Meter.MPCFileManager.MPCFileCreated += this.SignalDataManager_MPCFileCreated;
#endif