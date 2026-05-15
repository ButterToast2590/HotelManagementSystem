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


namespace HotelManagementSystem.MyControl
{
    public partial class ucReservation : System.Windows.Forms.UserControl
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

        private long _loggedInUserId;
        public long LoggedInUserId
        {
            get { return _loggedInUserId; }
            set
            {
                _loggedInUserId = value;
                LoadReservationHistory();
            }
        }

        public ucReservation()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }
        private void ucReservation_Load(object sender, EventArgs e)
        {
            dateIn.MinDate = DateTime.Today;
            dateCheckOut.MinDate = DateTime.Today.AddDays(1);
            dateCheckOut.Value = DateTime.Today.AddDays(1);
        }
        private void comboRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboFloor.Items.Clear();
            comboRoom.Items.Clear();

            if (comboRoomType.Text == "Select Room Type" || comboRoomType.Text == "")
                return;
            try
            {
                string sql =
                    "SELECT DISTINCT floor_number " +
                    "FROM rooms " +
                    "WHERE room_type = @roomType " +
                    "AND status = 'Available' " +
                    "AND room_id NOT IN ( " +
                    "    SELECT b.room_id FROM hotel.bookings b " +
                    "    WHERE b.status != 'Cancelled' " +
                    "    AND b.check_in_date < @checkOut " +
                    "    AND b.check_out_date > @checkIn " +
                    ") " +
                    "ORDER BY floor_number;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@roomType", comboRoomType.Text);
                    cmd.Parameters.AddWithValue("@checkIn", dateIn.Value.Date);
                    cmd.Parameters.AddWithValue("@checkOut", dateCheckOut.Value.Date);

                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboFloor.Items.Add(reader["floor_number"].ToString());
                    }
                }

                if (comboFloor.Items.Count > 0)
                    comboFloor.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading floors: " + ex.Message);
            }
            LoadAvailableRooms();
        }

        private void comboFloorNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboRoom.Items.Clear();

            if (comboFloor.SelectedItem == null) return;
            if (comboRoomType.Text == "Select Room Type" || comboRoomType.Text == "") return;

            try
            {
                string sql =
                    "SELECT room_number " +
                    "FROM rooms " +
                    "WHERE room_type    = @roomType " +
                    "AND floor_number   = @floor " +
                    "AND status         = 'Available' " +
                    "AND room_id NOT IN ( " +
                    "    SELECT b.room_id FROM hotel.bookings b " +
                    "    WHERE b.status != 'Cancelled' " +
                    "    AND b.check_in_date < @checkOut " +
                    "    AND b.check_out_date > @checkIn " +
                    ") " +
                    "ORDER BY room_number;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@roomType", comboRoomType.Text);
                    cmd.Parameters.AddWithValue("@floor", int.Parse(comboFloor.SelectedItem.ToString()));
                    cmd.Parameters.AddWithValue("@checkIn", dateIn.Value.Date);
                    cmd.Parameters.AddWithValue("@checkOut", dateCheckOut.Value.Date);

                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboRoom.Items.Add(reader["room_number"].ToString());
                    }
                }

                if (comboRoom.Items.Count > 0)
                    comboRoom.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room numbers: " + ex.Message);
            }
        }

        private void dateIn_ValueChanged(object sender, EventArgs e)
        {
            dateCheckOut.MinDate = dateIn.Value.AddDays(1);
            dateCheckOut.Value = dateIn.Value.AddDays(1);

            comboRoomType_SelectedIndexChanged(sender, e);
        }

        private void dateCheckOut_ValueChanged(object sender, EventArgs e)
        {
            comboRoomType_SelectedIndexChanged(sender, e);
        }

        private void LoadAvailableRooms()
        {
            try
            {
                dataGridViewRoomAvail.Rows.Clear();

                if (comboRoomType.Text == "Select Room Type" || comboRoomType.Text == "")
                    return;

                string sql =
                    "SELECT r.room_id, r.floor_number, r.room_number, " +
                    "r.price_per_night, r.max_occupancy " +
                    "FROM rooms r " +
                    "WHERE r.room_type = @roomType " +
                    "AND r.status = 'Available' " +
                    "AND r.room_id NOT IN ( " +
                    "    SELECT b.room_id FROM hotel.bookings b " +
                    "    WHERE b.status != 'Cancelled' " +
                    "    AND b.check_in_date < @checkOut " +
                    "    AND b.check_out_date > @checkIn " +
                    ") " +
                    "ORDER BY r.floor_number, r.room_number;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@roomType", comboRoomType.Text);
                    cmd.Parameters.AddWithValue("@checkIn", dateIn.Value.Date);
                    cmd.Parameters.AddWithValue("@checkOut", dateCheckOut.Value.Date);

                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int nights = (dateCheckOut.Value.Date - dateIn.Value.Date).Days;
                        decimal pricePerNight = Convert.ToDecimal(reader["price_per_night"]);
                        decimal totalPrice = pricePerNight * nights;

                        dataGridViewRoomAvail.Rows.Add(
                            reader["room_id"].ToString(),         
                            reader["floor_number"].ToString(),     
                            "Room " + reader["room_number"].ToString(),
                            "₱" + totalPrice.ToString("N2"),              
                            reader["max_occupancy"].ToString()      
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading available rooms: " + ex.Message);
            }
        }

        private void LoadReservationHistory()
        {
            if (LoggedInUserId <= 0) return;
            try
            {
                dataGridViewHistory.Rows.Clear();
                string sql =
                    "SELECT u.first_name, u.last_name, " +
                    "res.check_in_date, res.check_out_date, r.room_type, res.status " +
                    "FROM hotel.bookings res " +
                    "JOIN hotel.rooms r ON res.room_id = r.room_id " + 
                    "JOIN hotel.users u ON res.user_id = u.user_id " +
                    "WHERE res.user_id = @userId " +
                    "ORDER BY res.check_in_date DESC;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", LoggedInUserId);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string status = reader["status"].ToString();

                        int rowIdx = dataGridViewHistory.Rows.Add(
                            reader["first_name"] + " " + reader["last_name"],
                            Convert.ToDateTime(reader["check_in_date"]).ToString("MMM dd, yyyy"),
                            Convert.ToDateTime(reader["check_out_date"]).ToString("MMM dd, yyyy"),
                            reader["room_type"].ToString(),
                            status
                        );

                        DataGridViewRow row = dataGridViewHistory.Rows[rowIdx];
                        switch (status)
                        {
                            case "Pending":
                                row.DefaultCellStyle.BackColor = Color.LightYellow;
                                row.DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                                break;
                            case "Approved":
                                row.DefaultCellStyle.BackColor = Color.LightGreen;
                                row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                                break;
                            case "Cancelled":
                                row.DefaultCellStyle.BackColor = Color.LightCoral;
                                row.DefaultCellStyle.ForeColor = Color.DarkRed;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history: " + ex.Message);
            }
        }

        private void submitRegistrationbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string checkSql =
                            "SELECT COUNT(*) FROM hotel.bookings " +
                            "WHERE user_id = @userId " +
                            "AND status IN ('Pending', 'Approved');";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand checkCmd = new NpgsqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@userId", LoggedInUserId);

                    int activeCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (activeCount > 0)
                    {
                        MessageBox.Show(
                            "You already have an active reservation.\n" +"Please wait for it to be cancelled before making a new one.",
                            "Active Reservation Found",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking reservation status: " + ex.Message);
                return;
            }

            if (txtFirstname.Text.Trim() == "")
            { MessageBox.Show("Please enter your First Name."); return; }

            if (txtLastname.Text.Trim() == "")
            { MessageBox.Show("Please enter your Last Name."); return; }

            if (txtContactNum.Text.Trim() == "")
            { MessageBox.Show("Please enter your Contact Number."); return; }

            if (comboRoomType.Text == "Select Room Type" || comboRoomType.Text == "")
            { MessageBox.Show("Please select a Room Type."); return; }

            if (comboFloor.SelectedItem == null)
            { MessageBox.Show("Please select a Floor Number."); return; }

            if (comboRoom.SelectedItem == null)
            { MessageBox.Show("Please select a Room Number."); return; }

            if (dateCheckOut.Value.Date <= dateIn.Value.Date)
            { MessageBox.Show("Check-Out date must be after Check-In date."); return; }

            int totalGuests = (int)numberAdults.Value + (int)numberChildren.Value;
            if (totalGuests == 0)
            { MessageBox.Show("Please enter at least 1 guest (Adults + Children)."); return; }

            string selectedRoomNumber = comboRoom.SelectedItem.ToString();
            int selectedFloor = int.Parse(comboFloor.SelectedItem.ToString());
            long roomId = 0;
            int maxOccupancy = 0;

            try
            {
                string getRoomSql =
                    "SELECT room_id, max_occupancy FROM rooms " +
                    "WHERE room_number = @roomNumber AND floor_number = @floor;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(getRoomSql, conn);
                    cmd.Parameters.AddWithValue("@roomNumber", selectedRoomNumber);
                    cmd.Parameters.AddWithValue("@floor", selectedFloor);

                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        roomId = Convert.ToInt64(reader["room_id"]);
                        maxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
                    }
                }

                if (totalGuests > maxOccupancy)
                {
                    MessageBox.Show(
                        "Total guests (" + totalGuests + ") exceeds the max occupancy of this room (" + maxOccupancy + ").\n" +
                        "Please reduce guests or choose a different room.", "Occupancy Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string insertSql =
                    "INSERT INTO hotel.bookings " +
                    "  (user_id, room_id, first_name, last_name, contact_number, " +
                    "   check_in_date, check_out_date, adults, children, special_request, status) " +
                    "VALUES " +
                    "  (@userId, @roomId, @firstName, @lastName, @contact, " +
                    "   @checkIn, @checkOut, @adults, @children, @request, 'Pending');";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(insertSql, conn);
                    cmd.Parameters.AddWithValue("@userId", LoggedInUserId);
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    cmd.Parameters.AddWithValue("@firstName", txtFirstname.Text.Trim());
                    cmd.Parameters.AddWithValue("@lastName", txtLastname.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact", txtContactNum.Text.Trim());
                    cmd.Parameters.AddWithValue("@checkIn", dateIn.Value.Date);
                    cmd.Parameters.AddWithValue("@checkOut", dateCheckOut.Value.Date);
                    cmd.Parameters.AddWithValue("@adults", (int)numberAdults.Value);
                    cmd.Parameters.AddWithValue("@children", (int)numberChildren.Value);
                    cmd.Parameters.AddWithValue("@request",
                    guna2TextBox1.Text.Trim() == "" ? (object)DBNull.Value : guna2TextBox1.Text.Trim());

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Reservation submitted successfully!", "Success",MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtFirstname.Text = "";
                txtLastname.Text = "";
                txtContactNum.Text = "";
                guna2TextBox1.Text = "";
                numberAdults.Value = 0;
                numberChildren.Value = 0;
                comboRoomType.SelectedIndex = 0;

                LoadReservationHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving reservation: " + ex.Message);
            }
        }

        private void btnGoToRoomDetails_Click(object sender, EventArgs e)
        {
            lblUserNameDisplay parentForm = this.FindForm() as lblUserNameDisplay;
            if (parentForm != null)
            {
                parentForm.btnOff();                    
                parentForm.btnRoomInfo.FillColor = Color.LightSkyBlue; 
                parentForm.LoadContent(new ucRoomInfo());
            }
        }

        private void label4_Click(object sender, EventArgs e) { }
        private void layoutCountryRegion_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtLastname_TextChanged(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label21_Click(object sender, EventArgs e) { }
        private void lblRequests_Click(object sender, EventArgs e) { }
        private void txtContactInfo_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void numberAdults_ValueChanged(object sender, EventArgs e) { }
        private void layoutAdults_Paint(object sender, PaintEventArgs e) { }
        private void layoutChildren_Paint(object sender, PaintEventArgs e) { }
    }
}