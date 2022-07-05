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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 400;
            bunifuProgressBar1.MaximumValue = 6;
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (bunifuProgressBar1.Value == 5)
            {
                timer1.Stop();
                Login login = new Login();
                this.Hide();
                login.Show();
            }
            else
            {
                bunifuProgressBar1.Value++;
            }
        }
    }
}
