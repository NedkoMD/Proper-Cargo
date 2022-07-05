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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Dispose();
            menu.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да затворите Proper Cargo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void vehiclesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False");
        private void Dashboard_Load(object sender, EventArgs e)
        {
            Drivers drivers = new Drivers();
            DriversAdd driversAdd = new DriversAdd(drivers);
            driversAdd.ShowDrivers();
            int drCount = drivers.dataGridView1.RowCount;
            label6.Text = drCount.ToString();
            label23.Text = ((int)(drCount * 0.3)).ToString();
            label24.Text = ((int)(drCount - int.Parse(label23.Text))).ToString();

            Vehicles vehicles = new Vehicles();
            VehiclesAdd vehiclesAdd = new VehiclesAdd(vehicles);
            vehiclesAdd.ShowVehicles();
            int vhCount = vehicles.dataGridView1.RowCount;
            label9.Text = vhCount.ToString();
            label18.Text = label24.Text;
            label26.Text = ((int)(vhCount - int.Parse(label18.Text))).ToString();

            Routes routes = new Routes();
            RoutesAdd routesAdd = new RoutesAdd(routes);
            routesAdd.ShowRoutes();
            int rtCount = routes.dataGridView1.RowCount;
            label12.Text = rtCount.ToString();

            Customers customers = new Customers();
            CustomersAdd customersAdd = new CustomersAdd(customers);
            customersAdd.ShowCustomers();
            int csCount = customers.dataGridView1.RowCount;
            label3.Text = csCount.ToString();

            Warehouse warehouse = new Warehouse();
            StockAdd stockAdd = new StockAdd(warehouse);
            stockAdd.ShowStocks();
            int stCount = warehouse.dataGridView1.RowCount;
            label4.Text = stCount.ToString();

            int knCount = warehouse.dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["Пакетиране"].Value.ToString())
                .Count(s => s == "Контейнер");
            label29.Text = knCount.ToString();

            int skCount = warehouse.dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["Пакетиране"].Value.ToString())
                .Count(s => s == "Сандък");
            label30.Text = skCount.ToString();

            int ksCount = warehouse.dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["Пакетиране"].Value.ToString())
                .Count(s => s == "Кашон");
            label31.Text = knCount.ToString();

            int plCount = warehouse.dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["Пакетиране"].Value.ToString())
                .Count(s => s == "Плик");
            label32.Text = plCount.ToString();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
