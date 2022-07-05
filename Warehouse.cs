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
    public partial class Warehouse : Form
    {
        public Warehouse()
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
            StockAdd stockadd = new StockAdd(this);
            stockadd.Show();
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {
            StockAdd stocksAdd = new StockAdd(this);
            stocksAdd.ShowStocks();
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
            textBox1.Text = ID.ToString();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = ID.ToString();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False");
        private void button3_Click(object sender, EventArgs e)
        {
            StockAdd stockAdd = new StockAdd(this);
            string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            string ID = textBox1.Text;
            string Query = "Delete from Stocks where StId='" + ID + "'";

            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да изтриете данните за продукт №:" + ID + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                stockAdd.ShowStocks();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StockUpdate stockUpdate = new StockUpdate();
            stockUpdate.Show();
            stockUpdate.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            stockUpdate.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            stockUpdate.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            stockUpdate.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            stockUpdate.textBox5.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            stockUpdate.textBox7.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            stockUpdate.textBox6.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            StockAdd stockAdd = new StockAdd(this);
            stockAdd.ShowStocks();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
