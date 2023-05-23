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
    public partial class Booking : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Project\Honda\Honda\SqlStock\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        int Customer_Id = 0;
        public Booking()
        {
            InitializeComponent();
        }

        private void Booking_Load(object sender, EventArgs e)
        {

            SqlDataAdapter SDA = new SqlDataAdapter("Select Distinct Customer_Name from CustomerInfo", sqlcon);
            DataTable DT = new DataTable();
            SDA.Fill(DT);
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Select");
            foreach (DataRow Row in DT.Rows)
            {
                comboBox1.Items.Add(Row["Customer_Name"].ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select Distinct Address from CustomerInfo where Customer_Name='" + comboBox1.Text + "'", sqlcon);
            DataTable DT = new DataTable();
            sda.Fill(DT);
            comboBox5.Items.Clear();
            foreach (DataRow AB in DT.Rows)
            {

                comboBox5.Items.Add(AB["Address"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                if (button1.Text == "Submit")
                {
                    SqlCommand sqlCmd = new SqlCommand("Booking_Edit", sqlcon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Add");
                    sqlCmd.Parameters.AddWithValue("@Customer_Id ", 0);
                    sqlCmd.Parameters.AddWithValue("@Customer_Name", comboBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Address", comboBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Mob_No", textBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model_Type", comboBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model_Name_Color", comboBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Price", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model_No", textBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Addvance", textBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Payment_Method", comboBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Card_No", textBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@CVV", textBox6.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Booking_Date", dateTimePicker1.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Submit Successfully");
                    Reset();
                    FillDataGridView();
                }
                else
                {
                    SqlCommand sqlCmd = new SqlCommand("Booking_Edit", sqlcon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                    sqlCmd.Parameters.AddWithValue("@Customer_Id ", Customer_Id);
                    sqlCmd.Parameters.AddWithValue("@Customer_Name", comboBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Address", comboBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Mob_No", textBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model_Type", comboBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model_Name_Color", comboBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Price", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model_No", textBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Addvance", textBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Payment_Method", comboBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Card_No", textBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@CVV", textBox6.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Booking_Date", dateTimePicker1.Text.Trim());
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("Booking_Search", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Customer_Name", comboBox1.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns[0].Visible = false;
            sqlcon.Close();
        }
        void Reset()
        {
            comboBox1.Text = comboBox5.Text = textBox1.Text = comboBox2.Text = comboBox3.Text = textBox2.Text = textBox3.Text = textBox4.Text = comboBox4.Text = textBox5.Text = textBox6.Text = dateTimePicker1.Text = "";
            button1.Text = "Make Payment";
            button3.Enabled = true;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlDataAdapter sda = new SqlDataAdapter("Select Distinct Model_Name_Color from Stk where Model_Type ='" + comboBox2.Text + "'", sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox3.Items.Clear();
            foreach (DataRow AB in dt.Rows)
            {

                comboBox3.Items.Add(AB["Model_Name_Color"].ToString());
            } 
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = (@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Project\Honda\Honda\SqlStock\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            string Query = "Select * from [Stk] where Model_Name_Color ='" + comboBox3.Text + "'";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader Reader;
            try
            {
                conDatabase.Open();
                Reader = cmdDatabase.ExecuteReader();
                while (Reader.Read())
                {
                    string Price = Reader.GetInt32(3).ToString();
                    textBox2.Text = Price;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("Booking_Delete", sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Customer_Id ", Customer_Id);
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

        private void button3_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                Customer_Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                comboBox4.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                button1.Text = "Update";
                button2.Enabled = true;
            }
        } 
    }
}
