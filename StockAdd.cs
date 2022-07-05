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
    public partial class StockAdd : Form
    {
        Warehouse warehouse = new Warehouse();
        public StockAdd(Warehouse wh)
        {
            InitializeComponent();
            this.warehouse = wh;
        }
        public void ShowStocks()
        {
            con.Open();
            string Query = "select StId as 'Товар №', StName as 'Продукт', StVolume as 'Обем (m³)', StWeight as 'Тегло (кг)', StQuantity as 'Количество', StBoxing as 'Пакетиране', StSumQuantity as 'Общ обем (m³)' from Stocks";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            adapter.Fill(ds);
            warehouse.dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сигурни ли сте, че искате да затворите прозореца?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False");
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox4.SelectedIndex == -1 || textBox6.Text == "")
            {
                MessageBox.Show("Моля, попълнете всички полета!");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Stocks (StId, StName, StVolume, StWeight, StQuantity, StBoxing, StSumQuantity) values (@St_Id, @StN, @StVol, @StWgh, @StQn, @StBx, @StSumQn)", con);
                    cmd.Parameters.AddWithValue("@St_Id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@StN", textBox2.Text);
                    cmd.Parameters.AddWithValue("@StVol", double.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@StWgh", double.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@StQn", int.Parse(textBox5.Text));
                    cmd.Parameters.AddWithValue("@StBx", comboBox4.Text);
                    cmd.Parameters.AddWithValue("@StSumQn", double.Parse(textBox6.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данните са записани успешно!");
                    this.Dispose();
                    con.Close();
                    ShowStocks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

        private void StockAdd_Load(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == -1)
            {
                textBox1.Enabled = false;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 0)
            {
                textBox1.Enabled = true;
                textBox1.Text = "PL";
            }
            else if (comboBox4.SelectedIndex == 1)
            {
                textBox1.Enabled = true;
                textBox1.Text = "KS";
            }
            else if (comboBox4.SelectedIndex == 2)
            {
                textBox1.Enabled = true;
                textBox1.Text = "SK";
            }
            else
            {
                textBox1.Enabled = true;
                textBox1.Text = "KN";
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8;
        }
    }
}
