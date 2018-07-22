using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HotelMS
{
    public partial class Form3 : Form
    {
        conn conn = new conn();
        public Form3()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int reservid = 0;
            comboBox1.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            this.WindowState = FormWindowState.Maximized;
            String[] status = { "Online", "Hand-to-Hand" };
            String[] country = { "Pakistan", "Saudia Arabia", "Oman", "Behrain", "Autralia" };
            String[] city = { "Islamabad", "Jeddah", "Muscat", "Manama", "Canberra" };
            String[] gender = { "Male", "Female" };
            String[] roomtype = { "Single", "Double", "Family" };
            String[] season = { "Holiday", "WeekEnds"};
            comboBox1.Items.AddRange(status);
            comboBox4.Items.AddRange(country);
            comboBox5.Items.AddRange(city);
            comboBox6.Items.AddRange(gender);
            comboBox3.Items.AddRange(roomtype);
            comboBox2.Items.AddRange(season);
            try
            {
                conn.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("select count(reservid) from guestdetails", conn.sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    reservid = Convert.ToInt32(dr[0]);
                    reservid++;
                }

                this.textBox18.Text = "Res-" + reservid + "-" + System.DateTime.Today.Year;
                conn.sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);

            }
            finally {
                conn.sqlConnection1.Close();
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            from2 f2 = new from2();
            f2.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("insert into roomdetails(reservid,roomno,bookingdate,status,userto,season,roomtype) values(@reservid,@roomno,@bookingdate,@status,@userto,@season,@roomtype)", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@reservid", textBox18.Text);
                cmd.Parameters.AddWithValue("@roomno", textBox1.Text);
                cmd.Parameters.AddWithValue("@bookingdate", textBox9.Text);
                cmd.Parameters.AddWithValue("@status", comboBox1.Text);
                cmd.Parameters.AddWithValue("@userto", textBox2.Text);
                cmd.Parameters.AddWithValue("@season", comboBox2.Text);
                cmd.Parameters.AddWithValue("@roomtype", comboBox3.Text);
                cmd.ExecuteNonQuery();
                conn.sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);

            }
            finally
            {
                conn.sqlConnection1.Close();
            }

            try
            {
                conn.sqlConnection1.Open();
                SqlCommand cmd1 = new SqlCommand("insert into checkin(reservid,checkindate,noadults,nochilds,noinfants,totalmembers,lastname,firstname,address,country,city,gender,dob,phone,checkinstatus)values(@reservid,@checkindate,@noadults,@nochilds,@noinfants,@totalmembers,@lastname,@firstname,@address,@country,@city,@gender,@dob,@phone,@checkinstatus) ", conn.sqlConnection1);
                cmd1.Parameters.AddWithValue("@reservid", textBox18.Text);
                cmd1.Parameters.AddWithValue("@checkindate", textBox20.Text);
                cmd1.Parameters.AddWithValue("@noadults", textBox3.Text);
                cmd1.Parameters.AddWithValue("@nochilds", textBox4.Text);
                cmd1.Parameters.AddWithValue("@noinfants", textBox5.Text);
                cmd1.Parameters.AddWithValue("@totalmembers", textBox6.Text);
                cmd1.Parameters.AddWithValue("@lastname", textBox11.Text);
                cmd1.Parameters.AddWithValue("@firstname", textBox12.Text);
                cmd1.Parameters.AddWithValue("@address", textBox10.Text);
                cmd1.Parameters.AddWithValue("@country", comboBox4.Text);
                cmd1.Parameters.AddWithValue("@city", comboBox5.Text);
                cmd1.Parameters.AddWithValue("@gender", textBox13.Text);
                cmd1.Parameters.AddWithValue("@dob",textBox22.Text);
                cmd1.Parameters.AddWithValue("@phone", textBox7.Text);
                cmd1.Parameters.AddWithValue("checkinstatus", "Close");
                cmd1.ExecuteNonQuery();
                conn.sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);

            }
            finally
            {
                conn.sqlConnection1.Close();
            }

            try
            {
                conn.sqlConnection1.Open();
                SqlCommand cmd2 = new SqlCommand("insert into paytype(reservid,paytype,billto,cardno) values(@reservid,@paytype,@billto,@cardno)", conn.sqlConnection1);
                cmd2.Parameters.AddWithValue("@reservid", textBox18.Text);
                cmd2.Parameters.AddWithValue("@paytype", comboBox7.Text);
                cmd2.Parameters.AddWithValue("@billto", comboBox8.Text);
                cmd2.Parameters.AddWithValue("@cardno", textBox8.Text);
                cmd2.ExecuteNonQuery();
                conn.sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);

            }
            finally
            {
                conn.sqlConnection1.Close();
            }
            try
            {
                conn.sqlConnection1.Open();
                SqlCommand cmd3 = new SqlCommand("insert into bill(reservid,totalcharges,amountpaid,discount,balance,tax,totalamount) values(@reservid,@totalcharges,@amountpaid,@discount,@balance,@tax,@totalamount)", conn.sqlConnection1);
                cmd3.Parameters.AddWithValue("@reservid", textBox18.Text);
                cmd3.Parameters.AddWithValue("@totalcharges", textBox13.Text);
                cmd3.Parameters.AddWithValue("@amountpaid", textBox14.Text);
                cmd3.Parameters.AddWithValue("@discount", textBox15.Text);
                cmd3.Parameters.AddWithValue("@balance", textBox16.Text);
                cmd3.Parameters.AddWithValue("@tax", textBox17.Text);
                cmd3.Parameters.AddWithValue("@totalamount", textBox19.Text);
                cmd3.ExecuteNonQuery();
                conn.sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);

            }
            finally
            {
                conn.sqlConnection1.Close();
            }
            try
            {
                conn.sqlConnection1.Open();
                SqlCommand cmd4 = new SqlCommand("insert into guestdetails(reservid,roomno,bookingdate,status,userto,season,roomtype,checkindate,noadults,nochilds,noinfants,totalmembers,lastname,firstname,address,country,city,gender,dob,phone,paytype,billto,cardno,totalcharges,amountpaid,discount,balance,tax,totalamount)values(@reservid,@roomno,@bookingdate,@status,@userto,@season,@roomtype,@checkindate,@noadults,@nochilds,@noinfants,@totalmembers,@lastname,@firstname,@address,@country,@city,@gender,@dob,@phone,@paytype,@billto,@cardno,@totalcharges,@amountpaid,@discount,@balance,@tax,@totalamount)", conn.sqlConnection1);
                cmd4.Parameters.AddWithValue("@reservid", textBox18.Text);
                cmd4.Parameters.AddWithValue("@roomno", textBox1.Text);
                cmd4.Parameters.AddWithValue("@bookingdate", textBox9.Text);
                cmd4.Parameters.AddWithValue("@status", comboBox1.Text);
                cmd4.Parameters.AddWithValue("@userto", textBox2.Text);
                cmd4.Parameters.AddWithValue("@season", comboBox2.Text);
                cmd4.Parameters.AddWithValue("@roomtype", comboBox3.Text);

                cmd4.Parameters.AddWithValue("@checkindate", textBox20.Text);
                cmd4.Parameters.AddWithValue("@noadults", textBox3.Text);
                cmd4.Parameters.AddWithValue("@nochilds", textBox4.Text);
                cmd4.Parameters.AddWithValue("@noinfants", textBox5.Text);
                cmd4.Parameters.AddWithValue("@totalmembers", textBox6.Text);
                cmd4.Parameters.AddWithValue("@lastname", textBox11.Text);
                cmd4.Parameters.AddWithValue("@firstname", textBox12.Text);
                cmd4.Parameters.AddWithValue("@address", textBox10.Text);
                cmd4.Parameters.AddWithValue("@country", comboBox4.Text);
                cmd4.Parameters.AddWithValue("@city", comboBox5.Text);
                cmd4.Parameters.AddWithValue("@gender", textBox13.Text);
                cmd4.Parameters.AddWithValue("@dob", textBox22.Text);
                cmd4.Parameters.AddWithValue("@phone", textBox7.Text);

                cmd4.Parameters.AddWithValue("@paytype", comboBox7.Text);
                cmd4.Parameters.AddWithValue("@billto", comboBox8.Text);
                cmd4.Parameters.AddWithValue("@cardno", textBox8.Text);
                cmd4.Parameters.AddWithValue("@totalcharges", textBox13.Text);
                cmd4.Parameters.AddWithValue("@amountpaid", textBox14.Text);
                cmd4.Parameters.AddWithValue("@discount", textBox15.Text);
                cmd4.Parameters.AddWithValue("@balance", textBox16.Text);
                cmd4.Parameters.AddWithValue("@tax", textBox17.Text);
                cmd4.Parameters.AddWithValue("@totalamount", textBox19.Text);
                cmd4.ExecuteNonQuery();
                MessageBox.Show("Data Inserted");
                conn.sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
            }
            finally {
                conn.sqlConnection1.Close();
            
            }
    }
    }
}