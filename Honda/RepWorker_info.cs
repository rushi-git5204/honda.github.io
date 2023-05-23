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
    public partial class RepWorker_info : Form
    {
        public RepWorker_info()
        {
            InitializeComponent();
        }

        private void RepWorker_info_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Worker_info_DataSet1.Worker_info' table. You can move, or remove it, as needed.
            this.Worker_infoTableAdapter.Fill(this.Worker_info_DataSet1.Worker_info);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Sup_Bill_DataSet m = new Sup_Bill_DataSet();
            String sqlcon = (@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Project\Honda\Honda\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlConnection cn = new SqlConnection(sqlcon);
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Worker_info ", sqlcon);
            sqlDa.Fill(m, m.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("DataSet1", m.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport(); 
        }
 
    }
}
