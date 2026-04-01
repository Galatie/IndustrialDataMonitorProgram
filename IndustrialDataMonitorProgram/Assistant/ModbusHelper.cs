using IndustrialDataMonitorProgram.Conn;
using System;
using System.Linq;

namespace IndustrialDataMonitorProgram.Assistant
{
    public static class ModbusHelper
    {
        /// <summary>
        /// 生成 Modbus RTU 03 功能码（读取保持寄存器）
        /// </summary>
        public static byte[] CreateReadHoldingRegisters(byte slaveId, ushort startAddr, ushort length)
        {
            byte[] frame = new byte[8];
            frame[0] = slaveId;
            frame[1] = 0x03;
            frame[2] = (byte)(startAddr >> 8);
            frame[3] = (byte)(startAddr & 0xFF);
            frame[4] = (byte)(length >> 8);
            frame[5] = (byte)(length & 0xFF);

            ushort crc = CalcCRC(frame, 6);
            frame[6] = (byte)(crc & 0xFF);
            frame[7] = (byte)(crc >> 8);

            return frame;
        }

        /// <summary>
        /// 生成 Modbus RTU 01 功能码（读取线圈）
        /// </summary>
        public static byte[] CreateReadCoils(byte slaveId, ushort startAddr, ushort length)
        {
            byte[] frame = new byte[8];
            frame[0] = slaveId;
            frame[1] = 0x01;
            frame[2] = (byte)(startAddr >> 8);
            frame[3] = (byte)(startAddr & 0xFF);
            frame[4] = (byte)(length >> 8);
            frame[5] = (byte)(length & 0xFF);

            ushort crc = CalcCRC(frame, 6);
            frame[6] = (byte)(crc & 0xFF);
            frame[7] = (byte)(crc >> 8);

            return frame;
        }

        /// <summary>
        /// CRC16 校验（Modbus 标准）
        /// </summary>
        private static ushort CalcCRC(byte[] data, int length)
        {
            ushort crc = 0xFFFF;
            for (int i = 0; i < length; i++)
            {
                crc ^= data[i];
                for (int j = 0; j < 8; j++)
                {
                    bool lsb = (crc & 1) != 0;
                    crc >>= 1;
                    if (lsb) crc ^= 0xA001;
                }
            }
            return crc;
        }

        /// <summary>
        /// 解析 03 功能码返回数据，转为 int 数组
        /// </summary>
        public static int[] ParseHoldingRegisters(byte[] response)
        {
            if (response == null || response.Length < 5) return Array.Empty<int>();
            int byteCount = response[2];
            int[] values = new int[byteCount / 2];

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = (response[3 + i * 2] << 8) | response[4 + i * 2];
            }
            return values;
        }
    }
}
