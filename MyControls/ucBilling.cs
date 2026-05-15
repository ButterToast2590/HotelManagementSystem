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
    public partial class ucBilling : UserControl
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
                        "       r.price_per_night, b.status, " +
                        "       (b.check_out_date::date - b.check_in_date::date) AS nights " +
                        "FROM hotel.bookings b " +
                        "JOIN hotel.rooms r ON b.room_id = r.room_id " +
                        "WHERE b.user_id = @userId " +
                        "AND b.status IN ('Approved', 'Completed') " +
                        "ORDER BY b.check_in_date DESC LIMIT 1;";

                    NpgsqlCommand cmd = new NpgsqlCommand(bookingSql, conn);
                    cmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.Read()) return;

                    long bookingId = Convert.ToInt64(reader["booking_id"]);
                    int nights = Convert.ToInt32(reader["nights"]);
                    decimal pricePerNight = Convert.ToDecimal(reader["price_per_night"]);
                    string status = reader["status"].ToString();
                    DateTime checkIn = Convert.ToDateTime(reader["check_in_date"]);
                    DateTime checkOut = Convert.ToDateTime(reader["check_out_date"]);
                    reader.Close();

                    decimal roomCharges = pricePerNight * nights;

                    decimal fnbTotal = 0;
                    decimal servicesTotal = 0;

                    string chargesSql =
                        "SELECT charge_date, description, category, amount " +
                        "FROM hotel.billing_charges " +
                        "WHERE booking_id = @bookingId " +
                        "ORDER BY charge_date ASC;";

                    NpgsqlCommand chargesCmd = new NpgsqlCommand(chargesSql, conn);
                    chargesCmd.Parameters.AddWithValue("@bookingId", (long)bookingId);
                    NpgsqlDataReader chargesReader = chargesCmd.ExecuteReader();

                    dgvCharges.Rows.Clear();

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

                    chargesReader.Close();

                    dgvCharges.Rows.Insert(0, checkIn.ToString("MMM dd, yyyy"),"Room Stay (" + nights + " nights @ ₱" + pricePerNight.ToString("N2") + ")",
                        "Room","₱" + roomCharges.ToString("N2")
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

                    if (status == "Completed")
                    {
                        lblStatus.Text = "Paid";
                        lblStatus.ForeColor = Color.SeaGreen;
                        btnPay.Enabled = false;
                    }
                    else
                    {
                        lblStatus.Text = "Unpaid";
                        lblStatus.ForeColor = Color.Red;
                        btnPay.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading billing data: " + ex.Message);
            }
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
              "Confirm payment of your outstanding balance?",
              "Confirm Payment",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string sql =
                        "UPDATE hotel.bookings SET status = 'Completed' " +
                        "WHERE user_id = @userId AND status = 'Approved';";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Payment successful! Thank you for your stay.",
                    "Payment Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadBillingData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Payment failed: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalValue_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PDF download coming soon.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
