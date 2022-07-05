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
    public partial class Routes : Form
    {
        public Routes()
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
            RoutesAdd routesAdd = new RoutesAdd(this);
            routesAdd.Show();
        }

        private void Routes_Load(object sender, EventArgs e)
        {
            RoutesAdd routesAdd = new RoutesAdd(this);
            routesAdd.ShowRoutes();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да затворите Proper Cargo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            RoutesMaps routesMaps = new RoutesMaps();
            routesMaps.Show();
            var address = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            routesMaps.textBox1.Text = address.ToString();

            StringBuilder queryaddress = new StringBuilder();
            queryaddress.Append("https://maps.google.com/maps?q=");
            if (address != string.Empty)
            {
                queryaddress.Append(routesMaps.textBox1.Text);
            }
            routesMaps.webBrowser1.Navigate(queryaddress.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RoutesUpdate routesUpdate = new RoutesUpdate();
            routesUpdate.Show();
            routesUpdate.textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            routesUpdate.textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            routesUpdate.textBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            routesUpdate.listBox1.Items.Add(this.dataGridView1.CurrentRow.Cells[4].Value.ToString());
            routesUpdate.textBox4.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False");
        private void button3_Click(object sender, EventArgs e)
        {
            RoutesAdd routesAdd = new RoutesAdd(this);
            string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logistics_DB;Integrated Security=True;Pooling=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            string ID = textBox1.Text;
            string Query = "Delete from Routes where RtId=" + ID;

            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да изтриете данните за курс №:" + ID + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                routesAdd.ShowRoutes();
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

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            label3.Visible = true;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            RoutesAdd routesAdd = new RoutesAdd(this);
            routesAdd.ShowRoutes();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
