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
    public partial class VehiclesAdd : Form
    {
        Vehicles vehicles = new Vehicles();
        public VehiclesAdd(Vehicles vh)
        {
            InitializeComponent();
            this.vehicles = vh;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сигурни ли сте, че искате да затворите прозореца?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False");
        public void ShowVehicles()
        {
            con.Open();
            string Query = "select Id as '№', VhId as 'Рег. номер', VhBrand as 'Марка', VhModel as 'Модел', VhMileage as 'Пробег (km)', VhVolume as 'Обем (m³):', VhProduction as 'Производство', VhEngine as 'Двигател', VhColor as 'Цвят' from Vehicles";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            adapter.Fill(ds);
            vehicles.dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedIndex == -1 || textBox3.Text == "" || textBox4.Text == "" || comboBox3.SelectedIndex == -1 || comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Моля, попълнете всички полета!");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Vehicles (VhId, VhBrand, VhModel, VhMileage, VhVolume, VhProduction, VhEngine, VhColor) values (@Vh_Id, @VhBr, @VhMod, @VhMil, @VhVol, @VhPr, @VhEng, @VhCl)", con);
                    cmd.Parameters.AddWithValue("@Vh_Id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@VhBr", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@VhMod", textBox2.Text);
                    cmd.Parameters.AddWithValue("@VhMil", textBox3.Text);
                    cmd.Parameters.AddWithValue("@VhVol", textBox4.Text);
                    cmd.Parameters.AddWithValue("@VhPr", dateTimePicker1.Value.Year);
                    cmd.Parameters.AddWithValue("@VhEng", comboBox3.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@VhCl", comboBox4.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данните са записани успешно!");
                    this.Dispose();
                    con.Close();
                    ShowVehicles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
