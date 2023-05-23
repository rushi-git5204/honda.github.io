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
    public partial class RepCusBill : Form
    {
        public RepCusBill()
        {
            InitializeComponent();
        }
           private void button1_Click(object sender, EventArgs e)
        {
            Cus_Bill_DataSet m = new Cus_Bill_DataSet();
            String sqlcon = (@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Project\Honda\Honda\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlConnection cn = new SqlConnection(sqlcon);
            String n = dateTimePicker1.Value.ToShortDateString();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Cus_Bill where [Bill_Date] between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "'", sqlcon);
            sqlDa.Fill(m, m.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("DataSet1", m.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport(); 
        }

           private void RepCusBill_Load(object sender, EventArgs e)
           {
               // TODO: This line of code loads data into the 'Cus_Bill_DataSet.Cus_Bill' table. You can move, or remove it, as needed.
               this.Cus_BillTableAdapter.Fill(this.Cus_Bill_DataSet.Cus_Bill);

           }
    }
}
