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
    public partial class ucAdminBilling : UserControl
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

        public ucAdminBilling()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }
        private void ucAdminBilling_Load(object sender, EventArgs e)
        {
            LoadCounters();
            LoadGuestBills("Filter By Status");
        }
        private void LoadCounters()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string sqlToday =
                        "SELECT COALESCE(SUM(total_paid), 0) " +
                        "FROM hotel.bookings " +
                        "WHERE status = 'Completed' " +
                        "AND paid_at::date = CURRENT_DATE;";
                    NpgsqlCommand cmdToday = new NpgsqlCommand(sqlToday, conn);
                    decimal revenueToday = Convert.ToDecimal(cmdToday.ExecuteScalar());
                    lblEstimatedRevToday.Text = "₱" + revenueToday.ToString("N2");

                    string sqlPending =
                        "SELECT COUNT(*) FROM hotel.bookings " + "WHERE status = 'Approved';";
                    NpgsqlCommand cmdPending = new NpgsqlCommand(sqlPending, conn);
                    long pending = (long)cmdPending.ExecuteScalar();
                    lblPending.Text = pending.ToString();

                    string sqlCompleted =
                        "SELECT COUNT(*) FROM hotel.bookings " + "WHERE status = 'Completed' " +
                        "AND check_out_date::date = CURRENT_DATE;";
                    NpgsqlCommand cmdCompleted = new NpgsqlCommand(sqlCompleted, conn);
                    long completed = (long)cmdCompleted.ExecuteScalar();
                    lblCompleted.Text = completed.ToString();

                    string sqlTotal =
                        "SELECT COALESCE(SUM(total_paid), 0) " +
                        "FROM hotel.bookings " +
                        "WHERE status = 'Completed';";
                    NpgsqlCommand cmdTotal = new NpgsqlCommand(sqlTotal, conn);
                    decimal totalEarning = Convert.ToDecimal(cmdTotal.ExecuteScalar());
                    lblTotalEarning.Text = "₱" + totalEarning.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading counters: " + ex.Message);
            }
        }
        private void LoadGuestBills(string filter)
        {
            try
            {
                guestListGrid.Rows.Clear();

                string statusFilter = "";
                if (filter == "Paid") statusFilter = "AND b.status = 'Completed'";
                else if (filter == "Unpaid") statusFilter = "AND b.status = 'Approved'";

                string sql =
                  "SELECT b.first_name || ' ' || b.last_name AS guest_name, " +
                  "r.room_number, " +
                  "GREATEST((b.check_out_date::date - b.check_in_date::date), 1) * r.price_per_night AS room_charge, " +
                  "COALESCE((SELECT SUM(rso.total_amount) FROM hotel.room_service_orders rso WHERE rso.room_id = b.room_id AND rso.user_id = b.user_id), 0) AS service_charge, " +
                  "COALESCE(b.total_paid, 0) AS total_paid, " +
                  "b.status " +
                  "FROM hotel.bookings b " +
                  "JOIN hotel.rooms r ON b.room_id = r.room_id " +
                  "WHERE b.status IN ('Approved', 'Completed') " +
                  statusFilter +
                  " ORDER BY b.check_in_date DESC;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        decimal roomCharge = Convert.ToDecimal(reader["room_charge"]);
                        decimal serviceCharge = Convert.ToDecimal(reader["service_charge"]);
                        decimal subtotal = roomCharge + serviceCharge;         
                        decimal tax = Math.Round(subtotal * 0.12m, 2);         
                        decimal total = subtotal + tax;                         
                        string status = reader["status"].ToString();
                        string displayStatus = status == "Completed" ? "Paid" : "Unpaid";

                        int rowIdx = guestListGrid.Rows.Add(
                            reader["guest_name"].ToString(),
                            "Room " + reader["room_number"].ToString(),
                            "₱" + roomCharge.ToString("N2"),
                            "₱" + serviceCharge.ToString("N2"),
                            "₱" + total.ToString("N2"),      
                            displayStatus
                        );

                        if (status == "Approved")
                        {
                            guestListGrid.Rows[rowIdx].DefaultCellStyle.ForeColor = Color.Red;
                        }
                        else
                        {
                            guestListGrid.Rows[rowIdx].DefaultCellStyle.ForeColor = Color.SeaGreen;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading guest bills: " + ex.Message);
            }
        }
        private void StatusCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = statusCombo.SelectedItem?.ToString() ?? "Filter By Status";
            LoadGuestBills(selected);
        }
        private void lblTotalRooms_Click(object sender, EventArgs e)
        {
                
        }
    }
}
