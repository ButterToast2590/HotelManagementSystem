using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Npgsql;

namespace HotelManagementSystem.MyControl
{
    public partial class ucRoomInfo : System.Windows.Forms.UserControl
    {
        private string connString =
            "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
            "Port=26257;" +
            "Username=dbhotelmanagement;" +
            "Password=fdqYxIcKcPtSZV90PyNTNg;" +
            "Database=hotelmanagement;" +
            "Search Path=public,hotel;" +
            "SslMode=require;" +
            "Trust Server Certificate=true;" +
            "Timeout=60;" +
            "Command Timeout=120;";

        public ucRoomInfo()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Load += ucRoomInfo_Load;
        }

        private void ucRoomInfo_Load(object sender, EventArgs e)
        {
            LoadAvailableRooms();
        }

        private void LoadAvailableRooms()
        {
            try
            {
                comboboxAvailabeRoom.Items.Clear();
                comboboxAvailabeRoom.Items.Add("Show Available room only");

                string sql = @"
                    SELECT room_id, room_number, room_type, floor_number 
                    FROM rooms 
                    WHERE status = 'Available' 
                    ORDER BY floor_number, room_number;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        RoomItem room = new RoomItem
                        {
                            RoomId = reader["room_id"].ToString(),
                            Display = $"Room {reader["room_number"]} — {reader["room_type"]} (Floor {reader["floor_number"]})"
                        };
                        comboboxAvailabeRoom.Items.Add(room);
                    }
                }

                if (comboboxAvailabeRoom.Items.Count > 1)
                    comboboxAvailabeRoom.SelectedIndex = 1;
                else
                    comboboxAvailabeRoom.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rooms: " + ex.Message);
            }
        }

        private void comboboxAvailabeRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxAvailabeRoom.SelectedItem is RoomItem selectedRoom)
            {
                LoadRoomDetails(selectedRoom.RoomId);
            }
        }

        private void LoadRoomDetails(string roomId)
        {
            try
            {
                string sql = @"
                    SELECT room_number, room_type, floor_number, max_occupancy,
                           smoking_policy, description, room_image_data
                    FROM rooms 
                    WHERE room_id = @id;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", long.Parse(roomId));
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string roomNum = reader["room_number"].ToString();
                        string roomType = reader["room_type"].ToString();
                        string floor = reader["floor_number"].ToString();

                        lblRoomNumTypeChange.Text = $"Room {roomNum}  —  {roomType}";
                        lblRoomFloor.Text = $"Floor {floor}";
                        lblBedType.Text = roomType;
                        lblOccupancy.Text = reader["max_occupancy"].ToString() + " Guests";
                        lblFloorCard.Text = "Floor " + floor;
                        lblPolicy.Text = reader["smoking_policy"].ToString();

                        guna2TextBox1.Text = reader["description"] == DBNull.Value
                            ? "No description available."
                            : reader["description"].ToString();

                        int imgOrdinal = reader.GetOrdinal("room_image_data");
                        if (!reader.IsDBNull(imgOrdinal))
                        {
                            byte[] imageBytes = (byte[])reader[imgOrdinal];
                            using (var ms = new MemoryStream(imageBytes))
                            {
                                guna2PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                                guna2PictureBox2.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            guna2PictureBox2.Image = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room details: " + ex.Message);
            }
        }

        private class RoomItem
        {
            public string RoomId { get; set; }
            public string Display { get; set; }
            public override string ToString() => Display;
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void lblBedType_Click(object sender, EventArgs e) { }
        private void lblRoomFloor_Click(object sender, EventArgs e) { }
    }
}