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
    public partial class Form1 : Form
    {
        conn conn = new conn();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("select userid,password from users where userid='" + textBox1.Text + "'" + "and password='" + textBox2.Text + "'", conn.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.Hide();
                    from2 f2 = new from2();
                    f2.ShowDialog();
                    this.Close();
                    conn.sqlConnection1.Close();

                }


                else
                {
                    MessageBox.Show("Invalid User ID or Password");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);

            }

            finally {
                conn.sqlConnection1.Close();
            
            
            }

        }

    }
}
