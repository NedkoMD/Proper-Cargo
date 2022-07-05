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
    public partial class RoutesAdd : Form
    {
        Routes routes = new Routes();
        public RoutesAdd(Routes rt)
        {
            InitializeComponent();
            this.routes = rt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сигурни ли сте, че искате да затворите прозореца?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void RoutesAdd_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'logistics_DBDataSet.Drivers' table. You can move, or remove it, as needed.
            this.driversTableAdapter.Fill(this.logistics_DBDataSet.Drivers);
            // TODO: This line of code loads data into the 'logistics_DBDataSet.Vehicles' table. You can move, or remove it, as needed.
            this.vehiclesTableAdapter.Fill(this.logistics_DBDataSet.Vehicles);
            // TODO: This line of code loads data into the 'logistics_DBDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.logistics_DBDataSet.Customers);
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False");
        public void ShowRoutes()
        {
            con.Open();
            string Query = "select RtId as 'Курс №', Rt_CuCompany as 'Фирма', Rt_DrId as 'Шофьор №', Rt_VhId as 'Рег. номер', Rt_CuDAddress as 'Адрес за доставка', RtStart as 'Начало на курс' from Routes";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            adapter.Fill(ds);
            routes.dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Моля, попълнете всички полета!");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Routes (Rt_CuCompany, Rt_DrId, Rt_VhId, Rt_CuDAddress, RtStart) values (@Rt_Com, @Rt_Dr, @Rt_Vh, @Rt_Ad, @RtSt)", con);
                    cmd.Parameters.AddWithValue("@Rt_Com", comboBox1.GetItemText(comboBox1.SelectedItem));
                    cmd.Parameters.AddWithValue("@Rt_Dr", comboBox2.GetItemText(comboBox2.SelectedItem));
                    cmd.Parameters.AddWithValue("@Rt_Vh", comboBox3.GetItemText(comboBox3.SelectedItem));
                    cmd.Parameters.AddWithValue("@Rt_Ad", listBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@RtSt", dateTimePicker1.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данните са записани успешно!");
                    this.Dispose();
                    con.Close();
                    ShowRoutes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
