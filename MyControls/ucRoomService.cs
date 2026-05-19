using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagementSystem.MyControls
{
    public partial class ucRoomService : UserControl
    {
        private string connString =
            "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
            "Port=26257;" +
            "Username=dbhotelmanagement;" +
            "Password=fdqYxIcKcPtSZV90PyNTNg;" +
            "Database=hotelmanagement;" +
            "SslMode=require;" +
            "Trust Server Certificate=true;";

        private long currentUserId = -1;
        private long currentRoomId = -1;        // changed to long
        private int currentFloorNumber = -1;
        private string currentRoomNumber = "";  // added
        private bool hasActiveBooking = false;
        private DataTable orderTable = new DataTable();

        public ucRoomService()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;

            orderTable.Columns.Add("MenuId", typeof(Guid));
            orderTable.Columns.Add("Item", typeof(string));
            orderTable.Columns.Add("Price", typeof(decimal));
            orderTable.Columns.Add("Qty", typeof(int));
            orderTable.Columns.Add("Total", typeof(decimal));
        }

        private void ucRoomService_Load(object sender, EventArgs e)
        {
            currentUserId = UserSession.UserId1;
            CheckActiveBooking();
            LoadAvailableMenu();
            RefreshOrderGrid();
        }

        private void CheckActiveBooking()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string query = @"
                        SELECT b.room_id, r.floor_number, r.room_number
                        FROM hotel.bookings b
                        JOIN hotel.rooms r ON b.room_id = r.room_id
                        WHERE b.user_id = @userId 
                        AND b.status = 'Approved'
                        AND b.check_in_date <= (NOW() AT TIME ZONE 'Asia/Manila')::date
                        AND b.check_out_date >= (NOW() AT TIME ZONE 'Asia/Manila')::date
                        LIMIT 1";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", currentUserId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                hasActiveBooking = true;
                                currentRoomId = Convert.ToInt64(reader["room_id"]);
                                currentFloorNumber = Convert.ToInt32(reader["floor_number"]);
                                currentRoomNumber = reader["room_number"].ToString();

                                cbAutomaticRoom.Items.Clear();
                                cbAutomaticRoom.Items.Add(currentRoomNumber);
                                cbAutomaticRoom.SelectedIndex = 0;
                                cbAutomaticRoom.Enabled = false;

                                cbAutomaticFloor.Items.Clear();
                                cbAutomaticFloor.Items.Add(currentFloorNumber.ToString());
                                cbAutomaticFloor.SelectedIndex = 0;
                                cbAutomaticFloor.Enabled = false;
                            }
                            else
                            {
                                hasActiveBooking = false;

                                cbAutomaticRoom.Items.Clear();
                                cbAutomaticRoom.Items.Add("Not currently booked");
                                cbAutomaticRoom.SelectedIndex = 0;
                                cbAutomaticRoom.Enabled = false;

                                cbAutomaticFloor.Items.Clear();
                                cbAutomaticFloor.Items.Add("Not currently booked");
                                cbAutomaticFloor.SelectedIndex = 0;
                                cbAutomaticFloor.Enabled = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking booking:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAvailableMenu()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT id, name FROM hotel.menu WHERE status = 'Active' ORDER BY name";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);

                        DataRow placeholder = table.NewRow();
                        placeholder["id"] = Guid.Empty;
                        placeholder["name"] = "Available Food";
                        table.Rows.InsertAt(placeholder, 0);

                        cbAvailableMenu.DataSource = null;
                        cbAvailableMenu.DataSource = table;
                        cbAvailableMenu.DisplayMember = "name";
                        cbAvailableMenu.ValueMember = "id";
                        cbAvailableMenu.MaxDropDownItems = 15;
                        cbAvailableMenu.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbAvailableMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAvailableMenu.SelectedValue == null) return;
            if (!Guid.TryParse(cbAvailableMenu.SelectedValue.ToString(), out Guid selectedId)) return;

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string query = "SELECT name, price, description, image FROM hotel.menu WHERE id = @id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblMenu.Text = reader["name"].ToString();
                                lblPrice.Text = reader["price"] == DBNull.Value ? "—" : $"₱ {Convert.ToDecimal(reader["price"]):0.00}";
                                txtDescription.Text = reader["description"] == DBNull.Value ? "" : reader["description"].ToString();

                                if (reader["image"] != DBNull.Value)
                                {
                                    byte[] imgBytes = (byte[])reader["image"];
                                    using (var ms = new MemoryStream(imgBytes))
                                    {
                                        guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                        guna2PictureBox1.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    guna2PictureBox1.Image = null;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu details:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!hasActiveBooking)
            {
                MessageBox.Show("You must have an active booking to order room service.", "No Active Booking",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbAvailableMenu.SelectedValue == null ||
                cbAvailableMenu.SelectedValue.ToString() == Guid.Empty.ToString())
            {
                MessageBox.Show("Please select from the available menu.", "No Item Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Guid.TryParse(cbAvailableMenu.SelectedValue.ToString(), out Guid selectedId)) return;


            string menuName = lblMenu.Text;
            string priceText = lblPrice.Text.Replace("₱", "").Replace(",", "").Trim();
            if (!decimal.TryParse(priceText, out decimal price)) return;

            foreach (DataRow row in orderTable.Rows)
            {
                if ((Guid)row["MenuId"] == selectedId)
                {
                    row["Qty"] = Convert.ToInt32(row["Qty"]) + 1;
                    row["Total"] = Convert.ToInt32(row["Qty"]) * Convert.ToDecimal(row["Price"]);
                    RefreshOrderGrid();
                    return;
                }
            }

            DataRow newRow = orderTable.NewRow();
            newRow["MenuId"] = selectedId;
            newRow["Item"] = menuName;
            newRow["Price"] = price;
            newRow["Qty"] = 1;
            newRow["Total"] = price;
            orderTable.Rows.Add(newRow);
            RefreshOrderGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string menuId = dgvOrder.Rows[e.RowIndex].Tag?.ToString();
            if (string.IsNullOrEmpty(menuId)) return;

            if (e.ColumnIndex == colPlus.Index)
            {
                foreach (DataRow row in orderTable.Rows)
                {
                    if (row["MenuId"].ToString() == menuId)
                    {
                        row["Qty"] = Convert.ToInt32(row["Qty"]) + 1;
                        row["Total"] = Convert.ToInt32(row["Qty"]) * Convert.ToDecimal(row["Price"]);
                        break;
                    }
                }
            }
            else if (e.ColumnIndex == colMinus.Index)
            {
                foreach (DataRow row in orderTable.Rows)
                {
                    if (row["MenuId"].ToString() == menuId)
                    {
                        int newQty = Convert.ToInt32(row["Qty"]) - 1;

                        if (newQty <= 0)
                            orderTable.Rows.Remove(row);
                        else
                        {
                            row["Qty"] = newQty;
                            row["Total"] = newQty * Convert.ToDecimal(row["Price"]);
                        }
                        break;
                    }
                }
            }

            RefreshOrderGrid();
        }

        private void RefreshOrderGrid()
        {
            dgvOrder.Rows.Clear();

            foreach (DataRow row in orderTable.Rows)
            {
                int rowIdx = dgvOrder.Rows.Add(
                    row["Item"].ToString(),
                    "-",
                    row["Qty"].ToString(),
                    "+",
                    $"₱ {Convert.ToDecimal(row["Total"]):0.00}"
                );
                dgvOrder.Rows[rowIdx].Tag = row["MenuId"].ToString();
            }

            decimal total = 0;
            foreach (DataRow row in orderTable.Rows)
                total += Convert.ToDecimal(row["Total"]);

            lblOrderTotal.Text = $"₱{total:0.00}";
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (!hasActiveBooking)
            {
                MessageBox.Show("You must have an active booking to place a room service order.",
                    "No Active Booking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (orderTable.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one item to your order.",
                    "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    foreach (DataRow row in orderTable.Rows)
                    {
                        Guid menuId = (Guid)row["MenuId"];
                        decimal itemTotal = Convert.ToDecimal(row["Total"]);

                        string query = @"
                    INSERT INTO hotel.room_service_orders 
                        (user_id, room_id, floor_number, menu_id, status, payment_status, total_amount, created_at)
                    VALUES 
                        (@userId, @roomId, @floorNumber, @menuId, 'Pending', 'Unpaid', @totalAmount, 
                         NOW() AT TIME ZONE 'Asia/Manila')";

                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@userId", currentUserId);
                            cmd.Parameters.AddWithValue("@roomId", currentRoomId);
                            cmd.Parameters.AddWithValue("@floorNumber", currentFloorNumber);
                            cmd.Parameters.AddWithValue("@menuId", menuId);
                            cmd.Parameters.AddWithValue("@totalAmount", itemTotal);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Order placed successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                orderTable.Rows.Clear();
                txtSpecialInstructions.Text = "";
                RefreshOrderGrid();

                if (this.ParentForm is lblUserNameDisplay parentForm)
                {
                    parentForm.btnOff();
                    parentForm.btnHome.FillColor = Color.LightSkyBlue;
                    var dashboard = new HotelManagementSystem.MyControl.ucDashboard();
                    dashboard.LoggedInUserId = UserSession.UserId1;
                    parentForm.LoadContent(dashboard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error placing order:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e) { }

        private void txtDescription_TextChanged(object sender, EventArgs e) { }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void guna2PictureBox1_Click(object sender, EventArgs e) { }
    }
}