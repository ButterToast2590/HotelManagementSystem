using Npgsql;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class EditRoom : Form
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

        private long selectedRoomId = -1;
        private byte[] imageBytes = null;
        private bool isLoading = false;

        public EditRoom()
        {
            InitializeComponent();
        }

        public EditRoom(string roomId)
        {
            InitializeComponent();
            selectedRoomId = long.Parse(roomId);
        }

        private void EditRoom_Load(object sender, EventArgs e)
        {
            guna2PictureBox1.Click += guna2PictureBox1_Click;
            guna2PictureBox1.Cursor = Cursors.Hand;

            selectedRoomId = -1; 

            LoadRoomNumbers(); 

            availableRoomNum.SelectedIndexChanged += availableRoomNum_SelectedIndexChanged;
        }
        private void LoadRoomNumbers()
        {
            isLoading = true;

            availableRoomNum.Items.Clear();
            availableRoomNum.Items.Add(new ComboBoxItem { Display = "Select Room", Value = "" });
            availableRoomNum.SelectedIndex = 0;

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(
                        "SELECT room_id, room_number FROM rooms ORDER BY room_number", conn))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            availableRoomNum.Items.Add(new ComboBoxItem
                            {
                                Display = "Room " + reader["room_number"].ToString(),
                                Value = reader["room_id"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rooms: " + ex.Message);
            }
            finally
            {
                isLoading = false;
            }
        }

        private void availableRoomNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (availableRoomNum.SelectedIndex <= 0) return;

            if (availableRoomNum.SelectedItem is ComboBoxItem selected &&
                !string.IsNullOrEmpty(selected.Value))
            {
                selectedRoomId = long.Parse(selected.Value);
                LoadRoomData();
            }
        }

        private void LoadRoomData()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand(
                        "SELECT floor_number, room_type, price_per_night, max_occupancy, " +
                        "smoking_policy, status, description, room_image_data " +
                        "FROM rooms WHERE room_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedRoomId);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFloorNum.Text = reader["floor_number"].ToString();
                                txtRoomPrice.Text = Convert.ToDecimal(reader["price_per_night"]).ToString("N2");
                                occupancyNum.Value = Convert.ToDecimal(reader["max_occupancy"]);
                                roomDesc.Text = reader["description"] == DBNull.Value
                                    ? "" : reader["description"].ToString();

                                comboRoomType.Text = reader["room_type"].ToString();
                                smokingPolicy.Text = reader["smoking_policy"].ToString();
                                roomStatus.Text = reader["status"].ToString();

                                if (reader["room_image_data"] != DBNull.Value)
                                {
                                    imageBytes = (byte[])reader["room_image_data"];
                                    guna2PictureBox1.Image = Image.FromStream(
                                        new MemoryStream(imageBytes));
                                }
                                else
                                {
                                    guna2PictureBox1.Image = null;
                                    imageBytes = null;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room data: " + ex.Message);
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png",
                Title = "Select Room Image"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imageBytes = File.ReadAllBytes(ofd.FileName);
                    guna2PictureBox1.Image = Image.FromStream(new MemoryStream(imageBytes));
                }
            }
        }
        private void editRoombtn_Click(object sender, EventArgs e)
        {
            if (selectedRoomId == -1)
            {
                MessageBox.Show("Please select a room first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFloorNum.Text) ||
                string.IsNullOrWhiteSpace(txtRoomPrice.Text) ||
                string.IsNullOrWhiteSpace(comboRoomType.Text) ||
                string.IsNullOrWhiteSpace(smokingPolicy.Text) ||
                string.IsNullOrWhiteSpace(roomStatus.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtFloorNum.Text, out int floor))
            {
                MessageBox.Show("Floor number must be a valid integer.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtRoomPrice.Text, out decimal price))
            {
                MessageBox.Show("Price must be a valid number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand(
                        "UPDATE rooms SET floor_number = @floor, room_type = @type, " +
                        "price_per_night = @price, max_occupancy = @occ, " +
                        "smoking_policy = @smoke, status = @status, " +
                        "description = @desc, room_image_data = @img " +
                        "WHERE room_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@floor", floor);
                        cmd.Parameters.AddWithValue("@type", comboRoomType.Text);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@occ", (int)occupancyNum.Value);
                        cmd.Parameters.AddWithValue("@smoke", smokingPolicy.Text);
                        cmd.Parameters.AddWithValue("@status", roomStatus.Text);
                        cmd.Parameters.AddWithValue("@desc",
                            string.IsNullOrWhiteSpace(roomDesc.Text)
                                ? (object)DBNull.Value : roomDesc.Text);
                        cmd.Parameters.AddWithValue("@img",
                            imageBytes != null ? (object)imageBytes : DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", selectedRoomId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Room updated successfully!", "Zedlink United",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving room: " + ex.Message);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e) =>
            this.WindowState = FormWindowState.Minimized;

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        public class ComboBoxItem
        {
            public string Display { get; set; }
            public string Value { get; set; }
            public override string ToString() => Display;
        }
    }
}