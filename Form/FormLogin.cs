using System;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Npgsql;

namespace HotelManagementSystem
{

    public partial class logInForm : Form
    {
        private string connString =
            "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
            "Port=26257;" +
            "Username=DBHotelManagement;" +
            "Password=iMTxPnyvC50blvD2UcopKA;" +
            "Database=hotelmanagement;" +
            "SslMode=VerifyFull;";

        public logInForm()
        {
            InitializeComponent();
        }

        private void logInForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            try
            {
                picEye.BackgroundImage = null;
                picEye.SizeMode = PictureBoxSizeMode.Zoom;
                picEye.Visible = true;
                picEye.BringToFront();
                passWord_txt.UseSystemPasswordChar = true;

                if (passWord_txt != null && picEye != null)
                {
                    int margin = 15; 
                    picEye.Location = new Point(
                        passWord_txt.Right - picEye.Width - margin,
                        passWord_txt.Top + (passWord_txt.Height - picEye.Height) / 2
                    );
                    picEye.BringToFront();
                }

                if (passWord_txt != null)
                    picEye.Image = passWord_txt.UseSystemPasswordChar ? Properties.Resources.eye : Properties.Resources.show;
            }
            catch { }
        }

        private void logInBtn_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(username_txt.Text) || string.IsNullOrWhiteSpace(passWord_txt.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsValidNamePass(username_txt.Text.Trim(), passWord_txt.Text.Trim()))
            {
                lblUserNameDisplay dashboard = new lblUserNameDisplay();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool IsValidNamePass(string username, string password)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM hotel.users WHERE username=@user AND password=@pass";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        private void pictureBoxEye_MouseHover(object sender, EventArgs e)
        {
            try
            {
                if (toolTip1 == null || picEye == null || passWord_txt == null) return;
                string tip = passWord_txt.UseSystemPasswordChar ? "Show password" : "Hide password";
                toolTip1.SetToolTip(picEye, tip);
            }
            catch { }
        }

        private void eyeShow_Click(object sender, EventArgs e)
        {
            if (passWord_txt == null || picEye == null) return;
            passWord_txt.UseSystemPasswordChar = !passWord_txt.UseSystemPasswordChar;
            picEye.Image = passWord_txt.UseSystemPasswordChar ? Properties.Resources.eye : Properties.Resources.show;
            picEye.Refresh();
        }

        private void copyrightMessage_Click(object sender, EventArgs e)
        {

        }

        private void username_txt_TextChanged(object sender, EventArgs e)
        {

        }


        // Mouse Hover Section Click Functions
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxClose, "Close");
        }
        private void pictureBoxMinimize_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxMinimize, "Minimize");
        }

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void logInHeader__lbl_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void passWord_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void passWord_lbl_Click(object sender, EventArgs e)
        {

        }

        private void siguo_lbl_Click(object sender, EventArgs e)
        {
            SignUpForm createAccont = new SignUpForm();
            createAccont.Show();
            this.Hide();
        }
    }

}
