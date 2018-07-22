using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelMS
{
    public partial class from2 : Form
    {
        int flag = 0;
        public from2()
        {
            InitializeComponent();
        }

        private void from2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = 1;
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag = 2;
            panel1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flag = 3;
            panel1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                this.Hide();
                Form3 f3 = new Form3();
                f3.ShowDialog();
                this.Close();
            }

            if (flag == 2) {
                this.Hide();
                Form2 f22 = new Form2();
                f22.ShowDialog();
                this.Close();

            }
            if (flag == 3) {
                this.Hide();
                Form4 f4 = new Form4();
                f4.ShowDialog();
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (flag == 1) {
                this.Hide();
                Form5 f5 = new Form5();
                f5.ShowDialog();
                this.Close();
            
            
            }

            if (flag == 2)
            {
                this.Hide();
                Form6 f6 = new Form6();
                f6.ShowDialog();
                this.Close();
            }

            if (flag == 3)
            {
                this.Hide();
                Form7 f7 = new Form7();
                f7.ShowDialog();
                this.Close();
            }
        }
    }
}
