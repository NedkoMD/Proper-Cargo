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
    public partial class Cargo : Form
    {
        public Cargo()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Dispose();
            menu.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Cargo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'logistics_DBDataSet.Vehicles' table. You can move, or remove it, as needed.
            this.vehiclesTableAdapter.Fill(this.logistics_DBDataSet.Vehicles);
            // TODO: This line of code loads data into the 'logistics_DBDataSet.Stocks' table. You can move, or remove it, as needed.
            this.stocksTableAdapter.Fill(this.logistics_DBDataSet.Stocks);

            bunifuProgressBar1.MaximumValue = int.Parse(vhVolumeLabel1.Text);
            label15.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bunifuProgressBar1.MaximumValue = int.Parse(vhVolumeLabel1.Text);
            if (!listBox1.Items.Contains(comboBox2.SelectedValue) && bunifuProgressBar1.Value < bunifuProgressBar1.MaximumValue)
            {
                if (comboBox2.SelectedValue.ToString().StartsWith("PL"))
                {
                    if (bunifuProgressBar1.MaximumValue - bunifuProgressBar1.Value >= 2)
                    {
                        bunifuProgressBar1.Value += 2;
                        listBox1.Items.Add(comboBox2.SelectedValue.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Пакетът, който се опитвате да натоварите, ще надхвърли максималния капацитет на ППС-то!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (comboBox2.SelectedValue.ToString().StartsWith("KS"))
                {
                    if (bunifuProgressBar1.MaximumValue - bunifuProgressBar1.Value >= 5)
                    {
                        bunifuProgressBar1.Value += 5;
                        listBox1.Items.Add(comboBox2.SelectedValue.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Кашонът, който се опитвате да натоварите, ще надхвърли максималния капацитет на ППС-то!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (comboBox2.SelectedValue.ToString().StartsWith("SK"))
                {
                    if (bunifuProgressBar1.MaximumValue - bunifuProgressBar1.Value >= 10)
                    {
                        bunifuProgressBar1.Value += 10;
                        listBox1.Items.Add(comboBox2.SelectedValue.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Сандъкът, който се опитвате да натоварите, ще надхвърли максималния капацитет на ППС-то!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (comboBox2.SelectedValue.ToString().StartsWith("KN") && bunifuProgressBar1.Value == 0)
                {
                    bunifuProgressBar1.Value = bunifuProgressBar1.MaximumValue;
                    listBox1.Items.Add(comboBox2.SelectedValue.ToString());
                }
                else if (comboBox2.SelectedValue.ToString().StartsWith("KN") && bunifuProgressBar1.Value > 0)
                {
                    MessageBox.Show("Контейнерът изисква пълния товарен обем на ППС-то!\nМоля, изберете друго ППС или разтоварете целия товар!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (bunifuProgressBar1.Value == bunifuProgressBar1.MaximumValue)
            {
                MessageBox.Show("Товарният обем на ППС-то е запълнен!\nМоля, изберете друго ППС или освободете пространство!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (bunifuProgressBar1.Value == bunifuProgressBar1.MaximumValue)
            {
                bunifuProgressBar1.ProgressColor = Color.Red;
            }
            else
            {
                bunifuProgressBar1.ProgressColor = Color.LimeGreen;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int itemAtPosition = listBox1.SelectedIndex;
            if (listBox1.SelectedItem != null)
            {
                if (listBox1.Items.Count > 0)
                {
                    if (listBox1.Items[itemAtPosition].ToString().StartsWith("PL"))
                    {
                        bunifuProgressBar1.Value -= 2;
                        listBox1.Items.Remove(listBox1.SelectedItem);
                    }
                    else if (listBox1.Items[itemAtPosition].ToString().StartsWith("KS"))
                    {
                        bunifuProgressBar1.Value -= 5;
                        listBox1.Items.Remove(listBox1.SelectedItem);
                    }
                    else if (listBox1.Items[itemAtPosition].ToString().StartsWith("SK"))
                    {
                        bunifuProgressBar1.Value -= 10;
                        listBox1.Items.Remove(listBox1.SelectedItem);
                    }
                    else if (listBox1.Items[itemAtPosition].ToString().StartsWith("KN"))
                    {
                        bunifuProgressBar1.Value = 0;
                        listBox1.Items.Remove(listBox1.SelectedItem);
                    }
                }
            }
            else if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Товарният обем на ППС-то вече е празен!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Моля, изберете товар от листа с товари!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (bunifuProgressBar1.Value == bunifuProgressBar1.MaximumValue)
            {
                bunifuProgressBar1.ProgressColor = Color.Red;
            }
            else
            {
                bunifuProgressBar1.ProgressColor = Color.LimeGreen;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да затворите Proper Cargo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            bunifuProgressBar1.Value = 0;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да премахнете всички товари?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    listBox1.Items.Clear();
                    bunifuProgressBar1.Value = 0;
                }
            }
            else MessageBox.Show("Товарният обем на ППС-то вече е празен!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            label15.Visible = true;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            label15.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Сигурни ли сте, че искате да запишете товарите за ППС с рег. №: " + vhIdLabel1.Text + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show("Товарите са записани успешно!");
                }
            }
            else MessageBox.Show("Товарният обем на ППС-то е празен! Моля добавете товари!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void bunifuProgressBar1_progressChanged(object sender, EventArgs e)
        {
        }
    }
}
