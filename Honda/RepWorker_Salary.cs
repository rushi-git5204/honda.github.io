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
    public partial class RepWorker_Salary : Form
    {
        public RepWorker_Salary()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Worker_Salary_DataSet m = new Worker_Salary_DataSet();
            String sqlcon = (@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Project\Honda\Honda\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlConnection cn = new SqlConnection(sqlcon);
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Worker_Salary where [Salary_Date] between  '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "'", sqlcon);
            sqlDa.Fill(m, m.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("DataSet1", m.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport(); 
        }

        private void RepWorker_Salary_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Worker_Salary_DataSet.Worker_Salary' table. You can move, or remove it, as needed.
            this.Worker_SalaryTableAdapter.Fill(this.Worker_Salary_DataSet.Worker_Salary);

        }
    }
}
