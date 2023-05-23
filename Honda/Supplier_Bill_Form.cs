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
   
    public partial class Supplier_Bill_Form : Form
    {
        double v_Price = 0, v_Quantity = 0, v_Total_Price = 0;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Monika\Honda\Honda\SqlStock\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        int Supplier_Id = 0;
        public Supplier_Bill_Form()
        {
            InitializeComponent();
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
            string constring = (@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Monika\Honda\Honda\SqlStock\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
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
                    string Total_stock = Reader.GetInt32(6).ToString();
                    textBox2.Text = Price;
                    textBox7.Text = Total_stock;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Calculat()
        {
            v_Price = double.Parse(textBox2.Text);
            v_Quantity = double.Parse(textBox3.Text);
            if (checkBox1.Checked == true)
            {
                v_Total_Price = (v_Price * v_Quantity);
            }

           
            textBox4.Text = v_Total_Price.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
            }
            else 
            {
                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update[Stk]set Total_stock ='" + textBox11.Text + "'where Model_Name_Color='" + comboBox3.Text + "'";
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("Calculat");
            }
            Calculat();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                if (button1.Text == "Submit")
                {
                    SqlCommand sqlCmd = new SqlCommand("Supplier_Bill_Form_Edit", sqlcon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Add");
                    sqlCmd.Parameters.AddWithValue("@Supplier_Id ", 0);
                    sqlCmd.Parameters.AddWithValue("@Supplier_Name", comboBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Address", comboBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Mob_No", textBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model_Type", comboBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model_Name_Color", comboBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Price", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Quantity", textBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Total_Price", textBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Payment_Method", comboBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Card_No", textBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@CVV", textBox6.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Deb", dateTimePicker1.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Submit Successfully");
                    Reset();
                    FillDataGridView();
                }
                else
                {
                    SqlCommand sqlCmd = new SqlCommand("Supplier_Bill_Form_Edit", sqlcon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@mode", "Edit");
                    sqlCmd.Parameters.AddWithValue("@Supplier_Id ", Supplier_Id);
                    sqlCmd.Parameters.AddWithValue("@Supplier_Name", comboBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Address", comboBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Mob_No", textBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model_Type", comboBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Model_Name_Color", comboBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Price", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Quantity", textBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Total_Price", textBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Payment_Method", comboBox4.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Card_No", textBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@CVV", textBox6.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Deb", dateTimePicker1.Text.Trim());
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("Supplier_Bill_Form_Search", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Supplier_Name", comboBox1.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns[0].Visible = false;
            sqlcon.Close();
        }
        void Reset()
        {
            comboBox1.Text = comboBox5.Text = textBox1.Text = comboBox2.Text = comboBox3.Text = textBox2.Text = textBox3.Text = textBox4.Text = comboBox4.Text = textBox5.Text = textBox6.Text = dateTimePicker1.Text = "";
            button1.Text = "Submit";
            button3.Enabled = true;

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                Supplier_Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("Supplier_Bill_Form_Delete", sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Supplier_Id ", Supplier_Id);
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

        private void Supplier_Bill_Form_Load(object sender, EventArgs e)
        {
            Reset();
            FillDataGridView();
            SqlDataAdapter SDA = new SqlDataAdapter("Select Distinct Supplier_Name from Supplier_Info", sqlcon);
            DataTable DT = new DataTable();
            SDA.Fill(DT);
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Select");
            foreach (DataRow Row in DT.Rows)
            {
                comboBox1.Items.Add(Row["Supplier_Name"].ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select Distinct Address from Supplier_Info where Supplier_Name='" + comboBox1.Text + "'", sqlcon);
            DataTable DT = new DataTable();
            sda.Fill(DT);
            comboBox5.Items.Clear();
            foreach (DataRow AB in DT.Rows)
            {

                comboBox5.Items.Add(AB["Address"].ToString());
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = (@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\Monika\Honda\Honda\SqlStock\AllData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            string Query = "Select * from [Supplier_Info] where Address ='" + comboBox5.Text + "'";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader Reader;
            try
            {
                conDatabase.Open();
                Reader = cmdDatabase.ExecuteReader();
                while (Reader.Read())
                {
                    string Mob_No = Reader.GetValue(4).ToString();
                    textBox1.Text = Mob_No;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
            {
                textBox11.Text = (Convert.ToInt32(textBox7.Text) - Convert.ToInt32(textBox3.Text)).ToString();
            }
        }


        }
}
