using IndustrialDataMonitorProgram.Conn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IndustrialDataMonitorProgram
{
    public partial class FormDBQ : Form
    {
        private DataTable dataTable_his;
        public FormDBQ()
        {
            InitializeComponent();
            InitDataTable();
        }

        private void InitDataTable()
        {
            dataTable_his = new DataTable();
            dataTable_his.Columns.Add("产品ID");
            dataTable_his.Columns.Add("时间");
            dataTable_his.Columns.Add("温度");
            dataTable_his.Columns.Add("压力");
            dataTable_his.Columns.Add("转速");
            dataGridView1.DataSource = dataTable_his;
        }

        public void FormDBQ_Load(object sender, EventArgs e)
        {

        }
    }
}
