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
            "Username=dbhotelmanagement;" +
            "Password=fdqYxIcKcPtSZV90PyNTNg;" +
            "Database=hotelmanagement;" +
            "SslMode=require;" +
            "Trust Server Certificate=true;";

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
            string user = username_txt.Text.Trim();
            string pass = passWord_txt.Text.Trim();

            string role = IsValidNamePass(user, pass);

            if (role == "Admin")
            {
                AdminDashboard adminDash = new AdminDashboard();
                adminDash.Show();
                this.Hide();
            }
            else if (role == "User")
            {
                lblUserNameDisplay userDash = new lblUserNameDisplay();
                userDash.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string IsValidNamePass(string username, string password)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string adminSql = "SELECT 'Admin' FROM hotel.admins WHERE admin_name=@user AND password=@pass";
                    using (var cmd = new NpgsqlCommand(adminSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", password);
                        object result = cmd.ExecuteScalar();
                        if (result != null) return "Admin";
                    }

                    string userSql = "SELECT 'User' FROM hotel.users WHERE username=@user AND password=@pass";
                    using (var cmd = new NpgsqlCommand(userSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", password);
                        object result = cmd.ExecuteScalar();
                        if (result != null) return "User";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
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

        private void username_txt_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
    }

}
