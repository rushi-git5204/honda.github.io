using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Honda
{
    public partial class Supplier_Info : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Monika\Honda\Honda\SqlStock\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        int Supplier_Id = 0;
        public Supplier_Info()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                if (button2.Text == "Submit")
                {
                    SqlCommand sqlCmd = new SqlCommand("Supplier_Info_Edit", sqlcon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Add");
                    sqlCmd.Parameters.AddWithValue("@Supplier_Id", 0);
                    sqlCmd.Parameters.AddWithValue("@Supplier_Name", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Address", textBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Pin_code", textBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Mob_No", textBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email_Id", textBox6.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Deb", dateTimePicker1.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Submint Successfully");
                }
                else
                {
                    SqlCommand sqlCmd = new SqlCommand("Supplier_Info_Edit", sqlcon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                    sqlCmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id);
                    sqlCmd.Parameters.AddWithValue("@Supplier_Name", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Address", textBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Pin_code", textBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Mob_No", textBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email_Id", textBox6.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Deb", dateTimePicker1.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully");
                }
                Reset();
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Massage");
            }
            finally
            {
                sqlcon.Close();
            }
        
        }
        void FillDataGridView()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Supplier_Info_Search", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Supplier_Name", textBox8.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns[0].Visible = false;
            sqlcon.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Massage");
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                Supplier_Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                button2.Text = "Update";
                button3.Enabled = true;
            }
        }
        void Reset()
        {
            textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = dateTimePicker1.Text = "";
            button2.Text = "Submit";
            button3.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Supplier_Info_Load(object sender, EventArgs e)
        {
            Reset();
            FillDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("Supplier_Info_Delete", sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                Reset();
                FillDataGridView();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Massage");
            }
        }
    }
}
