using HotelManagementSystem.MyControl;
using HotelManagementSystem.MyControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            LoadContent(new ucAdminDash());
            btnHome.FillColor = Color.LightSkyBlue;

        }
        private void LoadContent(System.Windows.Forms.UserControl control)
        {
            adminPanelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            adminPanelMain.Controls.Add(control);
        }
        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnOff()
        {
            btnHome.FillColor = Color.Transparent;
            btnGuests.FillColor = Color.Transparent;
            btnRoom.FillColor = Color.Transparent;
            btnReservation.FillColor = Color.Transparent;
            btnInOut.FillColor = Color.Transparent;
            btnLogOut.FillColor = Color.Transparent;
            btnAdminRoomServices.FillColor = Color.Transparent;
            btnBilling.FillColor = Color.Transparent;
            btnFeedBack.FillColor = Color.Transparent;
            btnSettings.FillColor = Color.Transparent;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            btnOff();
            btnHome.FillColor = Color.LightSkyBlue;
            LoadContent(new ucAdminDash());
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            btnOff();
            btnGuests.FillColor = Color.LightSkyBlue;
            LoadContent(new ucAdminGuest());
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            btnOff();
            btnRoom.FillColor = Color.LightSkyBlue;
            LoadContent(new ucAdminRoomControl());
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            btnOff();
            btnReservation.FillColor = Color.LightSkyBlue;
            LoadContent(new ucAdminReservations());
        }

        private void btnInOut_Click(object sender, EventArgs e)
        {
            btnOff();
            btnInOut.FillColor = Color.LightSkyBlue;
            LoadContent(new ucAdminChechINOUT());
        }

        private void btnAdminRoomServices_Click(object sender, EventArgs e)
        {
            btnOff();
            btnAdminRoomServices.FillColor = Color.LightSkyBlue;
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            btnOff();
            btnBilling.FillColor = Color.LightSkyBlue;
        }

        private void btnFeedBack_Click(object sender, EventArgs e)
        {
            btnOff();
            btnFeedBack.FillColor = Color.LightSkyBlue;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            btnOff();
            btnSettings.FillColor = Color.LightSkyBlue;
        }
    }
}
