using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialDataMonitorProgram.Assistant
{
    internal class IniHelper
    {
        private static string iniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppConfig.ini");

        public static void Write(string section,string key,string value)
        {
            try
            {
                File.WriteAllText(iniPath, File.ReadAllText(iniPath).Replace($"[{section}]\r\n{key}=", $"[{section}]\r\n{key}={value}"));

            }
            catch
            {
                File.AppendAllText(iniPath, $"[{section}]\r\n{key}={value}\r\n");
            }
        }

        public static string Read(string section,string key)
        {
            try
            {
                var lines = File.ReadAllLines(iniPath);
                bool inSection = false;
                foreach(var line in lines)
                {
                    if (line.Trim() == $"[{section}]")
                        inSection = true;
                    else if (line.Trim().StartsWith("[") && inSection)
                        break;
                    else if (inSection && line.Trim().StartsWith(key + "="))
                        return line.Split("=")[1];
                }
            }
            catch { }
            return "";
        }
    }
}
