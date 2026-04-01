using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IndustrialDataMonitorProgram.Server
{
    public  class ServerHelper
    {
        private static readonly ServerHelper instance = new ServerHelper();
        private ServerHelper() { }

        public static ServerHelper Instance()
        {
            return instance;
        }

        public string DatabaseInsert(double temp, double pressure, int speed)
        {
            string pid = SQLiteHelper.GetNextProductId();
            if(pid == "ERROR_ID")
            {
                MessageBox.Show("产品编号获取失败，无法保存数据！");
                return pid;
            }
            SQLiteHelper.DataBaseInserData(pid, temp, pressure, speed);
            return pid;
        }

        public DataTable DataBaseSelect(string pid,int num = 1)
        {
            DataTable dt = new DataTable();
            dt = SQLiteHelper.DataBaseSelectByPId(pid,num);
            return dt;
        }

    }
}
