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
    public partial class Form4 : Form
    {
        conn conn = new conn();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select reservid from checkin where checkinstatus='Close'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["reservid"].ToString());

            }
            conn.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            from2 f2 = new from2();
            f2.ShowDialog();
            this.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into checkout(reservid,checkoutdate,noadults,nochilds,noinfants,totalmembers,lastname,firstname,address,country,city,gender,dob,phone,checkoutstatus) values(@reservid,@checkoutdate,@noadults,@nochilds,@noinfants,@totalmembers,@lastname,@firstname,@address,@country,@city,@gender,@dob,@phone,@checkoutstatus)", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@reservid", comboBox1.Text);
            cmd.Parameters.AddWithValue("@checkoutdate", textBox1.Text);
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
            cmd.Parameters.AddWithValue("@checkoutstatus", "Close");
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Updated!!");
            conn.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from checkin where reservid='" +comboBox1.Text +"'",conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) {
                textBox3.Text=dr["noadults"].ToString();
                textBox4.Text=dr["nochilds"].ToString();
                textBox5.Text=dr["noinfants"].ToString();
                textBox6.Text=dr["totalmembers"].ToString();
                textBox11.Text=dr["lastname"].ToString();
                textBox12.Text=dr["firstname"].ToString();
                textBox10.Text=dr["address"].ToString();
                textBox8.Text=dr["country"].ToString();
                textBox9.Text=dr["city"].ToString();
                textBox13.Text=dr["gender"].ToString();
                textBox2.Text=dr["dob"].ToString();
                textBox7.Text=dr["phone"].ToString();         
            }
 
            conn.sqlConnection1.Close();
        }
    }
}
