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
using HotelManagementSystem.MyControl;

namespace HotelManagementSystem.MyControl
{
    public partial class ucDashboard : UserControl
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

        private long _loggedInUserId;
        public long LoggedInUserId
        {
            get { return _loggedInUserId; }
            set
            {
                _loggedInUserId = value;
                LoadDashboard();
            }
        }

        public ucDashboard()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void ucDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            if (_loggedInUserId <= 0) return;
            LoadSummaryCards();
            LoadRecentRoomActivity();
            LoadRoomServiceActivity();
        }

        private void LoadSummaryCards()
        {
            try
            {
                string sql =
                    "SELECT b.booking_id, b.check_in_date, b.check_out_date, " +
                    "r.room_number, r.price_per_night, b.status " +
                    "FROM hotel.bookings b " +
                    "JOIN hotel.rooms r ON b.room_id = r.room_id " +
                    "WHERE b.user_id = @userId " +
                    "AND b.status IN ('Approved', 'Completed') " +
                    "ORDER BY CASE WHEN b.status = 'Approved' THEN 0 ELSE 1 END, b.booking_id DESC " +
                    "LIMIT 1;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", _loggedInUserId);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        long bookingId = Convert.ToInt64(reader["booking_id"]);
                        DateTime checkIn = Convert.ToDateTime(reader["check_in_date"]);
                        DateTime checkOut = Convert.ToDateTime(reader["check_out_date"]);
                        int nights = (checkOut - checkIn).Days;
                        if (nights <= 0) nights = 1;
                        decimal rate = Convert.ToDecimal(reader["price_per_night"]);
                        decimal roomBill = rate * nights;
                        string status = reader["status"].ToString();

                        lblCheckIn.Text = checkIn.ToString("MMM dd, yyyy");
                        lblCheckOut.Text = checkOut.ToString("MMM dd, yyyy");
                        lblRoomNum.Text = "Room " + reader["room_number"].ToString();
                        reader.Close();

                        if (status == "Completed")
                        {
                            lblCheckIn.ForeColor = Color.Gray;
                            lblCheckOut.ForeColor = Color.Gray;
                            lblRoomNum.ForeColor = Color.Gray;
                            lblCurrentBill.Text = "Paid";
                            lblCurrentBill.ForeColor = Color.SeaGreen;
                            return;
                        }

                        LoadCurrentBill(roomBill, bookingId, checkIn, checkOut);
                    }
                    else
                    {
                        lblCheckIn.Text = "—";
                        lblCheckOut.Text = "—";
                        lblRoomNum.Text = "—";
                        lblCurrentBill.Text = "—";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading summary cards: " + ex.Message);
            }
        }

        private void LoadCurrentBill(decimal roomBill, long bookingId, DateTime checkIn, DateTime checkOut)
        {
            try
            {
                long roomId = 0;
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand roomCmd = new NpgsqlCommand(
                        "SELECT room_id FROM hotel.bookings WHERE booking_id = @bookingId;", conn);
                    roomCmd.Parameters.AddWithValue("@bookingId", bookingId);
                    roomId = Convert.ToInt64(roomCmd.ExecuteScalar());
                }
                string sql =
                    "SELECT COALESCE(SUM(total_amount), 0) " +
                    "FROM hotel.room_service_orders " +
                    "WHERE user_id = @userId " +
                    "AND room_id = @roomId " +
                    "AND created_at::date >= @checkIn " +
                    "AND created_at::date <= @checkOut;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", _loggedInUserId);
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    cmd.Parameters.AddWithValue("@checkIn", checkIn);
                    cmd.Parameters.AddWithValue("@checkOut", checkOut);
                    decimal rsTotal = Convert.ToDecimal(cmd.ExecuteScalar());

                    decimal subtotal = roomBill + rsTotal;
                    decimal tax = Math.Round(subtotal * 0.12m, 2);
                    decimal totalDue = subtotal + tax;

                    lblCurrentBill.Text = "₱" + totalDue.ToString("N2");
                }
            }
            catch
            {
                decimal subtotal = roomBill;
                decimal tax = Math.Round(subtotal * 0.12m, 2);
                lblCurrentBill.Text = "₱" + (subtotal + tax).ToString("N2");
            }
        }


        private void LoadRecentRoomActivity()
        {
            try
            {
                rrGrid.Rows.Clear();

                string sql =
                    "SELECT b.first_name || ' ' || b.last_name AS guest_name, " +
                    "r.room_number, " +
                    "b.check_in_date, " +
                    "b.check_out_date, " +
                    "b.status, " +
                    "r.price_per_night " +
                    "FROM hotel.bookings b " +
                    "JOIN hotel.rooms r ON b.room_id = r.room_id " +
                    "WHERE b.user_id = @userId " +
                    "ORDER BY b.check_in_date DESC, b.booking_id DESC;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", _loggedInUserId);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime checkIn = Convert.ToDateTime(reader["check_in_date"]);
                        DateTime checkOut = Convert.ToDateTime(reader["check_out_date"]);
                        int nights = (checkOut - checkIn).Days;
                        if (nights <= 0) nights = 1;
                        decimal rate = Convert.ToDecimal(reader["price_per_night"]);
                        decimal subtotal = rate * nights;
                        decimal tax = Math.Round(subtotal * 0.12m, 2);
                        decimal bill = subtotal + tax;
                        string status = reader["status"].ToString();

                        int rowIdx = rrGrid.Rows.Add(
                            reader["guest_name"].ToString(),
                            "Room " + reader["room_number"].ToString(),
                            checkIn.ToString("MMM dd, yyyy"),
                            checkOut.ToString("MMM dd, yyyy"),
                            status,
                            "₱" + bill.ToString("N2")
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room activity: " + ex.Message);
            }
        }


        private void LoadRoomServiceActivity()
        {
            try
            {
                rsGrid.Rows.Clear();

                string sql =
                    "SELECT rso.floor_number, " +
                    "       r.room_number, " +
                    "       rso.status      AS rs_status, " +
                    "       rso.total_amount, " +
                    "       rso.created_at " +        
                    "FROM hotel.room_service_orders rso " +
                    "JOIN hotel.rooms r ON rso.room_id = r.room_id " +
                    "WHERE rso.user_id = @userId " +
                    "ORDER BY rso.created_at DESC;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", _loggedInUserId);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime orderedAt = Convert.ToDateTime(reader["created_at"]);

                        rsGrid.Rows.Add(
                            orderedAt.ToString("MMM dd, yyyy hh:mm tt"),
                            reader["floor_number"].ToString(),
                            "Room " + reader["room_number"].ToString(),
                            reader["rs_status"].ToString(),
                            "₱" + Convert.ToDecimal(reader["total_amount"]).ToString("N2")
                        );
                    }
                }
            }
            catch
            {
                // Room service table may not exist yet — silently skip
            }
        }


        private void label21_Click(object sender, EventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void label17_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label23_Click(object sender, EventArgs e)
        {

        }
        private void lblCheckIn_Click(object sender, EventArgs e)
        {

        }

        private void lblCheckIn_Click_1(object sender, EventArgs e)
        {

        }
    }
}