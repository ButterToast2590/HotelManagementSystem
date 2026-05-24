using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HotelManagementSystem.MyControls
{
    public partial class ucAdminRoomService : UserControl
    {
        private string connString =
            "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
            "Port=26257;" +
            "Username=dbhotelmanagement;" +
            "Password=fdqYxIcKcPtSZV90PyNTNg;" +
            "Database=hotelmanagement;" +
            "SslMode=require;" +
            "Trust Server Certificate=true;";

        public ucAdminRoomService()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void ucAdminRoomService_Load(object sender, EventArgs e)
        {
            dataGridView1.DataError += (s, ex) => { };

            while (dataGridView1.Columns.Count > 4)
                dataGridView1.Columns.RemoveAt(4);

            var statusCol = new DataGridViewComboBoxColumn();
            statusCol.Name = "colStatus";
            statusCol.HeaderText = "Status";
            statusCol.MinimumWidth = 100;
            statusCol.Width = 145;
            statusCol.FlatStyle = FlatStyle.Flat;
            statusCol.Items.AddRange("Pending", "Delivered", "Cancelled");
            dataGridView1.Columns.Add(statusCol);

            LoadOrderStats();
            LoadOrderQueue();
            LoadAvailableMenu();
        }

        private void LoadOrderStats()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(
                        "SELECT COUNT(*) FROM hotel.room_service_orders WHERE DATE(created_at) = CURRENT_DATE", conn))
                        lblTotalRoomsService.Text = cmd.ExecuteScalar()?.ToString() ?? "0";

                    using (var cmd = new NpgsqlCommand(
                        "SELECT COUNT(*) FROM hotel.room_service_orders WHERE status = 'Pending'", conn))
                        lblPendingOrders.Text = cmd.ExecuteScalar()?.ToString() ?? "0";

                    using (var cmd = new NpgsqlCommand(
                        "SELECT COUNT(*) FROM hotel.room_service_orders WHERE status = 'Delivered'", conn))
                        lblDelivered.Text = cmd.ExecuteScalar()?.ToString() ?? "0";

                    using (var cmd = new NpgsqlCommand(
                        "SELECT COUNT(*) FROM hotel.room_service_orders", conn))
                        lblTotaOrder.Text = cmd.ExecuteScalar()?.ToString() ?? "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stats:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderQueue()
        {
            try
            {
                dataGridView1.DataError += (s, ex) => { };
                dataGridView1.Rows.Clear();

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string query = @"SELECT o.order_id, r.room_number, m.name AS food_name,
                    o.total_amount, o.status 
                    FROM hotel.room_service_orders o
                    JOIN hotel.rooms r ON o.room_id = r.room_id
                    LEFT JOIN hotel.menu m ON o.menu_id = m.id
                    ORDER BY o.created_at DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string status = reader["status"] == DBNull.Value ? "Pending" : reader["status"].ToString();

                            int rowIdx = dataGridView1.Rows.Add(
                                reader["order_id"].ToString(),
                                reader["room_number"].ToString(),
                                reader["food_name"] == DBNull.Value ? "N/A" : reader["food_name"].ToString(),
                                reader["total_amount"].ToString(),
                                status
                            );

                            dataGridView1.Rows[rowIdx].Cells["colStatus"].Value = status;
                            dataGridView1.Rows[rowIdx].Tag = reader["order_id"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders:\n" + ex.Message, "Database Error",
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

                        guna2ComboBox1.DataSource = null;
                        guna2ComboBox1.DataSource = table;
                        guna2ComboBox1.DisplayMember = "name";
                        guna2ComboBox1.ValueMember = "id";

                        if (guna2ComboBox1.Items.Count > 0)
                            guna2ComboBox1.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty &&
                dataGridView1.CurrentCell is DataGridViewComboBoxCell)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["colStatus"].Index) return;

            string orderId = dataGridView1.Rows[e.RowIndex].Tag?.ToString();
            string newStatus = dataGridView1.Rows[e.RowIndex].Cells["colStatus"].Value?.ToString();

            if (string.IsNullOrEmpty(orderId) || string.IsNullOrEmpty(newStatus)) return;

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(
                        "UPDATE hotel.room_service_orders SET status = @status WHERE order_id = @orderId", conn))
                    {
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@orderId", long.Parse(orderId));
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Order status updated to '{newStatus}'.",
                    "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadOrderStats();
                LoadOrderQueue();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message);
            }
        }


        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedValue == null) return;
            if (!Guid.TryParse(guna2ComboBox1.SelectedValue.ToString(), out Guid selectedId)) return;

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
                                lblPrice.Text = reader["price"] == DBNull.Value
                                    ? "—" : $"₱ {Convert.ToDecimal(reader["price"]):0.00}";
                                txtDescription.Text = reader["description"] == DBNull.Value
                                    ? "" : reader["description"].ToString();

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

        private void createRoombtn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["addMenu"] != null || Application.OpenForms["editMenu"] != null || Application.OpenForms["DeleteMenu"] != null)
            {
                MessageBox.Show("Please close the currently open Menu window first.", "Window Already Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new addMenu().ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["addMenu"] != null || Application.OpenForms["editMenu"] != null || Application.OpenForms["DeleteMenu"] != null)
            {
                MessageBox.Show("Please close the currently open Menu window first.", "Window Already Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new editMenu().ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["addMenu"] != null || Application.OpenForms["editMenu"] != null || Application.OpenForms["DeleteMenu"] != null)
            {
                MessageBox.Show("Please close the currently open Menu window first.", "Window Already Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new DeleteMenu().ShowDialog();
        }

        private void s(object sender, EventArgs e)
        {

        }

        private void lblTotalRoomsService_Click(object sender, EventArgs e)
        {

        }
    }
}
