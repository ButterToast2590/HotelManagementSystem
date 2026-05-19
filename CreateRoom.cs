using Npgsql;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class CreateRoom : Form
    {
        private byte[] roomImageBytes = null;

        private string connString =
            "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
            "Port=26257;" +
            "Username=dbhotelmanagement;" +
            "Password=fdqYxIcKcPtSZV90PyNTNg;" +
            "Database=hotelmanagement;" +
            "SearchPath=public,hotel;" +
            "SslMode=require;" +
            "Trust Server Certificate=true;";

        public CreateRoom()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "Select Room Photo";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    roomImageBytes = File.ReadAllBytes(ofd.FileName);
                    guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    guna2PictureBox1.Image = Image.FromStream(new MemoryStream(roomImageBytes));
                }
            }
        }

        private void createRoombtn_Click(object sender, EventArgs e)
        {
            if (!FormIsValid())
                return;

            try
            {
                int floorNumber = int.Parse(txtFloorNum.Text.Trim());
                string roomNumber = txtRoomNum.Text.Trim();
                string roomType = comboRoomType.Text;
                string status = roomStatus.Text;
                decimal pricePerNight = decimal.Parse(txtRoomPrice.Text.Trim());
                int maxOccupancy = (int)occupancyNum.Value;
                string smokingPolicy = this.smokingPolicy.Text;
                string description = roomDesc.Text.Trim();

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string sql =
                        "INSERT INTO rooms " +
                        "  (floor_number, room_number, room_type, price_per_night, " +
                        "   max_occupancy, smoking_policy, room_image_data, description, status) " +
                        "VALUES " +
                        "  (@floor, @roomNumber, @roomType, @price, " +
                        "   @occupancy, @smoking, @imageData, @description, @status) " +
                        "RETURNING room_id;";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@floor", floorNumber);
                        cmd.Parameters.AddWithValue("@roomNumber", roomNumber);
                        cmd.Parameters.AddWithValue("@roomType", roomType);
                        cmd.Parameters.AddWithValue("@price", pricePerNight);
                        cmd.Parameters.AddWithValue("@occupancy", maxOccupancy);
                        cmd.Parameters.AddWithValue("@smoking", smokingPolicy);
                        cmd.Parameters.AddWithValue("@imageData", roomImageBytes != null ? (object)roomImageBytes : DBNull.Value);
                        cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description);
                        cmd.Parameters.AddWithValue("@status", status);

                        cmd.ExecuteScalar();
                    }
                }

                MessageBox.Show("Room " + roomNumber + " created successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (PostgresException pgEx) when (pgEx.SqlState == "23505")
            {
                MessageBox.Show("That room number already exists. Please use a different one.",
                    "Duplicate Room Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating room: " + ex.Message);
            }
        }

        private bool FormIsValid()
        {
            if (!int.TryParse(txtFloorNum.Text.Trim(), out _))
            {
                MessageBox.Show("Please enter a valid Floor Number (numbers only).");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRoomNum.Text))
            {
                MessageBox.Show("Please enter a Room Number.");
                return false;
            }

            string[] validRoomTypes = { "Single", "Double", "Twin", "Triple", "Suite", "Deluxe", "Executive" };
            string[] validStatuses = { "Available", "Occupied", "Maintenance" };

            if (!validRoomTypes.Contains(comboRoomType.Text))
            {
                MessageBox.Show("Please select a valid Room Type.");
                return false;
            }

            if (!validStatuses.Contains(roomStatus.Text))
            {
                MessageBox.Show("Please select a valid Room Status.");
                return false;
            }

            if (!decimal.TryParse(txtRoomPrice.Text.Trim(), out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid Price Per Night (e.g. 1500).");
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void btnMinimize_Click(object sender, EventArgs e) =>
            this.WindowState = FormWindowState.Minimized;

        private void guna2Panel10_Paint(object sender, PaintEventArgs e) { }
        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e) { }
        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e) { }
        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e) { }
        private void roomDesc_TextChanged(object sender, EventArgs e) { }
        private void lblChildren_Click(object sender, EventArgs e) { }
        private void layoutChildren_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }
        private void comboRoomType_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}