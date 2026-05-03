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
    public partial class ucAdminRoomService : UserControl
    {
        public ucAdminRoomService()
        {
            InitializeComponent();
        }

        private void createRoombtn_Click(object sender, EventArgs e)
        {
            Form open = Application.OpenForms["CreateMenu"];

            if (open != null)
            {
                open.BringToFront();
                open.WindowState = FormWindowState.Normal;
            }
            else
            {
                new CreateMenu().Show();
            }
        }
    }
}
