using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace Honda
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Stock_DataSet.Stk' table. You can move, or remove it, as needed.
            this.StkTableAdapter.Fill(this.Stock_DataSet.Stk);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Worker_Salary_DataSet m = new Worker_Salary_DataSet();
            String sqlcon = (@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Project\Honda\Honda\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlConnection cn = new SqlConnection(sqlcon);
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Stk where [Purchase_Date] between  '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "'", sqlcon);
            sqlDa.Fill(m, m.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("DataSet1", m.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
