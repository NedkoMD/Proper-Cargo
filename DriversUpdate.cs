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

namespace Logistics_Software
{
    public partial class DriversUpdate : Form
    {
        public DriversUpdate()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False");
        private void button1_Click(object sender, EventArgs e)
        {
            Drivers drivers = new Drivers();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Моля, попълнете всички полета!");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update Drivers set DrFirstName=@DrFN, DrLastName=@DrLN, DrEGN=@DREG, DrPhone=@DrPh, DrAddress=@DrAd where DrId=@DR_Id", con);
                    cmd.Parameters.AddWithValue("@Dr_Id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@DrFN", textBox2.Text);
                    cmd.Parameters.AddWithValue("@DrLN", textBox3.Text);
                    cmd.Parameters.AddWithValue("@DrEG", textBox4.Text);
                    cmd.Parameters.AddWithValue("@DrPh", textBox5.Text);
                    cmd.Parameters.AddWithValue("@DrAd", textBox6.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данните са актуализирани успешно!");
                    this.Dispose(true);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сигурни ли сте, че искате да затворите прозореца?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = true;
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = false;
        }

        private void dateTimePicker1_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
        }
    }
}
