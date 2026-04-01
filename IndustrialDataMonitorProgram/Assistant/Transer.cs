using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IndustrialDataMonitorProgram.Assistant
{
    internal static class Transer
    {
        //十六进制字符串转byte[]
        public static byte[] StringToByteArray(string hex)
        {
            int len = hex.Length / 2;
            byte[] res = new byte[len];
            for(int i = 0; i < len; i++)
            {
                res[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return res;
        }

        /*
        //数组数据格式转换数据库格式
        public static string ArrayToDBString<T>(T[] array)
        {
            if (array == null || array.Length == 0)
                return "";
            string dbs = String.Join("-", array);
            return dbs;
        }

        //数据库格式转数组
        public static int[] DBStringToIntArray(string dbs)
        {
            if (string.IsNullOrWhiteSpace(dbs))
                return new int[0];
            string[] str = dbs.Split("-");
            int[] res = dbs.Split("-").Select(int.Parse).ToArray();
            return res;
        }

        public static double[] DBStringToDoubleArray(string dbs)
        {
            string[] str = dbs.Split("-");
            double[] res = dbs.Split("-").Select(double.Parse).ToArray();
            return res;
        }
        */
    }
}
