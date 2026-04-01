
using IndustrialDataMonitorProgram.Conn;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace IndustrialDataMonitorProgram.Port
{
    internal class SerialPortHelper : IConnect
    {
        private SerialPort _serialPort = new SerialPort();
        public event Action<string> OnDataReceived;
        public delegate void DataReceivedHandler(string data);


        private bool isOpen => _serialPort.IsOpen;
        public bool IsOpen
        {
            get { return isOpen; }
        }

        public SerialPortHelper(string portName, int baudRate, int dataBits, StopBits stopBits, Parity parity)
        {
            _serialPort.PortName = portName;
            _serialPort.BaudRate = baudRate;
            _serialPort.DataBits = dataBits;
            _serialPort.StopBits = stopBits;
            _serialPort.Parity = parity;
        }
        // 打开串口
        public bool Open()
        {
            try
            {
                _serialPort.Open();
                _serialPort.DataReceived += SerialPort_DataReceived;
                return true;
            }
            catch
            {
                return false;
            }
        }

        // 关闭串口
        public void Close()
        {
            if (isOpen)
            {
                _serialPort.Close();
                _serialPort.DataReceived -= SerialPort_DataReceived;
                
            }
        }

        // 接收数据
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int count = _serialPort.BytesToRead;
            byte[] buffer = new byte[count];
            _serialPort.Read(buffer, 0, count);
            string hex = BitConverter.ToString(buffer);
            OnDataReceived?.Invoke(hex);
        }

        // 发送数据
        public void Send(byte[] data)
        {
            if (_serialPort.IsOpen)
                _serialPort.Write(data, 0, data.Length);
        }

        // 读取电脑所有可用串口
        public static string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }

        public ValueTuple<bool,string,int> GetPortState()
        {
            return new(_serialPort.IsOpen, _serialPort.PortName, _serialPort.BaudRate);

        }
    }
}
  