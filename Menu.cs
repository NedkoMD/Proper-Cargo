using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logistics_Software
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            Drivers drivers = new Drivers();
            drivers.Show();
            this.Dispose();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.Show();
            this.Dispose();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            Vehicles vehicles = new Vehicles();
            vehicles.Show();
            this.Dispose();
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            Routes routes = new Routes();
            routes.Show();
            this.Dispose();
        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.Show();
            this.Dispose();
        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да излезете?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Dispose();
                Login login = new Login();
                login.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да излезете?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Dispose();
                Login login = new Login();
                login.Show();
            }
        }

        private void bunifuTileButton9_Click(object sender, EventArgs e)
        {
            Cargo cargo = new Cargo();
            cargo.Show();
            this.Dispose();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да затворите Proper Cargo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void bunifuTileButton1_MouseEnter(object sender, EventArgs e)
        {
            bunifuTileButton1.ImageZoom = 52;
        }

        private void bunifuTileButton1_MouseLeave(object sender, EventArgs e)
        {
            bunifuTileButton1.ImageZoom = 50;
        }

        private void bunifuTileButton2_MouseEnter(object sender, EventArgs e)
        {
            bunifuTileButton2.ImageZoom = 52;
        }

        private void bunifuTileButton2_MouseLeave(object sender, EventArgs e)
        {
            bunifuTileButton2.ImageZoom = 50;
        }

        private void bunifuTileButton3_MouseEnter(object sender, EventArgs e)
        {
            bunifuTileButton3.ImageZoom = 64;
            bunifuTileButton3.ImagePosition = 14;
        }

        private void bunifuTileButton3_MouseLeave(object sender, EventArgs e)
        {
            bunifuTileButton3.ImageZoom = 62;
            bunifuTileButton3.ImagePosition = 16;
        }

        private void bunifuTileButton6_MouseEnter(object sender, EventArgs e)
        {
            bunifuTileButton6.ImageZoom = 52;
        }

        private void bunifuTileButton6_MouseLeave(object sender, EventArgs e)
        {
            bunifuTileButton6.ImageZoom = 50;
        }

        private void bunifuTileButton5_MouseEnter(object sender, EventArgs e)
        {
            bunifuTileButton5.ImageZoom = 52;
        }

        private void bunifuTileButton5_MouseLeave(object sender, EventArgs e)
        {
            bunifuTileButton5.ImageZoom = 50;
        }

        private void bunifuTileButton9_MouseEnter(object sender, EventArgs e)
        {
            bunifuTileButton9.ImageZoom = 52;
        }

        private void bunifuTileButton9_MouseLeave(object sender, EventArgs e)
        {
            bunifuTileButton9.ImageZoom = 50;
        }

        private void bunifuTileButton4_MouseEnter(object sender, EventArgs e)
        {
            bunifuTileButton4.ImageZoom = 52;
        }

        private void bunifuTileButton4_MouseLeave(object sender, EventArgs e)
        {
            bunifuTileButton4.ImageZoom = 50;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(37, 47);
        }

        private void pictureBox2_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(35, 45);
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(37, 47);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
