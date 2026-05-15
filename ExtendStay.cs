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
    public partial class ExtendStay : Form
    {
        private string connString =
            "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
            "Port=26257;" +
            "Username=dbhotelmanagement;" +
            "Password=fdqYxIcKcPtSZV90PyNTNg;" +
            "Database=hotelmanagement;" +
            "Search Path=public,hotel;" +
            "SslMode=require;" +
            "Trust Server Certificate=true;";
        private decimal _pricePerNight = 0;
        private DateTime _currentCheckOut;
        private long _bookingId = 0;

        public ExtendStay()
        {
            InitializeComponent();
        }
        private void ExtendStay_Load(object sender, EventArgs e)
        {
            LoadCurrentBookingInfo();

            monthCalendar1.MinDate = _currentCheckOut.AddDays(1);
            monthCalendar1.SelectionStart = _currentCheckOut.AddDays(1);
            monthCalendar1.SelectionEnd = _currentCheckOut.AddDays(1);

            UpdateEstimate();
        }
        private void LoadCurrentBookingInfo()
        {
            try
            {
                string sql =
                    "SELECT b.booking_id, b.check_out_date, r.price_per_night, " +
                    "       b.check_in_date, r.price_per_night * " +
                    "       (b.check_out_date::date - b.check_in_date::date) AS current_bill " +
                    "FROM hotel.bookings b " +
                    "JOIN rooms r ON b.room_id = r.room_id " +
                    "WHERE b.user_id = @userId " +
                    "AND b.status = 'Approved' " +
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
                        _bookingId = Convert.ToInt64(reader["booking_id"]);
                        _currentCheckOut = Convert.ToDateTime(reader["check_out_date"]);
                        _pricePerNight = Convert.ToDecimal(reader["price_per_night"]);
                        decimal currentBill = Convert.ToDecimal(reader["current_bill"]);

                        lblCurrentBal.Text = "₱" + currentBill.ToString("N2");
                        lblPerNight.Text = "₱" + _pricePerNight.ToString("N2");
                    }
                    else
                    {
                        lblCurrentBal.Text = "No active booking";
                        lblPerNight.Text = "—";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading booking info: " + ex.Message);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateEstimate();
        }

        private void UpdateEstimate()
        {
            if (_pricePerNight == 0 || _currentCheckOut == DateTime.MinValue) return;

            DateTime newCheckOut = monthCalendar1.SelectionStart;

            if (newCheckOut <= _currentCheckOut)
            {
                lblEstimated.Text = "Select a date after " + _currentCheckOut.ToString("MMM dd, yyyy");
                return;
            }

            int extraNights = (newCheckOut - _currentCheckOut).Days;
            decimal extraCost = extraNights * _pricePerNight;

            decimal currentBill = 0;
            string raw = lblCurrentBal.Text.Replace("₱", "").Replace(",", "").Trim();
            decimal.TryParse(raw, out currentBill);

            decimal totalEstimate = currentBill + extraCost;

            lblEstimated.Text = "₱" + totalEstimate.ToString("N2") + "\n" +
                               "(+" + extraNights + " night" +
                               (extraNights > 1 ? "s" : "") + ")";
        }

        private void createRoombtn_Click(object sender, EventArgs e)
        {
            if (_bookingId == 0)
            {
                MessageBox.Show("No active booking found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime newCheckOut = monthCalendar1.SelectionStart;

            if (newCheckOut <= _currentCheckOut)
            {
                MessageBox.Show(
                    "Please select a date after your current check-out: " +
                    _currentCheckOut.ToString("MMM dd, yyyy"),
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Extend stay to " + newCheckOut.ToString("MMM dd, yyyy") + "?\n" +
                "New estimated bill: " + lblEstimated.Text,
                "Confirm Extension",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                string sql =
                    "UPDATE hotel.bookings " +
                    "SET check_out_date = @newCheckOut " +
                    "WHERE booking_id = @bookingId;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@newCheckOut", newCheckOut.Date);
                    cmd.Parameters.AddWithValue("@bookingId", _bookingId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Stay extended successfully to " + newCheckOut.ToString("MMM dd, yyyy") + "!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error extending stay: " + ex.Message);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
