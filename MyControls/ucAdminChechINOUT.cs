using Npgsql;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagementSystem.MyControls
{
    public partial class ucAdminChechINOUT : UserControl
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
        public ucAdminChechINOUT()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void ucAdminChechINOUT_Load(object sender, EventArgs e)
        {
            filterCB.Items.Clear();
            filterCB.Items.Add("All");
            filterCB.Items.Add("Approved");
            filterCB.Items.Add("Completed");
            filterCB.Items.Add("Pending");
            filterCB.Items.Add("Cancelled");
            filterCB.SelectedIndex = 0;
            filterCB.SelectedIndexChanged += FilterCB_SelectedIndexChanged;

            LoadCounters();
            LoadActiveGuests();
            LoadUpcomingGuests();
            LoadLog("All");
        }

        private void LoadCounters()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string sqlIn = "SELECT COUNT(*) FROM hotel.bookings WHERE status = 'Approved';";
                    NpgsqlCommand cmdIn = new NpgsqlCommand(sqlIn, conn);
                    long checkedInCount = (long)cmdIn.ExecuteScalar();
                    lblCheckIn.Text = checkedInCount.ToString();

                    string sqlOut =
                        "SELECT COUNT(*) FROM hotel.bookings " +
                        "WHERE status = 'Approved' AND check_out_date::date <= CURRENT_DATE;";
                    NpgsqlCommand cmdOut = new NpgsqlCommand(sqlOut, conn);
                    long checkedOutCount = (long)cmdOut.ExecuteScalar();
                    lblCheckOut.Text = checkedOutCount.ToString();

                    string sqlOverdue =
                        "SELECT COUNT(*) FROM hotel.bookings " +
                        "WHERE status = 'Approved' AND check_out_date < NOW();";
                    NpgsqlCommand cmdOverdue = new NpgsqlCommand(sqlOverdue, conn);
                    long overdueCount = (long)cmdOverdue.ExecuteScalar();
                    lblNumofUserOverDue.Text = overdueCount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading counters: " + ex.Message);
            }
        }

        private void LoadActiveGuests()
        {
            try
            {
                activeguestGrid.Rows.Clear();

                string sql =
                    "SELECT b.booking_id, " +
                    "       b.first_name || ' ' || b.last_name AS guest_name, " +
                    "       r.room_number, " +
                    "       b.check_out_date " +
                    "FROM hotel.bookings b " +
                    "JOIN hotel.rooms r ON b.room_id = r.room_id " +
                    "WHERE b.status = 'Approved' " +
                    "ORDER BY b.check_out_date ASC;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime checkOutDate = Convert.ToDateTime(reader["check_out_date"]);
                        bool isOverdue = checkOutDate < DateTime.Now;

                        int rowIndex = activeguestGrid.Rows.Add(
                            reader["guest_name"].ToString(),            
                            "Room " + reader["room_number"].ToString(),  
                            checkOutDate.ToString("MMM dd, yyyy"),
                            "Check-Out"
                        );

                        if (isOverdue)
                        {
                            activeguestGrid.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200); 
                        }

                        activeguestGrid.Rows[rowIndex].Tag = reader["booking_id"];
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading active guests: " + ex.Message);
            }
        }
        private void LoadUpcomingGuests()
        {
            try
            {
                upcomingGrid.Rows.Clear();

                string sql =
                    "SELECT b.first_name || ' ' || b.last_name AS guest_name, " +
                    "       r.room_number, " +
                    "       b.status " +
                    "FROM hotel.bookings b " +
                    "JOIN hotel.rooms r ON b.room_id = r.room_id " +
                    "WHERE b.status IN ('Pending', 'Approved') " +
                    "  AND b.check_in_date::date >= CURRENT_DATE " +
                    "ORDER BY b.check_in_date ASC " +
                    "LIMIT 50;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        upcomingGrid.Rows.Add(
                            reader["guest_name"].ToString(),            
                            "Room " + reader["room_number"].ToString(), 
                            reader["status"].ToString()                
                        );
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading upcoming guests: " + ex.Message);
            }
        }
        private void LoadLog(string statusFilter)
        {
            try
            {
                overallLogGrid.Rows.Clear();

                string sql;

                if (statusFilter == "All")
                {
                    sql =
                        "SELECT CASE WHEN b.status = 'Completed' THEN b.check_out_date ELSE b.check_in_date END AS timestamp, " +
                        "b.first_name || ' ' || b.last_name AS guest_name, " +
                        "r.room_number, " +
                        "b.status, " +
                        "b.processed_by " +
                        "FROM hotel.bookings b " +
                        "JOIN hotel.rooms r ON b.room_id = r.room_id " +
                        "ORDER BY b.check_in_date DESC " +
                        "LIMIT 200;";
                }
                else
                {
                    sql =
                        "SELECT CASE WHEN b.status = 'Completed' THEN b.check_out_date ELSE b.check_in_date END AS timestamp, " +
                        "b.first_name || ' ' || b.last_name AS guest_name, " +
                        "r.room_number, " +
                        "b.status, " +
                        "b.processed_by " +
                        "FROM hotel.bookings b " +
                        "JOIN hotel.rooms r ON b.room_id = r.room_id " +
                        "WHERE b.status = @status " +
                        "ORDER BY b.check_in_date DESC " +
                        "LIMIT 200;";
                }

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    if (statusFilter != "All")
                    {
                        cmd.Parameters.AddWithValue("@status", statusFilter);
                    }

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime ts = Convert.ToDateTime(reader["timestamp"]);

                        overallLogGrid.Rows.Add(
                            ts.ToString("MMM dd, yyyy hh:mm tt"),
                            reader["guest_name"].ToString(),
                            "Room " + reader["room_number"],
                            reader["status"].ToString(),
                            reader["processed_by"].ToString()
                        );
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading log: " + ex.Message);
            }
        }

        private void FilterCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = filterCB.SelectedItem?.ToString() ?? "All";
            LoadLog(selected);
        }
        private void activeguestGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex != activeguestGrid.Columns["colAction"].Index) return;

            string guestName = activeguestGrid.Rows[e.RowIndex].Cells["colActiveGuest"].Value?.ToString();
            int bookingId = Convert.ToInt32(activeguestGrid.Rows[e.RowIndex].Tag);

            DialogResult answer = MessageBox.Show("Are you sure you want to check out " + guestName + "?", "Confirm Check-Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes) return;

            try
            {
                string sql =
                    "UPDATE hotel.bookings " +
                    "SET check_out_date = @today, status = 'Completed' " +
                    "WHERE booking_id = @bookingId AND status = 'Approved';";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@today", DateTime.Now);
                    cmd.Parameters.AddWithValue("@bookingId", bookingId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(guestName + " has been checked out successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCounters();
                LoadActiveGuests();
                LoadLog(filterCB.SelectedItem?.ToString() ?? "All");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check-out failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblCheckIn_Click(object sender, EventArgs e)
        {

        }
    }
}