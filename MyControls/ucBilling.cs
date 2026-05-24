using Npgsql;
using System;
using System.Drawing;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

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
                        "Room Stay (" + nights + " nights at ₱" + pricePerNight.ToString("N2") + ")",
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
                DateTime checkOutDate;
                long bookingId;

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string checkSql =
                        "SELECT booking_id, check_out_date FROM hotel.bookings " +
                        "WHERE user_id = @userId " +
                        "AND status = 'Approved' " +
                        "ORDER BY check_in_date DESC LIMIT 1;";

                    NpgsqlCommand checkCmd = new NpgsqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                    NpgsqlDataReader reader = checkCmd.ExecuteReader();

                    if (!reader.Read())
                    {
                        MessageBox.Show("You have no outstanding balance to pay.", "No Balance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    bookingId = Convert.ToInt64(reader["booking_id"]);
                    checkOutDate = Convert.ToDateTime(reader["check_out_date"]);
                }

                bool isEarlyCheckOut = DateTime.Today < checkOutDate.Date;

                if (isEarlyCheckOut)
                {
                    DialogResult earlyOut = MessageBox.Show("Would you like to check out early?\n\n" +
                        "Yes — settle your bill now and check out.\n" +
                        "No  — your bill will be settled at the end of your booking. Enjoy your stay!",
                        "Early Check-Out?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (earlyOut == DialogResult.No)
                    {
                        MessageBox.Show(
                            "No problem! Your bill will be settled at the end of your booking.\n\nEnjoy your stay!","Enjoy Your Stay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DialogResult confirm = MessageBox.Show(
                        "Are you sure you want to check out early and settle your bill now?","Confirm Early Check-Out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm != DialogResult.Yes) return;
                }
                else
                {
                    MessageBox.Show("Your stay has ended. We will now process your bill.", "Bill Settlement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                    {
                        conn.Open();

                        string calcSql =
                            "SELECT GREATEST((LEAST(CURRENT_DATE, b.check_out_date::date) - b.check_in_date::date), 1) * r.price_per_night " +
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

                        string updateSql = isEarlyCheckOut
                            ? "UPDATE hotel.bookings SET check_out_date = @today, status = 'Completed', paid_at = NOW(), total_paid = @totalPaid WHERE user_id = @userId AND status = 'Approved';"
                            : "UPDATE hotel.bookings SET status = 'Completed', paid_at = NOW(), total_paid = @totalPaid WHERE user_id = @userId AND status = 'Approved';";

                        NpgsqlCommand cmd = new NpgsqlCommand(updateSql, conn);
                        cmd.Parameters.AddWithValue("@today", DateTime.Today);
                        cmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                        cmd.Parameters.AddWithValue("@totalPaid", totalPaid);
                        cmd.ExecuteNonQuery();
                    }

                    string successMsg = isEarlyCheckOut
                        ? "You have been checked out early and your bill has been settled.\n\nThank you for your stay!"
                        : "Your bill has been settled successfully.\n\nThank you for your stay!";

                    MessageBox.Show(successMsg, "Payment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBillingData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during payment: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking payment status: " + ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblStatus.Text == "No Active Booking" || dgvCharges.Rows.Count == 0)
                {
                    MessageBox.Show("You don't have an active booking to generate a receipt for.\n\nPlease make a reservation first.", "No Active Booking",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF Files|*.pdf";
                saveDialog.FileName = "HotelReceipt_" + DateTime.Today.ToString("yyyyMMdd") + ".pdf";
                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                string filePath = saveDialog.FileName;

                iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 60, 60, 60, 60);
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                iTextSharp.text.pdf.BaseFont baseFont = iTextSharp.text.pdf.BaseFont.CreateFont(fontPath, iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED);

                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font bold = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normal = new iTextSharp.text.Font(baseFont, 10);
                iTextSharp.text.Font small = new iTextSharp.text.Font(baseFont, 9);
                iTextSharp.text.Font footer = new iTextSharp.text.Font(baseFont, 9, iTextSharp.text.Font.ITALIC);

                iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Zedlink United Hotel", titleFont);
                title.SpacingAfter = 2f;
                doc.Add(title);

                iTextSharp.text.Paragraph receipt = new iTextSharp.text.Paragraph("Official Receipt", bold);
                receipt.SpacingAfter = 2f;
                doc.Add(receipt);

                iTextSharp.text.Paragraph date = new iTextSharp.text.Paragraph("Date: " + DateTime.Today.ToString("MMMM dd, yyyy"), small);
                date.SpacingAfter = 20f;
                doc.Add(date);

                iTextSharp.text.Paragraph chargesTitle = new iTextSharp.text.Paragraph("ITEMIZED CHARGES", bold);
                chargesTitle.SpacingAfter = 8f;
                doc.Add(chargesTitle);

                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;
                table.SetWidths(new int[] { 2, 4, 3, 2 });
                table.SpacingAfter = 20f;

                string[] cols = { "Date", "Description", "Category", "Amount" };
                foreach (string col in cols)
                {
                    PdfPCell hCell = new PdfPCell(new iTextSharp.text.Phrase(col, bold));
                    hCell.Padding = 6;
                    hCell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                    table.AddCell(hCell);
                }

                foreach (DataGridViewRow row in dgvCharges.Rows)
                {
                    if (row.IsNewRow) continue;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        PdfPCell pdfCell = new PdfPCell(new iTextSharp.text.Phrase(cell.Value?.ToString() ?? "", normal));
                        pdfCell.Padding = 5;
                        table.AddCell(pdfCell);
                    }
                }

                doc.Add(table);

                iTextSharp.text.Paragraph summaryTitle = new iTextSharp.text.Paragraph("BILL SUMMARY", bold);
                summaryTitle.SpacingAfter = 8f;
                doc.Add(summaryTitle);

                PdfPTable summary = new PdfPTable(2);
                summary.WidthPercentage = 50;
                summary.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                summary.SetWidths(new int[] { 3, 2 });
                summary.SpacingAfter = 20f;

                void AddRow(string label, string value, bool isBold = false)
                {
                    iTextSharp.text.Font f = isBold ? bold : normal;
                    PdfPCell left = new PdfPCell(new iTextSharp.text.Phrase(label, f)) { Border = 0, Padding = 5 };
                    PdfPCell right = new PdfPCell(new iTextSharp.text.Phrase(value, f)) { Border = 0, Padding = 5, HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT };
                    summary.AddCell(left);
                    summary.AddCell(right);
                }

                AddRow("Room Charges:", lblRoomValue.Text);
                AddRow("Food & Beverage:", lblFnBValue.Text);
                AddRow("Services:", lblServicesValue.Text);
                AddRow("Subtotal:", lblSubtotalValue.Text);
                AddRow("Tax & Service (12%):", lblTaxValue.Text);
                AddRow("TOTAL DUE:", lblTotalValue.Text, isBold: true);

                doc.Add(summary);

                iTextSharp.text.Paragraph thankYou = new iTextSharp.text.Paragraph("Thank you for your stay!", footer);
                thankYou.SpacingBefore = 10f;
                doc.Add(thankYou);

                doc.Close();

                MessageBox.Show("Receipt saved!\n" + filePath, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void lblTotalValue_Click(object sender, EventArgs e) { }
    }
}