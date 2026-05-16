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
using System.IO;

namespace HotelManagementSystem.MyControls
{
    public partial class ucAdminRoomControl : UserControl
    {
        private readonly string connString =
            "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
            "Port=26257;" +
            "Username=dbhotelmanagement;" +
            "Password=fdqYxIcKcPtSZV90PyNTNg;" +
            "Database=hotelmanagement;" +
            "SearchPath=public,hotel;" +
            "SslMode=require;" +
            "Trust Server Certificate=true;";

        public ucAdminRoomControl()
        {
            InitializeComponent();
            this.Load += ucAdminRoomControl_Load;
        }
        private void ucAdminRoomControl_Load(object sender, EventArgs e)
        {
            LoadStats();
            LoadRooms();
        }
        public void LoadStats()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string sql =
                        "SELECT " +
                        "  COUNT(*)                                        AS total, " +
                        "  COUNT(*) FILTER (WHERE status = 'Occupied')    AS occupied, " +
                        "  COUNT(*) FILTER (WHERE status = 'Available')   AS available, " +
                        "  COUNT(*) FILTER (WHERE status = 'Maintenance') AS maintenance " +
                        "FROM rooms;";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblTotalRooms.Text = reader["total"].ToString();
                        lbltotalRoomOccupied.Text = reader["occupied"].ToString();
                        lblTotalRoomAvailable.Text = reader["available"].ToString();
                        lblUnderMaintenance.Text = reader["maintenance"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stats: " + ex.Message);
            }
        }

        public void LoadRooms()
        {
            try
            {
                dataGridView2.Rows.Clear();
                string filter = guna2ComboBox1.Text;
                bool hasFilter = (filter != "Select Room Type" && filter != "View All Room" &&  filter != "");

                string sql =
                    "SELECT room_id, floor_number, room_number, room_type, " +
                    "       price_per_night, max_occupancy, smoking_policy, " +
                    "       room_image_url, description, status " +
                    "FROM rooms";

                if (hasFilter)
                    sql += " WHERE room_type = @roomType";
                sql += " ORDER BY floor_number, room_number;";

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                    if (hasFilter)
                        cmd.Parameters.AddWithValue("@roomType", filter);

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string roomId = reader["room_id"].ToString();
                        string floor = reader["floor_number"].ToString();
                        string roomNumber = reader["room_number"].ToString();
                        string roomType = reader["room_type"].ToString();
                        string price = Convert.ToDecimal(reader["price_per_night"]).ToString("N2");
                        string occupancy = reader["max_occupancy"].ToString();
                        string smoking = reader["smoking_policy"].ToString();
                        string description = reader["description"] == DBNull.Value ? "" : reader["description"].ToString();
                        string status = reader["status"].ToString();

                        string imageUrl = reader["room_image_url"] == DBNull.Value ? "" : reader["room_image_url"].ToString();
                        string imageStatus = string.IsNullOrEmpty(imageUrl) ? "No Image" : "Image Saved";

                        int rowIndex = dataGridView2.Rows.Add(
                            roomId, floor, roomNumber, roomType, price,
                            occupancy, smoking, imageStatus, description, status);

                        if (status == "Occupied")
                            dataGridView2.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 210, 210);
                        else if (status == "Maintenance")
                            dataGridView2.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 200);
                        else
                            dataGridView2.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rooms: " + ex.Message);
            }
        }


        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.Text == "Select Room Type")
            {
                MessageBox.Show("Please select a valid room type.");
                return;
            }
            else
            {
                LoadRooms();
            }
        }
        private void createRoombtn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CreateRoom"] != null)
            {
                Application.OpenForms["CreateRoom"].BringToFront();
                return;
            }
            if (Application.OpenForms["DeleteRoom"] != null)
            {
                MessageBox.Show("Please close the Delete Room window first.",
                    "Window Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.OpenForms["DeleteRoom"].BringToFront();
                return;
            }

            CreateRoom form = new CreateRoom();
            form.FormClosed += (s, args) =>
            {
                LoadStats();
                LoadRooms();
            };
            form.Show();
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DeleteRoom"] != null)
            {
                Application.OpenForms["DeleteRoom"].BringToFront();
                return;
            }
            if (Application.OpenForms["CreateRoom"] != null)
            {
                MessageBox.Show("Please close the Add Room window first.",
                    "Window Open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.OpenForms["CreateRoom"].BringToFront();
                return;
            }

            DeleteRoom form = new DeleteRoom();
            form.Show();
        }
        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }






        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTotalRooms_Click(object sender, EventArgs e)
        {

        }
    }
}
