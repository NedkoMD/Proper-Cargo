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
    public partial class Drivers : Form
    {
        public Drivers()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Dispose();
            menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DriversAdd driversAdd = new DriversAdd(this);
            driversAdd.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Drivers_Load(object sender, EventArgs e)
        {
            DriversAdd driversAdd = new DriversAdd(this);
            driversAdd.ShowDrivers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DriversAdd driversAdd = new DriversAdd(this);
            string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            string ID = textBox1.Text;
            string Query = "Delete from Drivers where DrId=" + ID;

            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да изтриете данните за шофьор №:"+ ID+ "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                driversAdd.ShowDrivers();
            }
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да затворите Proper Cargo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = ID.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = ID.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DriversUpdate driversUpdate = new DriversUpdate();
            driversUpdate.Show();
            driversUpdate.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            driversUpdate.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            driversUpdate.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            driversUpdate.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            driversUpdate.textBox5.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            driversUpdate.textBox7.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            driversUpdate.textBox6.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DriversAdd driversAdd = new DriversAdd(this);
            driversAdd.ShowDrivers();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
