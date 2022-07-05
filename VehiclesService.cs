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
    public partial class VehiclesService : Form
    {
        public VehiclesService()
        {
            InitializeComponent();
        }

        private void vehiclesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vehiclesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.logistics_DBDataSet);

        }

        private void VehiclesService_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'logistics_DBDataSet.Vehicles' table. You can move, or remove it, as needed.
            this.vehiclesTableAdapter.Fill(this.logistics_DBDataSet.Vehicles);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            label26.Visible = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label26.Visible = false;
        }
    }
}
