using IndustrialDataMonitorProgram.Assistant;
using IndustrialDataMonitorProgram.Conn;
using IndustrialDataMonitorProgram.Port;
using IndustrialDataMonitorProgram.Server;
using System.Data;
using System.IO.Ports;

namespace IndustrialDataMonitorProgram
{
    public partial class MainForm : Form
    {
        private DataTable dataTable_his;
        private IConnect iconHepler;
        private ConnManager connManager;

        private bool isBusy = false;
        ProductInfoStruct productInfo;
        System.Threading.Timer readTimer;

        public MainForm()
        {

            InitializeComponent();
            
            InitDataTable();
            InitChart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitConfigData();
        }

        //串口显示初始化
        private void InitConfigData()
        {
            string[] ports = SerialPortHelper.GetPortNames();
            cmbProt.Items.AddRange(ports);
            if (ports.Length > 0) cmbProt.SelectedIndex = 0;

            string[] baud = IniHelper.Read("Serial","Baud").Split(",");
            cmbBaud.Items.AddRange(baud);
            cmbBaud.SelectedIndex = 0;
        }

        //初始化历史表格
        private void InitDataTable()
        {
            dataTable_his = new DataTable();
            dataTable_his.Columns.Add("时间");
            dataTable_his.Columns.Add("温度");
            dataTable_his.Columns.Add("压力");
            dataTable_his.Columns.Add("转速");
            dataGridView1.DataSource = dataTable_his;
        }

