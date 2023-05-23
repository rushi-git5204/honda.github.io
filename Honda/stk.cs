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
    public partial class stk : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Project\Honda\Honda\SqlStock\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        int Model_ID = 0;
        public stk()
        {
            InitializeComponent();
        }

        private void stk_Load(object sender, EventArgs e)
        {
            Reset();
            FillDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                if (button2.Text == "Submit")
                {
                    SqlCommand sqlCmd = new SqlCommand("Edit", sqlcon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Add");
                    sqlCmd.Parameters.AddWithValue("@Model_ID ", 0);
                    sqlCmd.Parameters.AddWithValue("@Model_Type", comboBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model_Name_Color", comboBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Price", textBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Purchase_quantity", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Old_stock", textBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Total_stock", textBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Purchase_Date", dateTimePicker1.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Submint Successfully");
                    Reset();
                    FillDataGridView();
                }
                else
                {
                    SqlCommand sqlCmd = new SqlCommand("Edit", sqlcon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                    sqlCmd.Parameters.AddWithValue("@Model_ID ", Model_ID);
                    sqlCmd.Parameters.AddWithValue("@Model_Type", comboBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model_Name_Color", comboBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Price", textBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Purchase_quantity", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Old_stock", textBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Total_stock", textBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Purchase_Date", dateTimePicker1.Text.Trim());
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("Search", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Model_Type", textBox5.Text.Trim());
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
                Model_ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                button2.Text = "Update";
                button3.Enabled = true;
            }
        }
        void Reset()
        {
            comboBox1.Text = comboBox2.Text = textBox2.Text = textBox1.Text = textBox3.Text = textBox4.Text = dateTimePicker1.Text = "";
            button2.Text = "Submit";
            button3.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("DeleteC", sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Model_ID ", Model_ID);
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

        private void button1_Click(object sender, EventArgs e)
        {
              Reset();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select Distinct Model_Name_Color from Stk where Model_Type='" + comboBox1.Text + "'",sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox2.Items.Clear();
            foreach (DataRow AB in dt.Rows)
            {

                comboBox2.Items.Add(AB["Model_Name_Color"].ToString());
            }
        }

     

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = (@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Project\Honda\Honda\SqlStock\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            string Query = "Select * from [Stk] where Model_Name_Color ='" + comboBox2.Text + "'";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader Reader;
            try
            {
                conDatabase.Open();
                Reader = cmdDatabase.ExecuteReader();
                while (Reader.Read())
                {
                    string Total_stock = Reader.GetInt32(6).ToString();
                    textBox3.Text = Total_stock;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                textBox4.Text = (Convert.ToInt32(textBox3.Text) + Convert.ToInt32(textBox2.Text)).ToString();
            }
            textBox2.Focus();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


    }
}

        

