using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem.MyControls
{
    public partial class ucProfile : UserControl
    {
        private string connString =
        "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
        "Port=26257;" +
        "Username=dbhotelmanagement;" +
        "Password=fdqYxIcKcPtSZV90PyNTNg;" +
        "Database=hotelmanagement;" +
        "SslMode=require;" +
        "Trust Server Certificate=true;";
        public ucProfile()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }
        private void ucProfile_Load(object sender, EventArgs e)
        {
            lblName.Text = $"{UserSession.FirstName1} {UserSession.LastName1}";
            lblFullName.Left = (this.Width - lblFullName.Width) / 2;

            email1txt.Text = UserSession.Email1;
            phone1txt.Text = UserSession.Phone1;
            gendert1xt.Text = UserSession.Gender1;
            address1txt.Text = UserSession.Address1;
            birthdate1txt.Text = UserSession.BirthDate1.ToString("MMMM dd, yyyy");
            lblMemSince.Text = $"Member since {UserSession.DateJoined1.ToString("MMMM yyyy")}";

            RefreshProfileData();
        }

        public void RefreshProfileData()
        {
            lblName.Text = $"{UserSession.FirstName1} {UserSession.LastName1}";
            email1txt.Text = UserSession.Email1;
            phone1txt.Text = UserSession.Phone1;
            gendert1xt.Text = UserSession.Gender1;
            address1txt.Text = UserSession.Address1;

            lblFullName.Left = (this.Width - lblFullName.Width) / 2;
            if (UserSession.ProfilePictureData1 != null && UserSession.ProfilePictureData1.Length > 0)
            {
                try
                {
                    if (guna2CirclePictureBox4.Image != null)
                    {
                        guna2CirclePictureBox4.Image.Dispose();
                        guna2CirclePictureBox4.Image = null;
                    }

                    using (MemoryStream ms = new MemoryStream(UserSession.ProfilePictureData1))
                    {
                        guna2CirclePictureBox4.Image = new Bitmap(Image.FromStream(ms));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load profile picture: " + ex.Message);
                }
            }
            else if (!string.IsNullOrEmpty(UserSession.ProfilePicturePath1))
            {
                string fullPath = Path.Combine(Application.StartupPath, UserSession.ProfilePicturePath1);
                if (File.Exists(fullPath))
                {
                    if (guna2CirclePictureBox4.Image != null)
                    {
                        guna2CirclePictureBox4.Image.Dispose();
                        guna2CirclePictureBox4.Image = null;
                    }

                    using (var temp = Image.FromFile(fullPath))
                    {
                        guna2CirclePictureBox4.Image = new Bitmap(temp);
                    }
                }
            }

            LoadUpcomingStays();
            LoadRecentActivity();
        }
        private void LoadRecentActivity()
        {
            try
            {
                recentActivityProfileGrid.Rows.Clear();

                string sql =
                    "SELECT r.room_type, " +
                    "       (b.check_out_date::date - b.check_in_date::date) AS nights, " +
                    "       r.price_per_night * " +
                    "       (b.check_out_date::date - b.check_in_date::date) AS total_bill " +
                    "FROM hotel.bookings b " +
                    "JOIN rooms r ON b.room_id = r.room_id " +
                    "WHERE b.user_id = @userId " +
                    "ORDER BY b.check_in_date DESC;";

                using (var conn = new Npgsql.NpgsqlConnection(connString))
                {
                    conn.Open();
                    var cmd = new Npgsql.NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        recentActivityProfileGrid.Rows.Add(
                            reader["room_type"].ToString(),          
                            reader["nights"].ToString() + " night(s)",
                            "₱" + Convert.ToDecimal(reader["total_bill"]).ToString("N2")
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recent activity: " + ex.Message);
            }
        }
        private void LoadUpcomingStays()
        {
            using (var conn = new Npgsql.NpgsqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT check_in_date, check_out_date FROM hotel.bookings " +
                             "WHERE user_id = @id AND status = 'Approved' LIMIT 1";

                using (var cmd = new Npgsql.NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", UserSession.UserId1);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lbl1NoBookings.Visible = false;

                            DateTime start = reader.GetDateTime(0);
                            DateTime end = reader.GetDateTime(1);
                            List<DateTime> range = new List<DateTime>();

                            for (DateTime dt = start; dt <= end; dt = dt.AddDays(1))
                                range.Add(dt);

                            monthCalendar1.BoldedDates = range.ToArray();
                        }
                        else
                        {
                            lbl1NoBookings.Visible = true;
                            lbl1NoBookings.BringToFront();
                            monthCalendar1.BoldedDates = new DateTime[] { };
                        }
                    }
                }
            }
            monthCalendar1.UpdateBoldedDates();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Form open = Application.OpenForms["EditProfile"];

            if (open != null)
            {
                open.BringToFront();
                open.WindowState = FormWindowState.Normal;
            }
            else
            {
                new EditProfile().Show();
            }
        }




        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }
        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
