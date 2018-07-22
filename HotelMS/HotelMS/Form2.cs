using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelMS
{
    public partial class Form2 : Form
    {
        conn conn = new conn();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {            
            this.WindowState = FormWindowState.Maximized;
            comboBox1.Items.Clear();
            try
            {
                conn.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("select reservid from roomdetails where status='Online'", conn.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    comboBox1.Items.Add(dr["reservid"].ToString());

                }
                conn.sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally {
                conn.sqlConnection1.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            from2 f2 = new from2();
            f2.ShowDialog();
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("insert into checkin(reservid,checkindate,noadults,nochilds,noinfants,totalmembers,lastname,firstname,address,country,city,gender,dob,phone,checkinstatus)values(@reservid,@checkindate,@noadults,@nochilds,@noinfants,@totalmembers,@lastname,@firstname,@address,@country,@city,@gender,@dob,@phone,@checkinstatus) ", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@reservid", comboBox1.Text);
                cmd.Parameters.AddWithValue("@checkindate", textBox1.Text);
                cmd.Parameters.AddWithValue("@noadults", textBox3.Text);
                cmd.Parameters.AddWithValue("@nochilds", textBox4.Text);
                cmd.Parameters.AddWithValue("@noinfants", textBox5.Text);
                cmd.Parameters.AddWithValue("@totalmembers", textBox6.Text);
                cmd.Parameters.AddWithValue("@lastname", textBox11.Text);
                cmd.Parameters.AddWithValue("@firstname", textBox12.Text);
                cmd.Parameters.AddWithValue("@address", textBox10.Text);
                cmd.Parameters.AddWithValue("@country", textBox8.Text);
                cmd.Parameters.AddWithValue("@city", textBox9.Text);
                cmd.Parameters.AddWithValue("@gender", textBox13.Text);
                cmd.Parameters.AddWithValue("@dob", textBox2.Text);
                cmd.Parameters.AddWithValue("@phone", textBox7.Text);
                cmd.Parameters.AddWithValue("checkinstatus", "Close");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted");
                conn.sqlConnection1.Close();
            }
            catch (Exception ex) {

                MessageBox.Show("Error " + ex.Message);
            }
            finally
            {
                conn.sqlConnection1.Close();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
