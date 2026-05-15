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
    public partial class ucAdminReservations : UserControl
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

        public ucAdminReservations()
        {
            InitializeComponent();
        }

        private void ucAdminReservations_Load(object sender, EventArgs e)
        {
            LoadSummaryCards();
            LoadReservationQueue();
            LoadBookingHistory();
        }

        private void LoadSummaryCards()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string pendingSql =
                        "SELECT COUNT(*) FROM hotel.bookings WHERE status = 'Pending';";
                    NpgsqlCommand pendingCmd = new NpgsqlCommand(pendingSql, conn);
                    lblApproval.Text = pendingCmd.ExecuteScalar().ToString();

                    string weekSql =
                        "SELECT COUNT(*) FROM hotel.bookings " +
                        "WHERE status = 'Approved' " +
                        "AND check_in_date >= date_trunc('week', CURRENT_DATE) " +
                        "AND check_in_date <  date_trunc('week', CURRENT_DATE) + INTERVAL '7 days';";
                    NpgsqlCommand weekCmd = new NpgsqlCommand(weekSql, conn);
                    lblWeeklyConfirmation.Text = weekCmd.ExecuteScalar().ToString();

                    string cancelSql =
                        "SELECT COUNT(*) FROM hotel.bookings WHERE status = 'Cancelled';";
                    NpgsqlCommand cancelCmd = new NpgsqlCommand(cancelSql, conn);
                    lblCancellation.Text = cancelCmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading summary: " + ex.Message);
            }
        }

        private void LoadReservationQueue()
        {
            try
            {
                queueGrid.Rows.Clear();
                string sql =
                    "SELECT b.booking_id, " +
                    "       b.first_name || ' ' || b.last_name AS guest_name, " +
                    "       r.room_number, " +
                    "       b.check_in_date, " +
                    "       b.check_out_date, " +
                    "       r.price_per_night, " +
                    "       b.status " +
                    "FROM hotel.bookings b " +
                    "JOIN rooms r ON b.room_id = r.room_id " +
                    "WHERE b.status IN ('Pending', 'Approved') " +
                    "ORDER BY b.check_in_date ASC;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime checkIn = Convert.ToDateTime(reader["check_in_date"]);
                        DateTime checkOut = Convert.ToDateTime(reader["check_out_date"]);
                        int nights = (checkOut - checkIn).Days;
                        decimal pricePerNight = Convert.ToDecimal(reader["price_per_night"]);
                        decimal totalBill = pricePerNight * nights;

                        int rowIdx = queueGrid.Rows.Add(
                            reader["booking_id"].ToString(),
                            reader["guest_name"].ToString(),
                            "Room " + reader["room_number"].ToString(),
                            checkIn.ToString("MMM dd, yyyy"),
                            checkOut.ToString("MMM dd, yyyy"),
                            "₱" + totalBill.ToString("N2"),
                            reader["status"].ToString()
                        );

                        string status = reader["status"].ToString();
                        if (status == "Pending")
                            queueGrid.Rows[rowIdx].DefaultCellStyle.BackColor = Color.LightYellow;
                        else if (status == "Approved")
                            queueGrid.Rows[rowIdx].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reservation queue: " + ex.Message);
            }
        }

        private void LoadBookingHistory()
        {
            try
            {
                bookingHistoryGrid.Rows.Clear();

                string sql =
                    "SELECT b.booking_id, " +
                    "       b.first_name || ' ' || b.last_name AS guest_name, " +
                    "       (b.adults + b.children) AS total_guests, " +
                    "       r.room_number, " +
                    "       b.check_in_date, " +
                    "       b.check_out_date, " +
                    "       b.status " +
                    "FROM hotel.bookings b " +
                    "JOIN rooms r ON b.room_id = r.room_id " +
                    "ORDER BY b.check_in_date DESC;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        bookingHistoryGrid.Rows.Add(
                            reader["booking_id"].ToString(),
                            reader["guest_name"].ToString(),
                            reader["total_guests"].ToString(),
                            "Room " + reader["room_number"].ToString(),
                            Convert.ToDateTime(reader["check_in_date"]).ToString("MMM dd, yyyy"),
                            Convert.ToDateTime(reader["check_out_date"]).ToString("MMM dd, yyyy"),
                            reader["status"].ToString()
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading booking history: " + ex.Message);
            }
        }

        private void queueGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colStatus.Index) return;

            string bookingId = queueGrid.Rows[e.RowIndex].Cells[colReservationId.Index].Value?.ToString();
            string newStatus = queueGrid.Rows[e.RowIndex].Cells[colStatus.Index].Value?.ToString();

            if (string.IsNullOrEmpty(bookingId) || string.IsNullOrEmpty(newStatus)) return;

            try
            {
                string updateSql =
                    "UPDATE hotel.bookings SET status = @status WHERE booking_id = @id;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(updateSql, conn);
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@id", long.Parse(bookingId));
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    $"Booking #{bookingId} status updated to '{newStatus}'.",
                    "Status Updated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadSummaryCards();
                LoadReservationQueue();
                LoadBookingHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message);
            }
        }

        private void queueGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (queueGrid.IsCurrentCellDirty &&
                queueGrid.CurrentCell is DataGridViewComboBoxCell)
            {
                queueGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void lblApproval_Click(object sender, EventArgs e) { }
    }
}
