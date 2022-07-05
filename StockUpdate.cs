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
    public partial class StockUpdate : Form
    {
        public StockUpdate()
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

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = true;
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = false;
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                double volume = double.Parse(textBox3.Text);
                double quantity = double.Parse(textBox5.Text);
                double sum = volume * quantity;
                textBox6.Text = sum.ToString();
            }
            catch
            {
                MessageBox.Show("Моля, въведете обем и количество на товар!");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',';
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',';
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',';
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False");
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Моля, попълнете всички полета!");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update Stocks set StName=@StN, StVolume=@StVol, StWeight=@StWgh, StQuantity=@StQn, StSumQuantity=@StSumQn where StId=@St_Id", con);
                    cmd.Parameters.AddWithValue("@St_Id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@StN", textBox2.Text);
                    cmd.Parameters.AddWithValue("@StVol", double.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@StWgh", double.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@StQn", int.Parse(textBox5.Text));
                    cmd.Parameters.AddWithValue("@StSumQn", double.Parse(textBox6.Text));
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
    }
}
