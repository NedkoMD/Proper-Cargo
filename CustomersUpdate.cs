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
    public partial class CustomersUpdate : Form
    {
        public CustomersUpdate()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сигурни ли сте, че искате да затворите прозореца?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void CustomersUpdate_Load(object sender, EventArgs e)
        {

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
                    SqlCommand cmd = new SqlCommand("Update Customers set CuCompany=@CuCmp, CuManagerFN=@CuMFN, CuManagerLN=@CuMLN, CuPhone=@CuPh, CuDAddress=@CuDA where CuId=@Cu_Id", con);
                    cmd.Parameters.AddWithValue("@Cu_Id", textBox6.Text);
                    cmd.Parameters.AddWithValue("@CuCmp", textBox1.Text);
                    cmd.Parameters.AddWithValue("@CuMFN", textBox2.Text);
                    cmd.Parameters.AddWithValue("@CuMLN", textBox3.Text);
                    cmd.Parameters.AddWithValue("@CuPh", textBox4.Text);
                    cmd.Parameters.AddWithValue("@CuDA", textBox5.Text);
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

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = true;
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = false;
        }

        private void CustomersUpdate_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
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
    }
}
