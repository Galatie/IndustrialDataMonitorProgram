using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialDataMonitorProgram.Assistant
{
    internal static class FileLogger
    {
        private static string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        public static void Log(string msg)
        {
            try
            {
                if (!Directory.Exists(logDir))
                    Directory.CreateDirectory(logDir);
                string file = Path.Combine(logDir, $"Log_{DateTime.Now:yyyy-MM-dd}.txt");
                string line = $"[{DateTime.Now:HH:mm:ss} ]{msg}";
                File.AppendAllText(file, line + Environment.NewLine);
            }
            catch { }
        }
    }
}
