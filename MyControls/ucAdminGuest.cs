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
    public partial class ucAdminGuest : UserControl
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

        public ucAdminGuest()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void ucAdminGuest_Load(object sender, EventArgs e)
        {
            LoadCounters();
            LoadGuestList();
        }

        private void LoadCounters()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string sqlTotal = "SELECT COUNT(*) FROM hotel.users;";
                    NpgsqlCommand cmdTotal = new NpgsqlCommand(sqlTotal, conn);
                    long totalGuests = (long)cmdTotal.ExecuteScalar();
                    lblNumOfGuest.Text = totalGuests.ToString();

                    string sqlCheckedIn =
                        "SELECT COUNT(*) FROM hotel.bookings " +
                        "WHERE status = 'Approved';";
                    NpgsqlCommand cmdCheckedIn = new NpgsqlCommand(sqlCheckedIn, conn);
                    long checkedIn = (long)cmdCheckedIn.ExecuteScalar();
                    lblCurrentGuest.Text = checkedIn.ToString();

                    string sqlCheckingOut =
                        "SELECT COUNT(*) FROM hotel.bookings " +
                        "WHERE status = 'Approved' " +
                        "AND check_out_date::date = CURRENT_DATE;";
                    NpgsqlCommand cmdCheckingOut = new NpgsqlCommand(sqlCheckingOut, conn);
                    long checkingOut = (long)cmdCheckingOut.ExecuteScalar();
                    lblCheckingOutToday.Text = checkingOut.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading counters: " + ex.Message);
            }
        }

        private void LoadGuestList()
        {
            try
            {
                guestList.Rows.Clear();

                string sql =
                    "SELECT b.first_name || ' ' || b.last_name AS guest_name, " +
                    "       r.room_number, " +
                    "       b.check_in_date, " +
                    "       b.check_out_date, " +
                    "       b.status, " +
                    "       r.price_per_night, " +
                    "       (b.check_out_date::date - b.check_in_date::date) AS nights, " +
                    "       COALESCE((SELECT SUM(rso.total_amount) " +
                    "                 FROM hotel.room_service_orders rso " +
                    "                 WHERE rso.user_id = b.user_id " +
                    "                 AND rso.room_id = b.room_id), 0) AS service_total " +
                    "FROM hotel.bookings b " +
                    "JOIN hotel.rooms r ON b.room_id = r.room_id " +
                    "ORDER BY b.check_in_date DESC;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int nights = Convert.ToInt32(reader["nights"]);
                        if (nights <= 0) nights = 1;
                        decimal rate = Convert.ToDecimal(reader["price_per_night"]);
                        decimal serviceTotal = Convert.ToDecimal(reader["service_total"]);

                        decimal subtotal = (rate * nights) + serviceTotal;
                        decimal tax = Math.Round(subtotal * 0.12m, 2);
                        decimal bill = subtotal + tax;

                        int rowIdx = guestList.Rows.Add(
                            reader["guest_name"].ToString(),
                            "Room " + reader["room_number"].ToString(),
                            Convert.ToDateTime(reader["check_in_date"]).ToString("MMM dd, yyyy"),
                            Convert.ToDateTime(reader["check_out_date"]).ToString("MMM dd, yyyy"),
                            reader["status"].ToString(),
                            "₱" + bill.ToString("N2")
                        );

                        string status = reader["status"].ToString();
                        DateTime checkOut = Convert.ToDateTime(reader["check_out_date"]);
                        if (status == "Approved" && checkOut < DateTime.Now)
                        {
                            guestList.Rows[rowIdx].DefaultCellStyle.BackColor =
                                Color.FromArgb(255, 200, 200);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading guest list: " + ex.Message);
            }
        }

        private void lblNumOfGuest_Click(object sender, EventArgs e) { }
    }
}