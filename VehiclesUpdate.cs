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
    public partial class VehiclesUpdate : Form
    {
        public VehiclesUpdate()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False");
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Моля, попълнете всички полета!");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update Vehicles set VhModel=@VhMod, VhMileage=@VhMil, VhVolume=@VhVol where VhId=@Vh_Id", con);
                    cmd.Parameters.AddWithValue("@Vh_Id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@VhMod", textBox2.Text);
                    cmd.Parameters.AddWithValue("@VhMil", textBox3.Text);
                    cmd.Parameters.AddWithValue("@VhVol", textBox4.Text);
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
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = true;
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = false;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',';
        }
    }
}
