using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Net.Sockets;
using System.Text;

namespace IndustrialDataMonitorProgram.Conn
{
    internal class TcpConHelper:IConnect
    {
        private TcpClient _tcpClient;
        private NetworkStream _stream;
        private string _ip;
        private int _netPort;
        public event Action<string> OnDataReceived;

        private bool isOpen => _tcpClient?.Connected ?? false;
        public bool IsOpen
        {
            get { return isOpen; }
        }

        public TcpConHelper(string ip, int netPort)
        {
            _ip = ip;
            _netPort = netPort;
        }

        public bool Open()
        {
            try
            {
                _tcpClient = new TcpClient();
                _tcpClient.Connect(_ip, _netPort);
                _stream = _tcpClient.GetStream();
                StartReceive();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Close()
        {
            _stream?.Close();
            _tcpClient?.Close();
        }

        public void Send(byte[] data)
        {
            if (isOpen)
            {
                _stream.Write(data, 0, data.Length);
            }
        }

        private async void StartReceive()
        {
            byte[] buffer = new byte[1024];
            while (isOpen)
            {
                try
                {
                    int len = await _stream.ReadAsync(buffer, 0, buffer.Length);
                    if (len == 0)
                        break;
                    string hex = BitConverter.ToString(buffer, 0, len);
                    OnDataReceived?.Invoke(hex);
                }
                catch
                {
                    break;
                }
            }
        }
    }
}
