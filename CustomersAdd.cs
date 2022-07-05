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
    public partial class CustomersAdd : Form
    {
        Customers customers = new Customers();
        public CustomersAdd(Customers cu)
        {
            InitializeComponent();
            this.customers = cu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сигурни ли сте, че искате да затворите прозореца?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False");
        public void ShowCustomers()
        {
            con.Open();
            string Query = "select CuId as 'Клиентски №', CuCompany as 'Фирма', CuManagerFN as 'Име на управител', CuManagerLN as 'Фамилия на управител', CuPhone as 'Телефон', CuDAddress as 'Адрес' from Customers";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            adapter.Fill(ds);
            customers.dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
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
                    SqlCommand cmd = new SqlCommand("Insert into Customers (CuCompany, CuManagerFN, CuManagerLN, CuPhone, CuDAddress) values (@CuCmp, @CuMFN, @CuMLN, @CuPh, @CuDA)", con);
                    cmd.Parameters.AddWithValue("@CuCmp", textBox1.Text);
                    cmd.Parameters.AddWithValue("@CuMFN", textBox2.Text);
                    cmd.Parameters.AddWithValue("@CuMLN", textBox3.Text);
                    cmd.Parameters.AddWithValue("@CuPh", textBox4.Text);
                    cmd.Parameters.AddWithValue("@CuDA", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данните са записани успешно!");
                    this.Dispose(true);
                    con.Close();
                    ShowCustomers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
