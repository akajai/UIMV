namespace UIM
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.chkTestTimerEnable = new System.Windows.Forms.CheckBox();
            this.txtMSGCount = new System.Windows.Forms.TextBox();
            this.txtMSGResponse = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDeviceID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbRetry = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.txtPollDelay = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmdOpenSerial = new System.Windows.Forms.Button();
            this.cmbSerialProtocol = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLiveData1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLiveData2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnTestDynamicFill = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabParams = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlParam1_1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlParam1_2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlParam2_1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlParam2_2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtDataType = new System.Windows.Forms.TextBox();
            this.txtNumRegs = new System.Windows.Forms.TextBox();
            this.txtStartReg = new System.Windows.Forms.TextBox();
            this.btnGetValue = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.timModbusMessage = new System.Windows.Forms.Timer(this.components);
            this.timTestMSG = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.tabParams.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1701, 858);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Silver;
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.chkTestTimerEnable);
            this.tabPage1.Controls.Add(this.txtMSGCount);
            this.tabPage1.Controls.Add(this.txtMSGResponse);
            this.tabPage1.Controls.Add(this.btnSendMessage);
            this.tabPage1.Controls.Add(this.btnTest);
            this.tabPage1.Controls.Add(this.GroupBox1);
            this.tabPage1.Controls.Add(this.GroupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1693, 829);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(783, 41);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 17;
            this.button1.Text = "Write to File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // chkTestTimerEnable
            // 
            this.chkTestTimerEnable.AutoSize = true;
            this.chkTestTimerEnable.Location = new System.Drawing.Point(1119, 176);
            this.chkTestTimerEnable.Margin = new System.Windows.Forms.Padding(4);
            this.chkTestTimerEnable.Name = "chkTestTimerEnable";
            this.chkTestTimerEnable.Size = new System.Drawing.Size(114, 21);
            this.chkTestTimerEnable.TabIndex = 16;
            this.chkTestTimerEnable.Text = "Enable Timer";
            this.chkTestTimerEnable.UseVisualStyleBackColor = true;
            this.chkTestTimerEnable.CheckedChanged += new System.EventHandler(this.chkTestTimerEnable_CheckedChanged);
            // 
            // txtMSGCount
            // 
            this.txtMSGCount.Location = new System.Drawing.Point(1001, 327);
            this.txtMSGCount.Margin = new System.Windows.Forms.Padding(4);
            this.txtMSGCount.Name = "txtMSGCount";
            this.txtMSGCount.Size = new System.Drawing.Size(87, 22);
            this.txtMSGCount.TabIndex = 15;
            this.txtMSGCount.Text = "0";
            // 
            // txtMSGResponse
            // 
            this.txtMSGResponse.Location = new System.Drawing.Point(1001, 210);
            this.txtMSGResponse.Margin = new System.Windows.Forms.Padding(4);
            this.txtMSGResponse.Multiline = true;
            this.txtMSGResponse.Name = "txtMSGResponse";
            this.txtMSGResponse.Size = new System.Drawing.Size(507, 77);
            this.txtMSGResponse.TabIndex = 15;
            this.txtMSGResponse.Text = "1";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(783, 207);
            this.btnSendMessage.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(100, 28);
            this.btnSendMessage.TabIndex = 9;
            this.btnSendMessage.Text = "SendMSG";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(555, 327);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(100, 28);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.GroupBox1.Controls.Add(this.txtDeviceID);
            this.GroupBox1.Controls.Add(this.label10);
            this.GroupBox1.Controls.Add(this.cmbRetry);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txtTimeout);
            this.GroupBox1.Controls.Add(this.txtPollDelay);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Location = new System.Drawing.Point(315, 7);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Size = new System.Drawing.Size(245, 281);
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Common Options";
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.Location = new System.Drawing.Point(101, 155);
            this.txtDeviceID.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.Size = new System.Drawing.Size(87, 22);
            this.txtDeviceID.TabIndex = 13;
            this.txtDeviceID.Text = "1";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(13, 156);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 25);
            this.label10.TabIndex = 14;
            this.label10.Text = "Device ID:";
            // 
            // cmbRetry
            // 
            this.cmbRetry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRetry.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cmbRetry.Location = new System.Drawing.Point(101, 71);
            this.cmbRetry.Margin = new System.Windows.Forms.Padding(4);
            this.cmbRetry.Name = "cmbRetry";
            this.cmbRetry.Size = new System.Drawing.Size(87, 24);
            this.cmbRetry.TabIndex = 9;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(13, 33);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(80, 25);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Time-out:";
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(13, 75);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(68, 25);
            this.Label5.TabIndex = 10;
            this.Label5.Text = "Retries:";
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(101, 32);
            this.txtTimeout.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(87, 22);
            this.txtTimeout.TabIndex = 0;
            this.txtTimeout.Text = "1000";
            // 
            // txtPollDelay
            // 
            this.txtPollDelay.Location = new System.Drawing.Point(101, 113);
            this.txtPollDelay.Margin = new System.Windows.Forms.Padding(4);
            this.txtPollDelay.Name = "txtPollDelay";
            this.txtPollDelay.Size = new System.Drawing.Size(87, 22);
            this.txtPollDelay.TabIndex = 11;
            this.txtPollDelay.Text = "0";
            // 
            // Label9
            // 
            this.Label9.Location = new System.Drawing.Point(13, 114);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(95, 25);
            this.Label9.TabIndex = 12;
            this.Label9.Text = "Poll Delay:";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.cmbDataBits);
            this.GroupBox2.Controls.Add(this.cmbStopBits);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.cmbParity);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.cmbBaudRate);
            this.GroupBox2.Controls.Add(this.cmbComPort);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Controls.Add(this.cmdOpenSerial);
            this.GroupBox2.Controls.Add(this.cmbSerialProtocol);
            this.GroupBox2.Location = new System.Drawing.Point(11, 7);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox2.Size = new System.Drawing.Size(221, 281);
            this.GroupBox2.TabIndex = 6;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Serial Modbus";
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBits.Items.AddRange(new object[] {
            "8",
            "7"});
            this.cmbDataBits.Location = new System.Drawing.Point(109, 165);
            this.cmbDataBits.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(93, 24);
            this.cmbDataBits.TabIndex = 13;
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbStopBits.Location = new System.Drawing.Point(109, 198);
            this.cmbStopBits.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(93, 24);
            this.cmbStopBits.TabIndex = 12;
            // 
            // Label8
            // 
            this.Label8.Location = new System.Drawing.Point(13, 166);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(84, 22);
            this.Label8.TabIndex = 11;
            this.Label8.Text = "Databits:";
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(13, 199);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(64, 22);
            this.Label7.TabIndex = 10;
            this.Label7.Text = "Stopbits:";
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(13, 133);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(64, 22);
            this.Label6.TabIndex = 9;
            this.Label6.Text = "Parity:";
            // 
            // cmbParity
            // 
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbParity.Location = new System.Drawing.Point(109, 132);
            this.cmbParity.Margin = new System.Windows.Forms.Padding(4);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(93, 24);
            this.cmbParity.TabIndex = 8;
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(13, 100);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(75, 22);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Protocol:";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(13, 66);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(84, 22);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Baud Rate:";
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200",
            "125000",
            "128000",
            "256000"});
            this.cmbBaudRate.Location = new System.Drawing.Point(109, 65);
            this.cmbBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(93, 24);
            this.cmbBaudRate.TabIndex = 4;
            // 
            // cmbComPort
            // 
            this.cmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14"});
            this.cmbComPort.Location = new System.Drawing.Point(109, 32);
            this.cmbComPort.Margin = new System.Windows.Forms.Padding(4);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(93, 24);
            this.cmbComPort.TabIndex = 3;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(13, 33);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(84, 22);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "COM Port:";
            // 
            // cmdOpenSerial
            // 
            this.cmdOpenSerial.Location = new System.Drawing.Point(45, 236);
            this.cmdOpenSerial.Margin = new System.Windows.Forms.Padding(4);
            this.cmdOpenSerial.Name = "cmdOpenSerial";
            this.cmdOpenSerial.Size = new System.Drawing.Size(127, 27);
            this.cmdOpenSerial.TabIndex = 2;
            this.cmdOpenSerial.Text = "Open Serial";
            this.cmdOpenSerial.Click += new System.EventHandler(this.cmdOpenSerial_Click);
            // 
            // cmbSerialProtocol
            // 
            this.cmbSerialProtocol.DisplayMember = "1";
            this.cmbSerialProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialProtocol.Items.AddRange(new object[] {
            "RTU",
            "ASCII"});
            this.cmbSerialProtocol.Location = new System.Drawing.Point(109, 98);
            this.cmbSerialProtocol.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSerialProtocol.Name = "cmbSerialProtocol";
            this.cmbSerialProtocol.Size = new System.Drawing.Size(93, 24);
            this.cmbSerialProtocol.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowLayoutPanel1);
            this.tabPage2.Controls.Add(this.lblResult);
            this.tabPage2.Controls.Add(this.btnTestDynamicFill);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1693, 829);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Live Data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.flowLayoutPanel1.Controls.Add(this.pnlLiveData1);
            this.flowLayoutPanel1.Controls.Add(this.pnlLiveData2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1707, 825);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // pnlLiveData1
            // 
            this.pnlLiveData1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlLiveData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLiveData1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlLiveData1.Location = new System.Drawing.Point(4, 4);
            this.pnlLiveData1.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLiveData1.Name = "pnlLiveData1";
            this.pnlLiveData1.Size = new System.Drawing.Size(842, 812);
            this.pnlLiveData1.TabIndex = 0;
            // 
            // pnlLiveData2
            // 
            this.pnlLiveData2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlLiveData2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLiveData2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlLiveData2.Location = new System.Drawing.Point(854, 4);
            this.pnlLiveData2.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLiveData2.Name = "pnlLiveData2";
            this.pnlLiveData2.Size = new System.Drawing.Size(842, 812);
            this.pnlLiveData2.TabIndex = 1;
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.Location = new System.Drawing.Point(11, 657);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(1672, 174);
            this.lblResult.TabIndex = 17;
            this.lblResult.Text = "Result:";
            // 
            // btnTestDynamicFill
            // 
            this.btnTestDynamicFill.Location = new System.Drawing.Point(589, 138);
            this.btnTestDynamicFill.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestDynamicFill.Name = "btnTestDynamicFill";
            this.btnTestDynamicFill.Size = new System.Drawing.Size(100, 28);
            this.btnTestDynamicFill.TabIndex = 3;
            this.btnTestDynamicFill.Text = "button1";
            this.btnTestDynamicFill.UseVisualStyleBackColor = true;
            this.btnTestDynamicFill.Click += new System.EventHandler(this.btnTestDynamicFill_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer1);
            this.tabPage3.Controls.Add(this.tabParams);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1693, 829);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Parameters";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(1693, 829);
            this.splitContainer1.SplitterDistance = 564;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabParams
            // 
            this.tabParams.Controls.Add(this.tabPage5);
            this.tabParams.Controls.Add(this.tabPage6);
            this.tabParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabParams.Location = new System.Drawing.Point(0, 0);
            this.tabParams.Margin = new System.Windows.Forms.Padding(4);
            this.tabParams.Name = "tabParams";
            this.tabParams.SelectedIndex = 0;
            this.tabParams.Size = new System.Drawing.Size(1693, 829);
            this.tabParams.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.flowLayoutPanel2);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage5.Size = new System.Drawing.Size(1685, 800);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Page 1";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.pnlParam1_1);
            this.flowLayoutPanel2.Controls.Add(this.pnlParam1_2);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1677, 792);
            this.flowLayoutPanel2.TabIndex = 19;
            // 
            // pnlParam1_1
            // 
            this.pnlParam1_1.BackColor = System.Drawing.SystemColors.Control;
            this.pnlParam1_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlParam1_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlParam1_1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlParam1_1.Location = new System.Drawing.Point(4, 4);
            this.pnlParam1_1.Margin = new System.Windows.Forms.Padding(4);
            this.pnlParam1_1.Name = "pnlParam1_1";
            this.pnlParam1_1.Size = new System.Drawing.Size(811, 736);
            this.pnlParam1_1.TabIndex = 0;
            // 
            // pnlParam1_2
            // 
            this.pnlParam1_2.BackColor = System.Drawing.SystemColors.Control;
            this.pnlParam1_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlParam1_2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlParam1_2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlParam1_2.Location = new System.Drawing.Point(823, 4);
            this.pnlParam1_2.Margin = new System.Windows.Forms.Padding(4);
            this.pnlParam1_2.Name = "pnlParam1_2";
            this.pnlParam1_2.Size = new System.Drawing.Size(842, 736);
            this.pnlParam1_2.TabIndex = 1;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.flowLayoutPanel5);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage6.Size = new System.Drawing.Size(1685, 800);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Page 2";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.flowLayoutPanel5.Controls.Add(this.pnlParam2_1);
            this.flowLayoutPanel5.Controls.Add(this.pnlParam2_2);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(1677, 783);
            this.flowLayoutPanel5.TabIndex = 19;
            // 
            // pnlParam2_1
            // 
            this.pnlParam2_1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlParam2_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlParam2_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlParam2_1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlParam2_1.Location = new System.Drawing.Point(4, 4);
            this.pnlParam2_1.Margin = new System.Windows.Forms.Padding(4);
            this.pnlParam2_1.Name = "pnlParam2_1";
            this.pnlParam2_1.Size = new System.Drawing.Size(810, 739);
            this.pnlParam2_1.TabIndex = 0;
            this.pnlParam2_1.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlParam2_1_Paint);
            // 
            // pnlParam2_2
            // 
            this.pnlParam2_2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlParam2_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlParam2_2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlParam2_2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlParam2_2.Location = new System.Drawing.Point(822, 4);
            this.pnlParam2_2.Margin = new System.Windows.Forms.Padding(4);
            this.pnlParam2_2.Name = "pnlParam2_2";
            this.pnlParam2_2.Size = new System.Drawing.Size(842, 738);
            this.pnlParam2_2.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtDataType);
            this.tabPage4.Controls.Add(this.txtNumRegs);
            this.tabPage4.Controls.Add(this.txtStartReg);
            this.tabPage4.Controls.Add(this.btnGetValue);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1693, 829);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Diagnostics";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtDataType
            // 
            this.txtDataType.Location = new System.Drawing.Point(637, 81);
            this.txtDataType.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataType.Name = "txtDataType";
            this.txtDataType.Size = new System.Drawing.Size(132, 22);
            this.txtDataType.TabIndex = 3;
            this.txtDataType.Text = "Type";
            // 
            // txtNumRegs
            // 
            this.txtNumRegs.Location = new System.Drawing.Point(496, 81);
            this.txtNumRegs.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumRegs.Name = "txtNumRegs";
            this.txtNumRegs.Size = new System.Drawing.Size(132, 22);
            this.txtNumRegs.TabIndex = 2;
            this.txtNumRegs.Text = "NumRegs";
            // 
            // txtStartReg
            // 
            this.txtStartReg.Location = new System.Drawing.Point(355, 81);
            this.txtStartReg.Margin = new System.Windows.Forms.Padding(4);
            this.txtStartReg.Name = "txtStartReg";
            this.txtStartReg.Size = new System.Drawing.Size(132, 22);
            this.txtStartReg.TabIndex = 1;
            this.txtStartReg.Text = "StartReg";
            // 
            // btnGetValue
            // 
            this.btnGetValue.Location = new System.Drawing.Point(143, 71);
            this.btnGetValue.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetValue.Name = "btnGetValue";
            this.btnGetValue.Size = new System.Drawing.Size(100, 28);
            this.btnGetValue.TabIndex = 0;
            this.btnGetValue.Text = "GetValue";
            this.btnGetValue.UseVisualStyleBackColor = true;
            this.btnGetValue.Click += new System.EventHandler(this.btnGetValue_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1693, 829);
            this.tabPage7.TabIndex = 4;
            this.tabPage7.Text = "MAP";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 25);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1693, 829);
            this.tabPage8.TabIndex = 5;
            this.tabPage8.Text = "Chart";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // timModbusMessage
            // 
            this.timModbusMessage.Interval = 1000;
            this.timModbusMessage.Tick += new System.EventHandler(this.timModbusMessage_Tick);
            // 
            // timTestMSG
            // 
            this.timTestMSG.Interval = 1000;
            this.timTestMSG.Tick += new System.EventHandler(this.timTestMSG_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1701, 858);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Transus Instruments Console for UIM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabParams.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.ComboBox cmbDataBits;
        internal System.Windows.Forms.ComboBox cmbStopBits;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox cmbParity;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cmbBaudRate;
        internal System.Windows.Forms.ComboBox cmbComPort;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button cmdOpenSerial;
        internal System.Windows.Forms.ComboBox cmbSerialProtocol;
        private System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ComboBox cmbRetry;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtTimeout;
        internal System.Windows.Forms.TextBox txtPollDelay;
        internal System.Windows.Forms.Label Label9;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        internal System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnTest;
        internal System.Windows.Forms.TextBox txtDeviceID;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timModbusMessage;
        private System.Windows.Forms.Button btnTestDynamicFill;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel pnlLiveData1;
        private System.Windows.Forms.FlowLayoutPanel pnlLiveData2;
        private System.Windows.Forms.TabControl tabParams;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel pnlParam1_1;
        private System.Windows.Forms.FlowLayoutPanel pnlParam1_2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.FlowLayoutPanel pnlParam2_1;
        private System.Windows.Forms.FlowLayoutPanel pnlParam2_2;
        private System.Windows.Forms.TextBox txtDataType;
        private System.Windows.Forms.TextBox txtNumRegs;
        private System.Windows.Forms.TextBox txtStartReg;
        private System.Windows.Forms.Button btnGetValue;
        internal System.Windows.Forms.TextBox txtMSGResponse;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Timer timTestMSG;
        private System.Windows.Forms.CheckBox chkTestTimerEnable;
        internal System.Windows.Forms.TextBox txtMSGCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

