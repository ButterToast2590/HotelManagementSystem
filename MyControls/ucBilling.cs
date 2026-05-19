using Npgsql;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagementSystem.MyControls
{
    public partial class ucBilling : UserControl
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

        public ucBilling()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void ucBilling_Load(object sender, EventArgs e)
        {
            LoadBillingData();
        }

        private void LoadBillingData()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string bookingSql =
                        "SELECT b.booking_id, b.check_in_date, b.check_out_date, " +
                        "r.price_per_night, b.status, " +
                        "(b.check_out_date::date - b.check_in_date::date) AS nights " +
                        "FROM hotel.bookings b " +
                        "JOIN hotel.rooms r ON b.room_id = r.room_id " +
                        "WHERE b.user_id = @userId " +
                        "AND b.status = 'Approved' " +
                        "ORDER BY b.booking_id DESC LIMIT 1;";

                    NpgsqlCommand cmd = new NpgsqlCommand(bookingSql, conn);
                    cmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.Read())
                    {
                        lblRoomValue.Text = "₱0.00";
                        lblFnBValue.Text = "₱0.00";
                        lblServicesValue.Text = "₱0.00";
                        lblSubtotalValue.Text = "₱0.00";
                        lblTaxValue.Text = "₱0.00";
                        lblTotalValue.Text = "₱0.00";
                        lblStatus.Text = "No Active Booking";
                        lblStatus.ForeColor = Color.Gray;
                        btnPay.Enabled = false;
                        dgvCharges.Rows.Clear();
                        return;
                    }

                    long bookingId = Convert.ToInt64(reader["booking_id"]);
                    int nights = Convert.ToInt32(reader["nights"]);
                    if (nights <= 0) nights = 1;
                    decimal pricePerNight = Convert.ToDecimal(reader["price_per_night"]);
                    string status = reader["status"].ToString();
                    DateTime checkIn = Convert.ToDateTime(reader["check_in_date"]);
                    DateTime checkOut = Convert.ToDateTime(reader["check_out_date"]);
                    reader.Close();

                    decimal roomCharges = pricePerNight * nights;
                    decimal fnbTotal = 0;
                    decimal servicesTotal = 0;

                    dgvCharges.Rows.Clear();

                    try
                    {
                        string chargesSql =
                            "SELECT charge_date, description, category, amount " +
                            "FROM hotel.billing_charges " +
                            "WHERE booking_id = @bookingId " +
                            "ORDER BY charge_date ASC;";

                        NpgsqlCommand chargesCmd = new NpgsqlCommand(chargesSql, conn);
                        chargesCmd.Parameters.AddWithValue("@bookingId", bookingId);

                        using (NpgsqlDataReader chargesReader = chargesCmd.ExecuteReader())
                        {
                            while (chargesReader.Read())
                            {
                                string category = chargesReader["category"].ToString();
                                decimal amount = Convert.ToDecimal(chargesReader["amount"]);

                                dgvCharges.Rows.Add(
                                    Convert.ToDateTime(chargesReader["charge_date"]).ToString("MMM dd, yyyy"),
                                    chargesReader["description"].ToString(),
                                    category,
                                    "₱" + amount.ToString("N2")
                                );

                                if (category == "Food & Beverage") fnbTotal += amount;
                                else if (category == "Services") servicesTotal += amount;
                            }
                        }
                    }
                    catch { dgvCharges.Rows.Clear(); }

                    try
                    {
                        // Fixed: filter room service orders by booking date range
                        string rsSql =
                            "SELECT COALESCE(SUM(rso.total_amount), 0) " +
                            "FROM hotel.room_service_orders rso " +
                            "JOIN hotel.bookings b ON b.booking_id = @bookingId " +
                            "WHERE rso.user_id = @userId " +
                            "AND rso.room_id = b.room_id " +
                            "AND rso.created_at::date >= b.check_in_date::date " +
                            "AND rso.created_at::date <= b.check_out_date::date;";

                        NpgsqlCommand rsCmd = new NpgsqlCommand(rsSql, conn);
                        rsCmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                        rsCmd.Parameters.AddWithValue("@bookingId", bookingId);
                        decimal rsTotal = Convert.ToDecimal(rsCmd.ExecuteScalar() ?? 0);
                        fnbTotal += rsTotal;

                        if (rsTotal > 0)
                        {
                            dgvCharges.Rows.Add(
                                DateTime.Today.ToString("MMM dd, yyyy"),
                                "Room Service Orders",
                                "Food & Beverage",
                                "₱" + rsTotal.ToString("N2")
                            );
                        }
                    }
                    catch { }

                    dgvCharges.Rows.Insert(0,
                        checkIn.ToString("MMM dd, yyyy"),
                        "Room Stay (" + nights + " nights @ ₱" + pricePerNight.ToString("N2") + ")",
                        "Room",
                        "₱" + roomCharges.ToString("N2")
                    );

                    decimal subtotal = roomCharges + fnbTotal + servicesTotal;
                    decimal tax = Math.Round(subtotal * 0.12m, 2);
                    decimal total = subtotal + tax;

                    lblRoomValue.Text = "₱" + roomCharges.ToString("N2");
                    lblFnBValue.Text = "₱" + fnbTotal.ToString("N2");
                    lblServicesValue.Text = "₱" + servicesTotal.ToString("N2");
                    lblSubtotalValue.Text = "₱" + subtotal.ToString("N2");
                    lblTaxValue.Text = "₱" + tax.ToString("N2");
                    lblTotalValue.Text = "₱" + total.ToString("N2");

                    lblStatus.Text = "Unpaid";
                    lblStatus.ForeColor = Color.Red;
                    btnPay.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading billing data: " + ex.Message);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string checkSql =
                        "SELECT status FROM hotel.bookings " +
                        "WHERE user_id = @userId " +
                        "AND status = 'Approved' " +
                        "ORDER BY check_in_date DESC LIMIT 1;";

                    NpgsqlCommand checkCmd = new NpgsqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                    string currentStatus = checkCmd.ExecuteScalar()?.ToString();

                    if (string.IsNullOrEmpty(currentStatus))
                    {
                        MessageBox.Show("You have no outstanding balance to pay.", "No Balance",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking payment status: " + ex.Message);
                return;
            }

            DialogResult earlyOut = MessageBox.Show(
                "Would you like to check out early?\n\n" +
                "• Yes — settle your bill now and check out.\n" +
                "• No  — your bill will be settled at the end of your booking. Enjoy your stay!",
                "Early Check-Out?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (earlyOut == DialogResult.No)
            {
                MessageBox.Show(
                    "No problem! Your bill will be settled at the end of your booking.\n\nEnjoy your stay!",
                    "Enjoy Your Stay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to check out early and settle your bill now?",
                "Confirm Early Check-Out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    // Get booking_id first for the date range filter
                    string getBookingIdSql =
                        "SELECT booking_id FROM hotel.bookings " +
                        "WHERE user_id = @userId AND status = 'Approved' " +
                        "ORDER BY booking_id DESC LIMIT 1;";

                    NpgsqlCommand getBookingCmd = new NpgsqlCommand(getBookingIdSql, conn);
                    getBookingCmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                    long bookingId = Convert.ToInt64(getBookingCmd.ExecuteScalar() ?? 0);

                    string calcSql =
                        "SELECT GREATEST((CURRENT_DATE - b.check_in_date::date), 1) * r.price_per_night " +
                        "FROM hotel.bookings b " +
                        "JOIN hotel.rooms r ON b.room_id = r.room_id " +
                        "WHERE b.user_id = @userId AND b.status = 'Approved';";

                    NpgsqlCommand calcCmd = new NpgsqlCommand(calcSql, conn);
                    calcCmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                    decimal roomAmount = Convert.ToDecimal(calcCmd.ExecuteScalar() ?? 0);

                    decimal rsAmount = 0;
                    try
                    {
                        string rsSql =
                            "SELECT COALESCE(SUM(rso.total_amount), 0) " +
                            "FROM hotel.room_service_orders rso " +
                            "JOIN hotel.bookings b ON b.booking_id = @bookingId " +
                            "WHERE rso.user_id = @userId " +
                            "AND rso.room_id = b.room_id " +
                            "AND rso.created_at::date >= b.check_in_date::date " +
                            "AND rso.created_at::date <= b.check_out_date::date;";

                        NpgsqlCommand rsCmd = new NpgsqlCommand(rsSql, conn);
                        rsCmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                        rsCmd.Parameters.AddWithValue("@bookingId", bookingId);
                        rsAmount = Convert.ToDecimal(rsCmd.ExecuteScalar() ?? 0);
                    }
                    catch { rsAmount = 0; }

                    decimal subtotal = roomAmount + rsAmount;
                    decimal tax = Math.Round(subtotal * 0.12m, 2);
                    decimal totalPaid = subtotal + tax;

                    string sql =
                        "UPDATE hotel.bookings " +
                        "SET check_out_date = @today, status = 'Completed', " +
                        "paid_at = NOW(), total_paid = @totalPaid " +
                        "WHERE user_id = @userId AND status = 'Approved';";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@today", DateTime.Today);
                    cmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                    cmd.Parameters.AddWithValue("@totalPaid", totalPaid);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "You have been checked out and your bill has been settled.\n\nThank you for your stay!",
                    "Checked Out Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadBillingData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during early check-out: " + ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PDF download coming soon.", "Download",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void lblTotalValue_Click(object sender, EventArgs e) { }
    }
}