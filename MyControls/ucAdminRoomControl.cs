using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem.MyControls
{
    public partial class ucAdminRoomControl : UserControl
    {
        public ucAdminRoomControl()
        {
            InitializeComponent();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.Text == "Select Room Type")
            {
                MessageBox.Show("Please select a valid room type.");
                return;
            }
        }

        private void createRoombtn_Click(object sender, EventArgs e)
        {
            CreateRoom createRoomForm = new CreateRoom();
            createRoomForm.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
