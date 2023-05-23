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
    public partial class RepSupBill : Form
    {
        public RepSupBill()
        {
            InitializeComponent();
        }
         private void button1_Click(object sender, EventArgs e)
        {
            Sup_Bill_DataSet m = new Sup_Bill_DataSet();
            String sqlcon = (@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Project\Honda\Honda\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlConnection cn = new SqlConnection(sqlcon);
            String n = dateTimePicker1.Value.ToShortDateString();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Supplier_Bill_Form where [Deb] between '" + dateTimePicker1.Value.ToShortDateString() + "' and '" + dateTimePicker2.Value.ToShortDateString() + "'", sqlcon);
             sqlDa.Fill(m, m.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("DataSet1", m.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh(); 
            this.reportViewer1.RefreshReport(); 
        }

        private void RepSupBill_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Sup_Bill_DataSet.Supplier_Bill_Form' table. You can move, or remove it, as needed.
            this.Supplier_Bill_FormTableAdapter.Fill(this.Sup_Bill_DataSet.Supplier_Bill_Form);

            this.reportViewer1.RefreshReport();
        }
    }
}
