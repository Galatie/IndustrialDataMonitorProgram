namespace IndustrialDataMonitorProgram
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            labProt = new Label();
            cmbProt = new ComboBox();
            labBaud = new Label();
            cmbBaud = new ComboBox();
            btnPortOpen = new Button();
            btnPortClose = new Button();
            labPortState = new Label();
            gpbPort = new GroupBox();
            labTcpState = new Label();
            labTcpS = new Label();
            btnTcpClose = new Button();
            btnTcpOpen = new Button();
            txbTcpPort = new TextBox();
            labTcpPort = new Label();
            txbTcpIp = new TextBox();
            labTcpIp = new Label();
            labPortS = new Label();
            panelDeviceStatus = new Panel();
            groupBox1 = new GroupBox();
            btnContinueRead = new Button();
            btnStopRead = new Button();
            btnStartRead = new Button();
            txbLen = new TextBox();
            labLen = new Label();
            txbAddr = new TextBox();
            txbSlave = new TextBox();
            labAddr = new Label();
            labSlave = new Label();
            groupBox2 = new GroupBox();
            btnQuery = new Button();
            btnUpload = new Button();
            labDeviceStatus = new Label();
            txbSpeed = new TextBox();
            labSpeed = new Label();
            txbPressure = new TextBox();
            labPressure = new Label();
            txbTemp = new TextBox();
            labTemp = new Label();
            gpbLog = new GroupBox();
            txbLogs = new TextBox();
            labLog = new Label();
            grpHisData = new GroupBox();
            chartdyna = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btnClear = new Button();
            dataGridView1 = new DataGridView();
            gpbPort.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            gpbLog.SuspendLayout();
            grpHisData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartdyna).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // labProt
            // 
            labProt.AutoSize = true;
            labProt.Location = new Point(18, 31);
            labProt.Name = "labProt";
            labProt.Size = new Size(61, 23);
            labProt.TabIndex = 0;
            labProt.Text = "串口：";
            // 
            // cmbProt
            // 
            cmbProt.FormattingEnabled = true;
            cmbProt.Location = new Point(81, 28);
            cmbProt.Name = "cmbProt";
            cmbProt.Size = new Size(151, 31);
            cmbProt.TabIndex = 1;
            // 
            // labBaud
            // 
            labBaud.AutoSize = true;
            labBaud.Location = new Point(1, 83);
            labBaud.Name = "labBaud";
            labBaud.Size = new Size(78, 23);
            labBaud.TabIndex = 2;
            labBaud.Text = "波特率：";
            // 
            // cmbBaud
            // 
            cmbBaud.FormattingEnabled = true;
            cmbBaud.Location = new Point(81, 80);
            cmbBaud.Name = "cmbBaud";
            cmbBaud.Size = new Size(151, 31);
            cmbBaud.TabIndex = 3;
            // 
            // btnPortOpen
            // 
            btnPortOpen.Location = new Point(248, 30);
            btnPortOpen.Name = "btnPortOpen";
            btnPortOpen.Size = new Size(94, 29);
            btnPortOpen.TabIndex = 4;
            btnPortOpen.Text = "打开串口";
            btnPortOpen.UseVisualStyleBackColor = true;
            btnPortOpen.Click += btnPortOpen_Click;
            // 
            // btnPortClose
            // 
            btnPortClose.Location = new Point(248, 80);
            btnPortClose.Name = "btnPortClose";
            btnPortClose.Size = new Size(94, 29);
            btnPortClose.TabIndex = 5;
            btnPortClose.Text = "关闭串口";
            btnPortClose.UseVisualStyleBackColor = true;
            btnPortClose.Click += btnPortClose_Click_1;
            // 
            // labPortState
            // 
            labPortState.AutoSize = true;
            labPortState.ForeColor = Color.Red;
            labPortState.Location = new Point(407, 68);
            labPortState.Name = "labPortState";
            labPortState.Size = new Size(61, 23);
            labPortState.TabIndex = 6;
            labPortState.Text = "已关闭";
            // 
            // gpbPort
            // 
            gpbPort.Controls.Add(labTcpState);
            gpbPort.Controls.Add(labTcpS);
            gpbPort.Controls.Add(btnTcpClose);
            gpbPort.Controls.Add(btnTcpOpen);
            gpbPort.Controls.Add(txbTcpPort);
            gpbPort.Controls.Add(labTcpPort);
            gpbPort.Controls.Add(txbTcpIp);
            gpbPort.Controls.Add(labTcpIp);
            gpbPort.Controls.Add(labPortS);
            gpbPort.Controls.Add(labPortState);
            gpbPort.Controls.Add(labBaud);
            gpbPort.Controls.Add(btnPortOpen);
            gpbPort.Controls.Add(labProt);
            gpbPort.Controls.Add(btnPortClose);
            gpbPort.Controls.Add(cmbBaud);
            gpbPort.Controls.Add(cmbProt);
            gpbPort.Location = new Point(12, 12);
            gpbPort.Name = "gpbPort";
            gpbPort.Size = new Size(485, 232);
            gpbPort.TabIndex = 7;
            gpbPort.TabStop = false;
            // 
            // labTcpState
            // 
            labTcpState.AutoSize = true;
            labTcpState.ForeColor = Color.Red;
            labTcpState.Location = new Point(407, 161);
            labTcpState.Name = "labTcpState";
            labTcpState.Size = new Size(61, 23);
            labTcpState.TabIndex = 20;
            labTcpState.Text = "已断开";
            // 
            // labTcpS
            // 
            labTcpS.AutoSize = true;
            labTcpS.Location = new Point(384, 129);
            labTcpS.Name = "labTcpS";
            labTcpS.Size = new Size(95, 23);
            labTcpS.TabIndex = 19;
            labTcpS.Text = "网络连接：";
            // 
            // btnTcpClose
            // 
            btnTcpClose.Location = new Point(248, 170);
            btnTcpClose.Name = "btnTcpClose";
            btnTcpClose.Size = new Size(94, 29);
            btnTcpClose.TabIndex = 18;
            btnTcpClose.Text = "断开";
            btnTcpClose.UseVisualStyleBackColor = true;
            btnTcpClose.Click += btnTcpClose_Click;
            // 
            // btnTcpOpen
            // 
            btnTcpOpen.Location = new Point(248, 129);
            btnTcpOpen.Name = "btnTcpOpen";
            btnTcpOpen.Size = new Size(94, 29);
            btnTcpOpen.TabIndex = 17;
            btnTcpOpen.Text = "连接";
            btnTcpOpen.UseVisualStyleBackColor = true;
            btnTcpOpen.Click += btnTcpOpen_Click;
            // 
            // txbTcpPort
            // 
            txbTcpPort.Location = new Point(81, 170);
            txbTcpPort.Name = "txbTcpPort";
            txbTcpPort.Size = new Size(151, 29);
            txbTcpPort.TabIndex = 16;
            txbTcpPort.Text = "8080";
            // 
            // labTcpPort
            // 
            labTcpPort.AutoSize = true;
            labTcpPort.Location = new Point(15, 173);
            labTcpPort.Name = "labTcpPort";
            labTcpPort.Size = new Size(48, 23);
            labTcpPort.TabIndex = 15;
            labTcpPort.Text = "端口:";
            // 
            // txbTcpIp
            // 
            txbTcpIp.Location = new Point(81, 129);
            txbTcpIp.Name = "txbTcpIp";
            txbTcpIp.Size = new Size(151, 29);
            txbTcpIp.TabIndex = 14;
            txbTcpIp.Text = "127.0.1";
            // 
            // labTcpIp
            // 
            labTcpIp.AutoSize = true;
            labTcpIp.Location = new Point(0, 132);
            labTcpIp.Name = "labTcpIp";
            labTcpIp.Size = new Size(63, 23);
            labTcpIp.TabIndex = 8;
            labTcpIp.Text = "IP地址:";
            // 
            // labPortS
            // 
            labPortS.AutoSize = true;
            labPortS.Location = new Point(384, 36);
            labPortS.Name = "labPortS";
            labPortS.Size = new Size(95, 23);
            labPortS.TabIndex = 7;
            labPortS.Text = "串口状态：";
            // 
            // panelDeviceStatus
            // 
            panelDeviceStatus.BackColor = Color.Red;
            panelDeviceStatus.Location = new Point(99, 141);
            panelDeviceStatus.Name = "panelDeviceStatus";
            panelDeviceStatus.Size = new Size(71, 29);
            panelDeviceStatus.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnContinueRead);
            groupBox1.Controls.Add(btnStopRead);
            groupBox1.Controls.Add(btnStartRead);
            groupBox1.Controls.Add(txbLen);
            groupBox1.Controls.Add(labLen);
            groupBox1.Controls.Add(txbAddr);
            groupBox1.Controls.Add(txbSlave);
            groupBox1.Controls.Add(labAddr);
            groupBox1.Controls.Add(labSlave);
            groupBox1.Location = new Point(503, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(224, 232);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            // 
            // btnContinueRead
            // 
            btnContinueRead.Location = new Point(125, 155);
            btnContinueRead.Name = "btnContinueRead";
            btnContinueRead.Size = new Size(93, 29);
            btnContinueRead.TabIndex = 14;
            btnContinueRead.Text = "开始监控";
            btnContinueRead.UseVisualStyleBackColor = true;
            btnContinueRead.Click += btnContinueRead_Click;
            // 
            // btnStopRead
            // 
            btnStopRead.Enabled = false;
            btnStopRead.Location = new Point(125, 190);
            btnStopRead.Name = "btnStopRead";
            btnStopRead.Size = new Size(93, 29);
            btnStopRead.TabIndex = 13;
            btnStopRead.Text = "停止监控";
            btnStopRead.UseVisualStyleBackColor = true;
            btnStopRead.Click += btnStopRead_Click;
            // 
            // btnStartRead
            // 
            btnStartRead.Location = new Point(12, 155);
            btnStartRead.Name = "btnStartRead";
            btnStartRead.Size = new Size(93, 29);
            btnStartRead.TabIndex = 8;
            btnStartRead.Text = "读取数据";
            btnStartRead.UseVisualStyleBackColor = true;
            btnStartRead.Click += btnStartRead_Click;
            // 
            // txbLen
            // 
            txbLen.Location = new Point(111, 101);
            txbLen.Name = "txbLen";
            txbLen.Size = new Size(88, 29);
            txbLen.TabIndex = 12;
            txbLen.Text = "10";
            txbLen.TextAlign = HorizontalAlignment.Right;
            // 
            // labLen
            // 
            labLen.AutoSize = true;
            labLen.Location = new Point(10, 103);
            labLen.Name = "labLen";
            labLen.Size = new Size(112, 23);
            labLen.TabIndex = 11;
            labLen.Text = "寄存器长度：";
            // 
            // txbAddr
            // 
            txbAddr.Location = new Point(96, 66);
            txbAddr.Name = "txbAddr";
            txbAddr.Size = new Size(103, 29);
            txbAddr.TabIndex = 10;
            txbAddr.Text = "0";
            txbAddr.TextAlign = HorizontalAlignment.Right;
            // 
            // txbSlave
            // 
            txbSlave.Location = new Point(96, 28);
            txbSlave.Name = "txbSlave";
            txbSlave.Size = new Size(103, 29);
            txbSlave.TabIndex = 9;
            txbSlave.Text = "1";
            txbSlave.TextAlign = HorizontalAlignment.Right;
            // 
            // labAddr
            // 
            labAddr.AutoSize = true;
            labAddr.Location = new Point(10, 66);
            labAddr.Name = "labAddr";
            labAddr.Size = new Size(95, 23);
            labAddr.TabIndex = 2;
            labAddr.Text = "起始地址：";
            // 
            // labSlave
            // 
            labSlave.AutoSize = true;
            labSlave.Location = new Point(9, 31);
            labSlave.Name = "labSlave";
            labSlave.Size = new Size(95, 23);
            labSlave.TabIndex = 0;
            labSlave.Text = "从站地址：";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnQuery);
            groupBox2.Controls.Add(btnUpload);
            groupBox2.Controls.Add(panelDeviceStatus);
            groupBox2.Controls.Add(labDeviceStatus);
            groupBox2.Controls.Add(txbSpeed);
            groupBox2.Controls.Add(labSpeed);
            groupBox2.Controls.Add(txbPressure);
            groupBox2.Controls.Add(labPressure);
            groupBox2.Controls.Add(txbTemp);
            groupBox2.Controls.Add(labTemp);
            groupBox2.Location = new Point(733, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(237, 232);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(122, 190);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(109, 29);
            btnQuery.TabIndex = 15;
            btnQuery.Text = "查询数据";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Visible = false;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(9, 190);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(109, 29);
            btnUpload.TabIndex = 14;
            btnUpload.Text = "上传数据";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // labDeviceStatus
            // 
            labDeviceStatus.AutoSize = true;
            labDeviceStatus.Location = new Point(9, 143);
            labDeviceStatus.Name = "labDeviceStatus";
            labDeviceStatus.Size = new Size(95, 23);
            labDeviceStatus.TabIndex = 14;
            labDeviceStatus.Text = "设备状态：";
            // 
            // txbSpeed
            // 
            txbSpeed.Location = new Point(67, 104);
            txbSpeed.Name = "txbSpeed";
            txbSpeed.ReadOnly = true;
            txbSpeed.Size = new Size(103, 29);
            txbSpeed.TabIndex = 13;
            txbSpeed.TextAlign = HorizontalAlignment.Center;
            // 
            // labSpeed
            // 
            labSpeed.AutoSize = true;
            labSpeed.Location = new Point(9, 107);
            labSpeed.Name = "labSpeed";
            labSpeed.Size = new Size(61, 23);
            labSpeed.TabIndex = 12;
            labSpeed.Text = "转速：";
            // 
            // txbPressure
            // 
            txbPressure.Location = new Point(67, 66);
            txbPressure.Name = "txbPressure";
            txbPressure.ReadOnly = true;
            txbPressure.Size = new Size(103, 29);
            txbPressure.TabIndex = 11;
            txbPressure.TextAlign = HorizontalAlignment.Center;
            // 
            // labPressure
            // 
            labPressure.AutoSize = true;
            labPressure.Location = new Point(9, 69);
            labPressure.Name = "labPressure";
            labPressure.Size = new Size(61, 23);
            labPressure.TabIndex = 10;
            labPressure.Text = "压力：";
            // 
            // txbTemp
            // 
            txbTemp.Location = new Point(67, 28);
            txbTemp.Name = "txbTemp";
            txbTemp.ReadOnly = true;
            txbTemp.Size = new Size(103, 29);
            txbTemp.TabIndex = 9;
            txbTemp.TextAlign = HorizontalAlignment.Center;
            // 
            // labTemp
            // 
            labTemp.AutoSize = true;
            labTemp.Location = new Point(9, 31);
            labTemp.Name = "labTemp";
            labTemp.Size = new Size(61, 23);
            labTemp.TabIndex = 0;
            labTemp.Text = "温度：";
            // 
            // gpbLog
            // 
            gpbLog.Controls.Add(txbLogs);
            gpbLog.Controls.Add(labLog);
            gpbLog.Location = new Point(12, 259);
            gpbLog.Name = "gpbLog";
            gpbLog.Size = new Size(958, 213);
            gpbLog.TabIndex = 8;
            gpbLog.TabStop = false;
            gpbLog.Text = "通讯日志：";
            // 
            // txbLogs
            // 
            txbLogs.Location = new Point(10, 28);
            txbLogs.Multiline = true;
            txbLogs.Name = "txbLogs";
            txbLogs.ReadOnly = true;
            txbLogs.ScrollBars = ScrollBars.Vertical;
            txbLogs.Size = new Size(942, 165);
            txbLogs.TabIndex = 1;
            // 
            // labLog
            // 
            labLog.AutoSize = true;
            labLog.Location = new Point(10, 25);
            labLog.Name = "labLog";
            labLog.Size = new Size(0, 23);
            labLog.TabIndex = 0;
            // 
            // grpHisData
            // 
            grpHisData.Controls.Add(chartdyna);
            grpHisData.Controls.Add(btnClear);
            grpHisData.Controls.Add(dataGridView1);
            grpHisData.Location = new Point(12, 472);
            grpHisData.Name = "grpHisData";
            grpHisData.Size = new Size(958, 246);
            grpHisData.TabIndex = 15;
            grpHisData.TabStop = false;
            // 
            // chartdyna
            // 
            chartArea1.Name = "ChartArea1";
            chartdyna.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartdyna.Legends.Add(legend1);
            chartdyna.Location = new Point(18, 26);
            chartdyna.Name = "chartdyna";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartdyna.Series.Add(series1);
            chartdyna.Size = new Size(430, 205);
            chartdyna.TabIndex = 15;
            chartdyna.Text = "chart1";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(852, 211);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 29);
            btnClear.TabIndex = 14;
            btnClear.Text = "清空数据";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(454, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(498, 179);
            dataGridView1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 730);
            Controls.Add(grpHisData);
            Controls.Add(gpbLog);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(gpbPort);
            Font = new Font("Microsoft YaHei UI", 10F);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "工业数据监控系统";
            Load += Form1_Load;
            gpbPort.ResumeLayout(false);
            gpbPort.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            gpbLog.ResumeLayout(false);
            gpbLog.PerformLayout();
            grpHisData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartdyna).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label labProt;
        private ComboBox cmbProt;
        private Label labBaud;
        private ComboBox cmbBaud;
        private Button btnPortOpen;
        private Button btnPortClose;
        private Label labPortState;
        private GroupBox gpbPort;
        private Panel panelDeviceStatus;
        private GroupBox groupBox1;
        private Label labAddr;
        private Label labSlave;
        private TextBox txbLen;
        private Label labLen;
        private TextBox txbAddr;
        private TextBox txbSlave;
        private Button btnStopRead;
        private Button btnStartRead;
        private GroupBox groupBox2;
        private TextBox txbTemp;
        private Label labTemp;
        private Label labDeviceStatus;
        private TextBox txbSpeed;
        private Label labSpeed;
        private TextBox txbPressure;
        private Label labPressure;
        private GroupBox gpbLog;
        private TextBox txbLogs;
        private Label labLog;
        private GroupBox grpHisData;
        private Button btnClear;
        private DataGridView dataGridView1;
        private Label labPortS;
        private Label labTcpIp;
        private TextBox txbTcpPort;
        private Label labTcpPort;
        private TextBox txbTcpIp;
        private Label labTcpState;
        private Label labTcpS;
        private Button btnTcpClose;
        private Button btnTcpOpen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartdyna;
        private Button btnUpload;
        private Button btnQuery;
        private Button btnContinueRead;
    }
}
