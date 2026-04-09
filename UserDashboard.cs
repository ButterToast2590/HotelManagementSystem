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

namespace HotelManagementSystem
{
    public partial class lblUserNameDisplay : Form
    {
        public lblUserNameDisplay()
        {
            InitializeComponent();
            lblTitle.Text = " ";
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
            lblTitle.Text = btnHighlights.Text;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            btnOff();
            btnHome.FillColor = Color.LightSkyBlue;
            lblTitle.Text = btnHome.Text;
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            btnOff();
            btnReservation.FillColor = Color.LightSkyBlue;
            lblTitle.Text = btnReservation.Text;
        }

        private void btnInOut_Click(object sender, EventArgs e)
        {
            btnOff();
            btnInOut.FillColor = Color.LightSkyBlue;
            lblTitle.Text = btnInOut.Text;
        }

        private void btnMyBill_Click(object sender, EventArgs e)
        {
            btnOff();
            btnMyBill.FillColor = Color.LightSkyBlue;
            lblTitle.Text = btnMyBill.Text;
        }

        private void btnRoomInfo_Click(object sender, EventArgs e)
        {
            btnOff();
            btnRoomInfo.FillColor = Color.LightSkyBlue;
            lblTitle.Text = btnRoomInfo.Text;
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
            lblTitle.Text = btnFeedBack.Text;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            btnOff();
            btnProfile.FillColor = Color.LightSkyBlue;
            lblTitle.Text = btnProfile.Text;
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
    }
}
