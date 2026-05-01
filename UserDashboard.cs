using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using HotelManagementSystem.MyControl;
using HotelManagementSystem.MyControls;

namespace HotelManagementSystem 
{
    public partial class lblUserNameDisplay : Form
    {
        public lblUserNameDisplay()
        {
            InitializeComponent();
            LoadContent(new ucDashboard());
            btnHome.FillColor = Color.LightSkyBlue;
        }
        private void LoadContent(System.Windows.Forms.UserControl control)
        {
            panelMain.Controls.Clear();   
            control.Dock = DockStyle.Fill; 
            panelMain.Controls.Add(control);
        }

        // Event and Button click functions
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void copyrightMessage_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            btnOff();
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            btnOff();
            btnHighlights.FillColor = Color.LightSkyBlue;
            LoadContent(new ucHighlights());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            btnOff();
            btnHome.FillColor = Color.LightSkyBlue;
            LoadContent(new ucDashboard());
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            btnOff();
            btnReservation.FillColor = Color.LightSkyBlue;
            LoadContent(new ucReservation());
        }

        private void btnInOut_Click(object sender, EventArgs e)
        {
            btnOff();
            btnInOut.FillColor = Color.LightSkyBlue;
            LoadContent(new ucCheckInOut());
        }

        private void btnMyBill_Click(object sender, EventArgs e)
        {
            btnOff();
            btnMyBill.FillColor = Color.LightSkyBlue;
            LoadContent(new ucBilling());
        }

        private void btnRoomInfo_Click(object sender, EventArgs e)
        {
            btnOff();
            btnRoomInfo.FillColor = Color.LightSkyBlue;
            LoadContent(new ucRoomInfo());
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            btnOff();
            btnLogOut.FillColor = Color.IndianRed;
        }

        private void btnFeedBack_Click(object sender, EventArgs e)
        {
            btnOff();
            btnFeedBack.FillColor = Color.LightSkyBlue;
            LoadContent(new ucFeedback());
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            btnOff();
            btnProfile.FillColor = Color.LightSkyBlue;
            LoadContent(new ucProfile());
        }
        private void btnRoomServices_Click(object sender, EventArgs e)
        {
            btnOff();
            btnRoomServices.FillColor = Color.LightSkyBlue;
            LoadContent(new ucRoomService());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void btnOff()
        {
            btnHighlights.FillColor = Color.Transparent;
            btnHome.FillColor = Color.Transparent;
            btnInOut.FillColor = Color.Transparent;
            btnMyBill.FillColor = Color.Transparent;
            btnRoomInfo.FillColor = Color.Transparent;
            btnLogOut.FillColor = Color.Transparent;
            btnFeedBack.FillColor = Color.Transparent;
            btnProfile.FillColor = Color.Transparent;
            btnReservation.FillColor = Color.Transparent;
            btnRoomServices.FillColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnOff();
        }

        private void lblUserNameDisplay_Load(object sender, EventArgs e)
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

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void lblUserDisplay_Click(object sender, EventArgs e)
        {

        }

        private void pnlTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