        //初始化曲线
        private void InitChart()
        {
            chartdyna.Series.Clear();

            chartdyna.Series.Add("温度");
            chartdyna.Series["温度"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartdyna.Series["温度"].Color = System.Drawing.Color.Red;

            chartdyna.Series.Add("压力");
            chartdyna.Series["压力"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartdyna.Series["压力"].Color = System.Drawing.Color.Blue;

        }


        //输出日志
        private void AppendLog(string msg)
        {
            if (txbLogs.InvokeRequired)
            {
                txbLogs.Invoke(new Action(() => AppendLog(msg)));
                return;
            }
            txbLogs.AppendText($"{DateTime.Now:HH:mm:ss} {msg}\r\n");
            FileLogger.Log(msg);
            txbLogs.ScrollToCaret();
        }


        //打开串口
        private void btnPortOpen_Click(object sender, EventArgs e)
        {
            if (iconHepler != null && iconHepler.IsOpen)
            {
                MessageBox.Show("请先关闭当前连接");
                return;
            }
            try
            {
                iconHepler = new SerialPortHelper(cmbProt.Text, int.Parse(cmbBaud.Text), 8, StopBits.One, Parity.None);
                connManager = new ConnManager(iconHepler);
                if (iconHepler.Open())
                {
                    iconHepler.OnDataReceived += data => AppendLog("接收：" + data);
                    labPortState.Text = "已打开";
                    labPortState.ForeColor = System.Drawing.Color.Green;
                }
                else
                    MessageBox.Show("打开失败");
            }
            catch
            {
                MessageBox.Show("打开失败");
            }
        }

        //关闭串口
        private void btnPortClose_Click_1(object sender, EventArgs e)
        {
            if (!iconHepler.IsOpen)
                return;
            iconHepler.Close();
            labPortState.Text = "已关闭";
            labPortState.ForeColor = System.Drawing.Color.Red;
        }

        //
        private void btnStartRead_Click(object sender, EventArgs e)
        {
            SendDataAsync();
        }


        private async void SendDataAsync()
        {
            if (iconHepler == null || !iconHepler.IsOpen)
            {
                MessageBox.Show("请先打开串口");
                return;
            }

            try
            {
                isBusy = true;
                await Task.Run(() =>
                {
                    byte slave = byte.Parse(txbSlave.Text);
                    ushort addr = ushort.Parse(txbAddr.Text);
                    ushort len = ushort.Parse(txbLen.Text);

                    byte[] cmd = ModbusHelper.CreateReadHoldingRegisters(slave, addr, len);
                    connManager.SendCommand(
                        cmd,
                        onSuccess: (response) =>
                        {
                            string hex = BitConverter.ToString(response);
                            AppendLog("接收：" + hex);
                            ParseAndUpdateUI(hex);
                            connManager.CompleteAndClose();
                        },
                        onFail: () =>
                        {
                            panelDeviceStatus.BackColor = System.Drawing.Color.Red;
                        }
                        );
                    AppendLog($"发送：{BitConverter.ToString(cmd)}");
                    iconHepler.OnDataReceived += data =>
                    {
                        byte[] resp = Transer.StringToByteArray(data.Replace("-", ""));
                        //判断接收的数据是否为正确的
                        if (false) return;
                        connManager?.OnResponseReceived(resp);
                    };
                });
            }
            catch
            {
                this.Invoke(() => panelDeviceStatus.BackColor = Color.Red);
            }
            finally
            {
                isBusy = false;
            }
            
        }

        //停止监控
        private void btnStopRead_Click(object sender, EventArgs e)
        {
            if (readTimer != null)
                readTimer.Dispose();
            btnContinueRead.Enabled = true;
            btnStopRead.Enabled = false;
        }

        //打开tcp连接
        private void btnTcpOpen_Click(object sender, EventArgs e)
        {
            if (iconHepler != null && iconHepler.IsOpen)
            {
                MessageBox.Show("请先关闭当前连接");
                return;
            }
            try
            {
                string ip = txbTcpIp.Text;
                int port = int.Parse(txbTcpPort.Text);
                iconHepler = new TcpConHelper(ip, port);
                connManager = new ConnManager(iconHepler);
                if (iconHepler.Open())
                {
                    iconHepler.OnDataReceived += data =>
                    {
                        AppendLog("接收：" + data);
                    };
                    labTcpState.Text = "已连接";
                    labTcpState.ForeColor = System.Drawing.Color.Green;
                }
                else
                    MessageBox.Show("连接失败！");
            }
            catch
            {
                MessageBox.Show("连接失败！");
            }
        }

        //关闭tcp连接
        private void btnTcpClose_Click(object sender, EventArgs e)
        {
            if (!iconHepler.IsOpen)
                return;
            iconHepler?.Close();
            labTcpState.Text = "已断开";
            labTcpState.ForeColor = System.Drawing.Color.Red;
        }

        //更新UI
        private void ParseAndUpdateUI(string hexData)
        {
            try
            {
                byte[] response = Transer.StringToByteArray(hexData.Replace("-", ""));
                int[] values = ModbusHelper.ParseHoldingRegisters(response);

                if (values.Length >= 3)
                {
                    double temp = values[0] * 0.1;
                    double press = values[1] * 0.01;
                    int speed = values[2];
                    txbTemp.Text = temp.ToString("0.0");
                    txbPressure.Text = press.ToString("0.00");
                    txbSpeed.Text = speed.ToString();
                    productInfo = new ProductInfoStruct("", temp, press, speed);

                    panelDeviceStatus.BackColor = System.Drawing.Color.Green;
                    UpdateChartAndHistory(temp, press, speed);
                }
            }
            catch
            {
                panelDeviceStatus.BackColor = System.Drawing.Color.Red;
            }
        }

        private void UpdateChartAndHistory(double temp, double press, int speed)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateChartAndHistory(temp, press, speed)));
            }
            chartdyna.Series["温度"].Points.AddY(temp);
            chartdyna.Series["压力"].Points.AddY((press));

            dataTable_his.Rows.Add(
                DateTime.Now.ToString("HH:mm:ss"),
                temp.ToString("0.0"),
                press.ToString("0.00"),
                speed
                );

            if (dataTable_his.Rows.Count > 20)
                dataTable_his.Rows.RemoveAt(0);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataTable_his.Clear();
            chartdyna.Series.Clear();
        }

        //上传数据
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (productInfo.p_id == null)
                {
                    MessageBox.Show("上传失败");
                    return;
                }
                ServerHelper.Instance().DatabaseInsert(productInfo.p_temp, productInfo.p_pressure, productInfo.p_speed);
                MessageBox.Show("上传成功");
            }
            catch
            {
                MessageBox.Show("上传失败");
            }
        }

        //持续监控
        private void btnContinueRead_Click(object sender, EventArgs e)
        {
            try
            {
                readTimer = new System.Threading.Timer((obj) =>
                {
                    SendDataAsync();
                },null,5000,-1);

                btnContinueRead.Enabled = false;
                btnStopRead.Enabled = true;
            }
            catch
            {
                MessageBox.Show("监控失败");
            }
        }
    }
}
