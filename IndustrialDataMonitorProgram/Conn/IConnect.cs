using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialDataMonitorProgram.Conn
{
    internal interface IConnect
    {
        event Action<string> OnDataReceived;
        bool Open();
        void Close();
        void Send(byte[] data);
        bool IsOpen { get; }

    }
}
