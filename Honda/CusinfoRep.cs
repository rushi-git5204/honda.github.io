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
    public partial class CusinfoRep : Form
    {
        public CusinfoRep()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Project\Honda\Honda\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select * from Customerinfo", sqlcon);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDa.Fill(dt);

            ReportDataSource rds = new ReportDataSource("CusInfoDataSet1", dt);
            reportViewer1.LocalReport.ReportPath = @"E:\Project\Honda\Honda\CusinfoReport1.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void CusinfoRep_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
