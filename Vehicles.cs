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
    public partial class Vehicles : Form
    {
        public Vehicles()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Dispose();
            menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VehiclesAdd vehiclesAdd = new VehiclesAdd(this);
            vehiclesAdd.Show();
        }

        private void Vehicles_Load(object sender, EventArgs e)
        {
            VehiclesAdd vehiclesAdd = new VehiclesAdd(this);
            vehiclesAdd.ShowVehicles();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да затворите Proper Cargo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = ID;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = ID;
        }


        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False");
        private void button3_Click(object sender, EventArgs e)
        {
            VehiclesAdd vehiclesAdd = new VehiclesAdd(this);
            string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            string ID = textBox1.Text;
            string Query = "Delete from Vehicles where Id=" + ID;

            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да изтриете данните за ППС с рег. №:" + ID + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                vehiclesAdd.ShowVehicles();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            VehiclesUpdate vehiclesUpdate = new VehiclesUpdate();
            vehiclesUpdate.Show();
            vehiclesUpdate.textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            vehiclesUpdate.textBox8.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            vehiclesUpdate.textBox2.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            vehiclesUpdate.textBox3.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            vehiclesUpdate.textBox4.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            vehiclesUpdate.textBox5.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            vehiclesUpdate.textBox6.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            vehiclesUpdate.textBox7.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            VehiclesAdd vehiclesAdd = new VehiclesAdd(this);
            vehiclesAdd.ShowVehicles();
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            label3.Visible = true;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            int service = int.Parse(this.dataGridView1.CurrentRow.Cells[4].Value.ToString()) - 30000;
            int filters = int.Parse(this.dataGridView1.CurrentRow.Cells[4].Value.ToString()) - 20000;
            VehiclesService vehiclesService = new VehiclesService();
            vehiclesService.Show();
            vehiclesService.label19.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            vehiclesService.label20.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            vehiclesService.label21.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            vehiclesService.label22.Text = this.dataGridView1.CurrentRow.Cells[4].Value+" km".ToString();
            vehiclesService.label23.Text = this.dataGridView1.CurrentRow.Cells[5].Value+" m³".ToString();
            vehiclesService.label1.Text = this.dataGridView1.CurrentRow.Cells[6].Value+" г.".ToString();
            vehiclesService.label2.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            vehiclesService.label7.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            if(service == 0)
            {
                vehiclesService.label13.Text = "ОБСЛУЖВАНЕ!";
                vehiclesService.label14.Text = "ОБСЛУЖВАНЕ!";
                vehiclesService.label13.ForeColor = System.Drawing.Color.Red;
                vehiclesService.label14.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                vehiclesService.label13.Text = service + " km".ToString();
                vehiclesService.label14.Text = service + " km".ToString();
            }
            if (filters == 0)
            {
                vehiclesService.label15.Text = "ОБСЛУЖВАНЕ!";
                vehiclesService.label15.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                vehiclesService.label15.Text = filters + " km".ToString();
            }
            vehiclesService.label16.Text = "Изправни";
            vehiclesService.label24.Text = "Отлично";
            vehiclesService.label25.Text = "Добро";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
