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
    public partial class Form6 : Form
    {
        conn conn = new conn();
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select reservid from guestdetails",conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {

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

        private void button5_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from checkin where reservid='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.sqlConnection1.Close();
        }
    }
}
