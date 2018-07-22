using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace HotelMS
{
    public partial class Form5 : Form
    {
        conn conn = new conn();
        public Form5()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            this.WindowState = FormWindowState.Maximized;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select reservid from guestdetails",conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {

                comboBox1.Items.Add(dr["reservid"].ToString());
            
            }
            conn.sqlConnection1.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from guestdetails where reservid='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            from2 f2 = new from2();
            f2.ShowDialog();
            this.Close();
        }
    }
}
