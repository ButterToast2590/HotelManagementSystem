using System;
using System.Data;
using System.Drawing;
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
            passWord_txt.UseSystemPasswordChar = true;
            passWord_txt.IconRight = Properties.Resources.show;
            passWord_txt.IconRightCursor = Cursors.Hand;
        }

        private void logInBtn_Click_1(object sender, EventArgs e)
        {
            string user = username_txt.Text.Trim();
            string pass = passWord_txt.Text.Trim();

            using (var conn = new Npgsql.NpgsqlConnection(connString))
            {
                conn.Open();

                string adminSql = "SELECT * FROM hotel.admins WHERE admin_name = @u AND password = @p";
                using (var cmdAdmin = new Npgsql.NpgsqlCommand(adminSql, conn))
                {
                    cmdAdmin.Parameters.AddWithValue("@u", user);
                    cmdAdmin.Parameters.AddWithValue("@p", pass);
                    using (var reader = cmdAdmin.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserSession.Username1 = reader["admin_name"].ToString();
                            new AdminDashboard().Show();
                            this.Hide();
                            return;
                        }
                    }
                }

                string userSql = @"SELECT user_id, username, first_name, last_name, email, 
                                   phone_number, gender, address, birthday, created_at,
                                   profile_picture_data
                                   FROM hotel.users 
                                   WHERE username = @u AND password = @p";

                using (var cmdUser = new Npgsql.NpgsqlCommand(userSql, conn))
                {
                    cmdUser.Parameters.AddWithValue("@u", user);
                    cmdUser.Parameters.AddWithValue("@p", pass);
                    using (var reader = cmdUser.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserSession.UserId1 = Convert.ToInt64(reader["user_id"]);
                            UserSession.Username1 = reader["username"].ToString();
                            UserSession.FirstName1 = reader["first_name"].ToString();
                            UserSession.LastName1 = reader["last_name"].ToString();
                            UserSession.Email1 = reader["email"].ToString();
                            UserSession.Phone1 = reader["phone_number"].ToString();
                            UserSession.Gender1 = reader["gender"].ToString();
                            UserSession.Address1 = reader["address"].ToString();
                            UserSession.BirthDate1 = Convert.ToDateTime(reader["birthday"]);
                            UserSession.DateJoined1 = Convert.ToDateTime(reader["created_at"]);

                            int picOrdinal = reader.GetOrdinal("profile_picture_data");
                            if (!reader.IsDBNull(picOrdinal))
                            {
                                UserSession.ProfilePictureData1 = (byte[])reader[picOrdinal];
                            }
                            else
                            {
                                UserSession.ProfilePictureData1 = null;
                            }

                            new lblUserNameDisplay().Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void passWord_txt_IconRightClick(object sender, EventArgs e)
        {
            passWord_txt.UseSystemPasswordChar = !passWord_txt.UseSystemPasswordChar;
            passWord_txt.IconRight = passWord_txt.UseSystemPasswordChar
                ? Properties.Resources.show
                : Properties.Resources.eye;
            passWord_txt.Refresh();
        }

        private void siguo_lbl_Click(object sender, EventArgs e)
        {
            SignUpForm createAccont = new SignUpForm();
            createAccont.Show();
            this.Hide();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e) { Application.Exit(); }
        private void pictureBoxMinimize_Click(object sender, EventArgs e) { this.WindowState = FormWindowState.Minimized; }
        private void pictureBoxClose_MouseHover(object sender, EventArgs e) { toolTip1.SetToolTip(pictureBoxClose, "Close"); }
        private void pictureBoxMinimize_MouseHover(object sender, EventArgs e) { toolTip1.SetToolTip(pictureBoxMinimize, "Minimize"); }
        private void copyrightMessage_Click(object sender, EventArgs e) { }
        private void username_txt_TextChanged(object sender, EventArgs e) { }
        private void logInHeader__lbl_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void passWord_txt_TextChanged(object sender, EventArgs e) { }
        private void passWord_lbl_Click(object sender, EventArgs e) { }
        private void username_txt_TextChanged_1(object sender, EventArgs e) { }
        private void guna2GroupBox1_Click(object sender, EventArgs e) { }
        private void pictureBoxEye_MouseHover(object sender, EventArgs e) { }
        private void eyeShow_Click(object sender, EventArgs e) { }
    }
}