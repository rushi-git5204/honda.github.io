using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Honda
{
    public partial class Adminhome : Form
    {

        public Adminhome()
        {
            InitializeComponent();
        }

        private void supplierInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Supplier_Info frm = new Supplier_Info ();
            frm.MdiParent = this;
            frm.Show();

        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.MdiParent = this;
            frm.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stk frm = new stk();
            frm.MdiParent = this;
            frm.Show();
        }

        private void stockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Stock frm = new Stock();
            frm.MdiParent = this;
            frm.Show();
        }

        private void customerInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RepCusInfo frm = new RepCusInfo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void customerBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepCusBill frm = new RepCusBill();
            frm.MdiParent = this;
            frm.Show();
        }

        private void supplierBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepSupBill frm = new RepSupBill();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RepSupInfo frm = new RepSupInfo();
            frm.MdiParent = this;
            frm.Show();

        }

        private void customerBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepBooking frm = new RepBooking();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RepWorker_info frm = new RepWorker_info();
            frm.MdiParent = this;
            frm.Show();
        }

        private void workerSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepWorker_Salary frm = new RepWorker_Salary();
            frm.MdiParent = this;
            frm.Show();
        }

        private void Adminhome_Load(object sender, EventArgs e)
        {

        }

        private void workerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Worker_info frm = new Worker_info();
            frm.MdiParent = this;
            frm.Show();
        }

        private void workerSalaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Worker_Salary frm = new Worker_Salary();
            frm.MdiParent = this;
            frm.Show();
        }

    }
}
