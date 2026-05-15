using Npgsql;
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
    public partial class ucCheckInOut
    {
        private string connString =
            "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
            "Port=26257;" +
            "Username=dbhotelmanagement;" +
            "Password=fdqYxIcKcPtSZV90PyNTNg;" +
            "Database=hotelmanagement;" +
            "SearchPath=public,hotel;" +
            "SslMode=require;" +
            "Trust Server Certificate=true;";

        public ucCheckInOut()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void ucCheckInOut_Load(object sender, EventArgs e)
        {
            LoadCheckInOutData();
        }

        private void LoadCheckInOutData()
        {
            try
            {
                string sql =
                    "SELECT b.booking_id, b.first_name, b.last_name, " +
                    "       b.check_in_date, b.check_out_date, b.status, " +
                    "       r.room_number, r.floor_number, r.max_occupancy, " +
                    "       r.price_per_night " +
                    "FROM hotel.bookings b " +
                    "JOIN hotel.rooms r ON b.room_id = r.room_id " +
                    "WHERE b.user_id = @userId " +
                    "AND b.status IN ('Approved', 'Completed') " + 
                    "ORDER BY b.check_in_date DESC " +
                    "LIMIT 1;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        DateTime checkIn = Convert.ToDateTime(reader["check_in_date"]);
                        DateTime checkOut = Convert.ToDateTime(reader["check_out_date"]);
                        string status = reader["status"].ToString();

                        if (status == "Approved")
                        {
                            lblChangeBookingStats.Text = "Checked In";
                            bookingStatsContainer.FillColor = Color.MediumSeaGreen;
                            lblChangeBookingStats.ForeColor = Color.White;
                            btnExtendStay.Enabled = true;
                            btnEarlyOut.Enabled = true;

                            lblCheckInSched.Text = checkIn.ToString("MMM dd, yyyy — hh:mm tt");
                            lblCheckoutSched.Text = checkOut.ToString("MMM dd, yyyy — 12:00 PM");
                            lblAssignedRoom.Text = "Room " + reader["room_number"] +
                                                   ", Floor " + reader["floor_number"];
                            lblMaxOccupancy.Text = reader["max_occupancy"].ToString();

                            TimeSpan remaining = checkOut - DateTime.Now;
                            if (remaining.TotalSeconds > 0)
                            {
                                lblTime.Text = remaining.Days + " days, " + remaining.Hours + " hrs";
                            }
                            else
                            {
                                lblTime.Text = "Check-out overdue";
                                this.BeginInvoke(new Action(() => ShowOverduePaymentReminder()));
                            }
                        }
                        else
                        {
                            lblChangeBookingStats.Text = "Checked Out";
                            bookingStatsContainer.FillColor = Color.SteelBlue;
                            lblChangeBookingStats.ForeColor = Color.White;
                            btnExtendStay.Enabled = false;
                            btnEarlyOut.Enabled = false;

                            lblCheckInSched.Text = "—";
                            lblCheckoutSched.Text = "—";
                            lblAssignedRoom.Text = "—";
                            lblMaxOccupancy.Text = "—";
                            lblTime.Text = "—";
                        }
                    }
                    else
                    {
                        lblChangeBookingStats.Text = "Not Checked In";
                        bookingStatsContainer.FillColor = Color.LightGray;
                        lblChangeBookingStats.ForeColor = Color.DimGray;
                        lblCheckInSched.Text = "—";
                        lblCheckoutSched.Text = "—";
                        lblAssignedRoom.Text = "—";
                        lblMaxOccupancy.Text = "—";
                        lblTime.Text = "—";
                        btnExtendStay.Enabled = false;
                        btnEarlyOut.Enabled = false;
                    }

                    reader.Close();
                    LoadHistory(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading check-in data: " + ex.Message);
            }
        }

        private void LoadHistory(NpgsqlConnection conn)
        {
            try
            {
                chechINOutGrid.Rows.Clear();

                string sql =
                    "SELECT b.first_name || ' ' || b.last_name AS guest_name, " +
                    "       r.room_number, b.check_in_date, b.check_out_date, " +
                    "       b.status, r.price_per_night, " +
                    "       (b.check_out_date::date - b.check_in_date::date) AS nights " +
                    "FROM hotel.bookings b " +
                    "JOIN hotel.rooms r ON b.room_id = r.room_id " +
                    "WHERE b.user_id = @userId " +
                    "ORDER BY b.check_in_date DESC;";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int nights = Convert.ToInt32(reader["nights"]);
                    decimal rate = Convert.ToDecimal(reader["price_per_night"]);
                    decimal bill = rate * nights;
                    string status = reader["status"].ToString();

                    int rowIdx = chechINOutGrid.Rows.Add(
                        reader["guest_name"].ToString(),
                        "Room " + reader["room_number"].ToString(),
                        Convert.ToDateTime(reader["check_in_date"]).ToString("MMM dd, yyyy"),
                        Convert.ToDateTime(reader["check_out_date"]).ToString("MMM dd, yyyy"),
                        status,
                        "₱" + bill.ToString("N2")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history: " + ex.Message);
            }
        }

        private void btnExtendStay_Click(object sender, EventArgs e)
        {
            ExtendStay extendStayForm = new ExtendStay();
            extendStayForm.FormClosed += (s, args) => LoadCheckInOutData();
            extendStayForm.ShowDialog();
        }

        private void btnEarlyOut_Click_1(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to check out early?",
                "Early Check-Out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                string sql =
                    "UPDATE hotel.bookings " +
                    "SET check_out_date = @today, status = 'Completed' " +
                    "WHERE user_id = @userId AND status = 'Approved';";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@today", DateTime.Today);
                    cmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("You have been checked out. Thank you for your stay!",
                    "Checked Out", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblUserNameDisplay parentForm = this.FindForm() as lblUserNameDisplay;
                if (parentForm != null)
                {
                    parentForm.btnOff();
                    parentForm.btnMyBill.FillColor = Color.LightSkyBlue;
                    parentForm.LoadContent(new MyControls.ucBilling());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during early check-out: " + ex.Message);
            }
        }
        private void ShowOverduePaymentReminder()
        {
            MessageBox.Show(
                "Your stay has ended and you have an outstanding balance.\n\n" + "Please proceed to settle your bill before leaving.\n\n" +
                "Thank you for staying with us!", "Payment Required", MessageBoxButtons.OK, MessageBoxIcon.Warning
            );

            lblUserNameDisplay parentForm = this.FindForm() as lblUserNameDisplay;
            if (parentForm != null)
            {
                parentForm.btnOff();
                parentForm.btnMyBill.FillColor = Color.LightSkyBlue;
                parentForm.LoadContent(new MyControls.ucBilling());
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}