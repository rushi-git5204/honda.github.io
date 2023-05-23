using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Honda
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            button4.Visible = true;
            button3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the Name & Password");
            }
            else
            {
                if (textBox1.Text == "Login" && textBox2.Text == "Login")
                {
                    MessageBox.Show("You are successfully login");

                    Adminhome obj = new Adminhome();
                    obj.Show();
                }
                else
                {
                    MessageBox.Show("Name & Password is incorrect");
                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the Name & Password");
            }
            else
            {
                if (textBox1.Text == "User" && textBox2.Text == "12345")
                {
                    MessageBox.Show("You are successfully login");

                    Userhome obj = new Userhome();
                    obj.Show();
                }
                else
                {
                    MessageBox.Show("Name & Password is incorrect");
                }


            }
        }
    }
}
