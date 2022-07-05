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
    public partial class Customers : Form
    {
        public Customers()
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
            CustomersAdd customersAdd = new CustomersAdd(this);
            customersAdd.Show();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            CustomersAdd customersAdd = new CustomersAdd(this);
            customersAdd.ShowCustomers();
        }


        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False");
        private void button3_Click(object sender, EventArgs e)
        {
            CustomersAdd customersAdd = new CustomersAdd(this);
            string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            string ID = textBox1.Text;
            string Query = "Delete from Customers where CuId=" + ID;

            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да изтриете данните за клиент №:" + ID + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                customersAdd.ShowCustomers();
            }
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = ID.ToString();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = ID.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CustomersUpdate customersUpdate = new CustomersUpdate();
            customersUpdate.Show();
            customersUpdate.textBox6.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            customersUpdate.textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            customersUpdate.textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            customersUpdate.textBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            customersUpdate.textBox4.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            customersUpdate.textBox5.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void Customers_Enter(object sender, EventArgs e)
        {
            CustomersAdd customersAdd = new CustomersAdd(this);
            customersAdd.ShowCustomers();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            CustomersAdd customersAdd = new CustomersAdd(this);
            customersAdd.ShowCustomers();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
