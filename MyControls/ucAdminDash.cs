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

namespace HotelManagementSystem.MyControls
{
    public partial class ucAdminDash : UserControl
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
        public ucAdminDash()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }
        private void ucAdminDash_Load(object sender, EventArgs e)
        {
            LoadTotalGuests();
            LoadRoomOccupied();
            LoadRevenueToday();
            LoadPendingOrders();
            LoadCheckInOutHistory();
            LoadRoomOccupancyByFloor();
        }
        private void LoadTotalGuests()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM hotel.users;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    long count = (long)cmd.ExecuteScalar();
                    lblTotalGuest.Text = count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading total guests: " + ex.Message);
            }
        }
        private void LoadRoomOccupied()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(DISTINCT room_id) FROM hotel.bookings WHERE status = 'Approved';";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    long count = (long)cmd.ExecuteScalar();
                    lbltotalRoomOccupied.Text = count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room occupied: " + ex.Message);
            }
        }
        private void LoadRevenueToday()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string sql =
                        "SELECT COALESCE(SUM(total_paid), 0) " +
                        "FROM hotel.bookings " +
                        "WHERE status = 'Completed';";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    decimal revenue = Convert.ToDecimal(cmd.ExecuteScalar());
                    lblTotalRevenue.Text = "₱" + revenue.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading revenue: " + ex.Message);
            }
        }
        private void LoadPendingOrders()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string sql =
                        "SELECT COUNT(*) FROM hotel.room_service_orders " +
                        "WHERE status = 'Pending';";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    long count = (long)cmd.ExecuteScalar();
                    lblTotalNumOrder.Text = count.ToString();
                }
            }
            catch
            {
                lblTotalNumOrder.Text = "0";
            }
        }
        private void LoadCheckInOutHistory()
        {
            try
            {
                dataGridView1.Rows.Clear();

                string sql =
                    "SELECT b.first_name || ' ' || b.last_name AS client_name, " +
                    "       r.room_number, " +
                    "       r.room_type, " +
                    "       b.status " +
                    "FROM hotel.bookings b " +
                    "JOIN hotel.rooms r ON b.room_id = r.room_id " +
                    "WHERE b.status IN ('Approved', 'Completed') " + 
                    "ORDER BY b.check_in_date DESC " +
                    "LIMIT 10;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader["client_name"].ToString(),
                            "Room " + reader["room_number"].ToString(),
                            reader["room_type"].ToString(),
                            reader["status"].ToString()
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading check-in/out history: " + ex.Message);
            }
        }
        private void LoadRoomOccupancyByFloor()
        {
            try
            {
                dataGridView2.Rows.Clear();

                string sql =
                    "SELECT r.floor_number, " +
                    "       COUNT(r.room_id) AS total_rooms, " +
                    "       COUNT(r.room_id) - COUNT(b.booking_id) AS available_rooms " +
                    "FROM hotel.rooms r " +
                    "LEFT JOIN hotel.bookings b " +
                    "       ON r.room_id = b.room_id AND b.status = 'Approved' " +
                    "GROUP BY r.floor_number " +
                    "ORDER BY r.floor_number ASC;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dataGridView2.Rows.Add(
                            "Floor " + reader["floor_number"].ToString(),
                            reader["total_rooms"].ToString(),
                            reader["available_rooms"].ToString()
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room occupancy: " + ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotalGuest_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalRevenue_Click(object sender, EventArgs e)
        {

        }
    }
}
