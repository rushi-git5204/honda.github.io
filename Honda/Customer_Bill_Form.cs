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
    public partial class Customer_Bill_Form : Form
    {
        double v_Gstamt = 0, v_Price = 0, v_Gst = 0, v_Total_Price = 0, v_Insurance = 0, v_Accessary_Charge = 0;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\PROJECT\Honda\Honda\SqlStock\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        int Customer_Id = 0;
        public Customer_Bill_Form()
        {
            InitializeComponent();
        }
        
        private void Customer_Bill_Form_Load(object sender, EventArgs e)
        {
            Reset();
            FillDataGridView();
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
            comboBox6.Items.Clear();
            foreach (DataRow AB in DT.Rows)
            {

                comboBox6.Items.Add(AB["Address"].ToString());
                Reset();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select Distinct Model_Name_Color from [Stk] where Model_Type='" + comboBox2.Text + "'", sqlcon);
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
            string constring = (@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\PROJECT\Honda\Honda\SqlStock\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
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
                    string Total_stock = Reader.GetInt32(6).ToString();
                    string Price = Reader.GetInt32(3).ToString();
                    textBox1.Text = Total_stock;
                    textBox4.Text = Price;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {              
                 if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                 if (button1.Text == "Make Payment")
                {
                    SqlCommand sqlCmd = new SqlCommand("Cus_Bill_Edit", sqlcon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Add");
                    sqlCmd.Parameters.AddWithValue("@Customer_Id ", 0);
                    sqlCmd.Parameters.AddWithValue("@Customer_Name", comboBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Address", comboBox6.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model_Type", comboBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model_Name_Color", comboBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Engine_No", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Chassis_No", textBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Price", textBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Insurance", textBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@GST", textBox6.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Accessary_Charge", textBox7.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Total_Price", textBox8.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Payment_Method", comboBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Card_No", textBox9.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@CVV", textBox10.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Bill_Date", dateTimePicker1.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Payment Successfully");
                    Reset();
                    FillDataGridView();
                }
                 else
                 {
                     SqlCommand sqlCmd = new SqlCommand("Cus_Bill_Edit", sqlcon);
                     sqlCmd.CommandType = CommandType.StoredProcedure;
                     sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                     sqlCmd.Parameters.AddWithValue("@Customer_Id ", Customer_Id);
                     sqlCmd.Parameters.AddWithValue("@Customer_Name", comboBox1.Text.Trim());
                     sqlCmd.Parameters.AddWithValue("@Address", comboBox6.Text.Trim());
                     sqlCmd.Parameters.AddWithValue("@Model_Type", comboBox2.Text.Trim());
                     sqlCmd.Parameters.AddWithValue("@Model_Name_Color", comboBox3.Text.Trim());
                     sqlCmd.Parameters.AddWithValue("@Engine_No", textBox2.Text.Trim());
                     sqlCmd.Parameters.AddWithValue("@Chassis_No", textBox3.Text.Trim());
                     sqlCmd.Parameters.AddWithValue("@Price", textBox4.Text.Trim());
                     sqlCmd.Parameters.AddWithValue("@Insurance", textBox5.Text.Trim());
                     sqlCmd.Parameters.AddWithValue("@GST", textBox6.Text.Trim());
                     sqlCmd.Parameters.AddWithValue("@Accessary_Charge", textBox7.Text.Trim());
                     sqlCmd.Parameters.AddWithValue("@Total_Price", textBox8.Text.Trim());
                     sqlCmd.Parameters.AddWithValue("@Payment_Method", comboBox5.Text.Trim());
                     sqlCmd.Parameters.AddWithValue("@Card_No", textBox9.Text.Trim());
                     sqlCmd.Parameters.AddWithValue("@CVV", textBox10.Text.Trim());
                     sqlCmd.Parameters.AddWithValue("@Bill_Date", dateTimePicker1.Text.Trim());
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("Cus_Bill_Search", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Customer_Name", comboBox1.Text.Trim());
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
                Customer_Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                comboBox5.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                textBox10.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                button1.Text = "Update";
                button2.Enabled = true;
            }
        }
        void Reset()
        {
            comboBox1.Text = comboBox3.Text = comboBox6.Text = comboBox2.Text = comboBox3.Text = textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = comboBox5.Text = textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = checkBox1.Text = checkBox2.Text = dateTimePicker1.Text = "";
            button1.Text = "Make Payment";
            button3.Enabled = true;

        }
        private void GSTCalc()
        {
            v_Price = double.Parse(textBox4.Text);
            v_Gst = double.Parse(textBox6.Text);
            if (checkBox1.Checked == true)
            {
                v_Gstamt = (v_Price * v_Gst) / 100;
            }
            textBox12.Text = v_Gstamt.ToString();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            GSTCalc();
            if (textBox1.Text.Length > 0)
            {
                textBox11.Text = (Convert.ToInt32(textBox1.Text) - 1).ToString();
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
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
                SqlCommand sqlCmd = new SqlCommand("Cus_Bill_Delete", sqlcon);
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
        private void Calculat()
        {
            v_Price = double.Parse(textBox4.Text);
            v_Gstamt = double.Parse(textBox12.Text);
            v_Insurance = double.Parse(textBox5.Text);
            v_Accessary_Charge = double.Parse(textBox7.Text);

            if (checkBox2.Checked == true)
            {
                v_Total_Price = (v_Price + v_Gstamt + v_Insurance + v_Accessary_Charge);
            }
            textBox8.Text = v_Total_Price.ToString();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text=="")
            {
            }
            else
            {
                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update[Stk]set Total_stock ='"+textBox11.Text+"'where Model_Name_Color='"+comboBox3.Text+"'";
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("Calculat");
            }
                  Calculat();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
