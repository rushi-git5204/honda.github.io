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
    public partial class Userhome : Form
    { 
        public Userhome()
        {
            InitializeComponent();
        } 

        private void customerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cusinfo frm = new Cusinfo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void customerBillFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_Bill_Form frm = new Customer_Bill_Form();
            frm.MdiParent = this;
            frm.Show();

        }

        private void bookingOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Booking frm = new Booking();
            frm.MdiParent = this;
            frm.Show();
        }

        private void supplierBillFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Supplier_Bill_Form frm = new Supplier_Bill_Form();
            frm.MdiParent = this;
            frm.Show();
        } 

        private void cBShineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CBShine frm = new CBShine();
            frm.MdiParent = this;
            frm.Show();
         }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void xBladeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XBlade frm = new XBlade();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cD110DreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CD110_Dream frm = new CD110_Dream();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cBHornet160rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CBHornet frm = new CBHornet();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cBR250RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CBR_250R frm = new CBR_250R();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cBUnicornToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CB_Unicorn frm = new CB_Unicorn();
            frm.MdiParent = this;
            frm.Show();
        }

        private void sP125ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SP125 frm = new SP125();
            frm.MdiParent = this;
            frm.Show();
        }

        private void livoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Livo frm = new Livo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void activa5GToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activa6G frm = new Activa6G();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dio frm = new Dio();
            frm.MdiParent = this;
            frm.Show();
        }

        private void graziaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grazia frm = new Grazia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void newActiva125ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activa125 frm = new Activa125();
            frm.MdiParent = this;
            frm.Show();
        }

        private void africaTwinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfricaTwin frm = new AfricaTwin();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cB1000RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CB1000R frm = new CB1000R();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cBR650RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CBR650R frm = new CBR650R();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cBR1000RRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CBR1000RR frm = new CBR1000RR();
            frm.MdiParent = this;
            frm.Show();
        }

        private void goldWingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoldWing frm = new GoldWing();
            frm.MdiParent = this;
            frm.Show();
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contacts frm = new Contacts();
            frm.MdiParent = this;
            frm.Show();
        }

      
    }
}
