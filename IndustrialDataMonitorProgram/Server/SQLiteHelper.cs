using IndustrialDataMonitorProgram.Assistant;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace IndustrialDataMonitorProgram.Server
{
    public class SQLiteHelper
    {
        private static string connStr = @"Data Source=MonitorData.db;Version=3";

        //数据库连接初始化
        public static void InitDatabase()
        {
            using(SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = @"
                CREATE TABLE IF NO EXISITS DeviceData（
                ProductId INTEGER PRIMAY KEY NULL,
                CreateTime TEXT NOT NULL,
                Temperatures REAL NOT NULL,
                Pressures REAL NOT NULL
                Speeds INTEGER NOT NULL
                )";

                string sql_id = @"
                Create TABLE IF NOT EXISTS ProductSeq(
                Date TEXT PRIMARY KEY,
                Seq INTERGER NOT NULL DEFAULT 0
                )";
                using (SQLiteCommand cmd = new SQLiteCommand(sql,conn))
                {
                    cmd.ExecuteNonQuery();
                }
                
            }
        }

        //插入数据
        public static void DataBaseInserData(string pid,double temp, double press, int speed)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = @"INSERT INTO DeviceData(ProductId,CreateTime,Temperatures,Pressures,Speeds)
                VALUES(@pid,@time,@temp,@press,@speed)";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", pid);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@temp", temp);
                    cmd.Parameters.AddWithValue("@press", press);
                    cmd.Parameters.AddWithValue("@speed", speed);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //删除数据
        public static void DataBaseDeleteByPId(string pid)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = @"DELETE FROM DeviceData WHERE ProductId = @pid";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", pid);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DataBaseUpdateByPId(string pid,double temp,double press,int speed)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = @"UPDATE DeviceData 
                            SET Temperatures = @temp,Pressure = @press,Speed = @speed
                            WHERE ProductId = @pid";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", pid);
                    cmd.Parameters.AddWithValue("@temp", temp);
                    cmd.Parameters.AddWithValue("@press", press);
                    cmd.Parameters.AddWithValue("@speed", speed);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //查询数据
        public static DataTable DataBaseSelectByPId(string pid ,int count = 1)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql;
                if (count == 1)
                {
                    sql = @"SELECT * FROM DeviceData
                              WHEN PId = @pid";
                }
                else
                {
                    sql = @"SELECT * FROM DeviceData
                              WHEN PId = @pid
                              LIMIT @count";
                }
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", pid);
                    if (count != 1)
                        cmd.Parameters.AddWithValue("@count", count);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        public static string GetNextProductId()
        {
            string today = DateTime.Now.ToString("yyyymmdd");
            using (SQLiteConnection conn = new SQLiteConnection())
            {
                conn.Open();
                using(SQLiteTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlSelect = @"Select Seq FROM ProductSeq WHEN Date = @date";
                        int seq = 0;

                        using (SQLiteCommand cmd = new SQLiteCommand(sqlSelect, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@date", today);
                            var res = cmd.ExecuteScalar();
                            if(res!=null)
                                seq = int.Parse(res.ToString()) ;
                        }
                        seq++;

                        string sqlUpsert = @"
                        INSERT OR REPLACE INTO ProductSeq(Date,Seq)
                        VALUES(@date,@seq)";

                        using(SQLiteCommand cmd = new SQLiteCommand( sqlUpsert, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@date", today);
                            cmd.Parameters.AddWithValue("@seq", seq);
                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();

                        return $"PROD_{today}_{seq:D5}";
                    }
                    catch
                    {
                        tran.Rollback();
                        return "ERROR_ID";
                    }
                }
                
            }
        }

        
    }
}
