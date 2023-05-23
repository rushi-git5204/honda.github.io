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
    public partial class Worker_info : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Monika\Honda\Honda\SqlStock\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        int Worker_ID = 0;
        public Worker_info()
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
                    SqlCommand sqlCmd = new SqlCommand("Worker_info_Edit", sqlcon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Add");
                    sqlCmd.Parameters.AddWithValue("@Worker_ID ", 0);
                    sqlCmd.Parameters.AddWithValue("@Worker_Type", comboBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Worker_Name", textBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Address", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Mobile_No", textBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email_Id", textBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Joining_Date", dateTimePicker1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Basic_Salary", textBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Per_Day_Salary", textBox6.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Ref_Name", textBox9.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Ref_Mobile_No", textBox10.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Account_No", textBox7.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Submint Successfully");
                    Reset();
                    FillDataGridView();
                }
                else
                {
                    SqlCommand sqlCmd = new SqlCommand("Worker_info_Edit", sqlcon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                    sqlCmd.Parameters.AddWithValue("@Worker_ID ", Worker_ID);
                    sqlCmd.Parameters.AddWithValue("@Worker_Type", comboBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Worker_Name", textBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Address", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Mobile_No", textBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email_Id", textBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Joining_Date", dateTimePicker1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Basic_Salary", textBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Per_Day_Salary", textBox6.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Ref_Name", textBox9.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Ref_Mobile_No", textBox10.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Account_No", textBox7.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully");
                    Reset();
                    FillDataGridView();
                }
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("Worker_info_Search", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Worker_Type", textBox8.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns[0].Visible = false;
            sqlcon.Close();
        }
        private void Worker_info_Load(object sender, EventArgs e)
        {
            Reset();
            FillDataGridView();
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
                Worker_ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                textBox10.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                button2.Text = "Update";
                button3.Enabled = true;
            }
        }
        void Reset()
        {
            comboBox1.Text = textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = dateTimePicker1.Text = textBox5.Text = textBox6.Text = textBox9.Text = textBox10.Text = textBox7.Text = "";
            button2.Text = "Submit";
            button3.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("Worker_info_Delete", sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Worker_ID ", Worker_ID);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully");
                Reset();
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Massage");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length > 0)
            {
                textBox6.Text = (Convert.ToInt32(textBox5.Text) / 31).ToString();
            }
        }

               
    }
}
