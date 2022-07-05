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
    public partial class DriversAdd : Form
    {
        Drivers drivers = new Drivers();
        public DriversAdd(Drivers dr)
        {
            InitializeComponent();
            this.drivers = dr;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void DriversAdd_Load(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False");
        public void ShowDrivers()
        {
            con.Open();
            string Query = "select DrId as 'Служебен №', DrFirstName as 'Име', DrLastName as 'Фамилия', DrEGN as 'ЕГН', DrPhone as 'Телефон', DrJoinDate as 'Дата на назначаване', DrAddress as 'Адрес' from Drivers";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            adapter.Fill(ds);
            drivers.dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text =="" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Моля, попълнете всички полета!");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Drivers (DrId, DrFirstName, DrLastName, DrEGN, DrPhone, DrJoinDate, DrAddress) values (@Dr_Id, @DrFN, @DrLN, @DrEG, @DrPh, @DrJD, @DrAd)", con);
                    cmd.Parameters.AddWithValue("@Dr_Id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@DrFN", textBox2.Text);
                    cmd.Parameters.AddWithValue("@DrLN", textBox3.Text);
                    cmd.Parameters.AddWithValue("@DrEG", textBox4.Text);
                    cmd.Parameters.AddWithValue("@DrPh", textBox5.Text);
                    cmd.Parameters.AddWithValue("@DrJD", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@DrAd", textBox6.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данните са записани успешно!");
                    this.Dispose();
                    con.Close();
                    ShowDrivers();
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8;
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
    }
}
