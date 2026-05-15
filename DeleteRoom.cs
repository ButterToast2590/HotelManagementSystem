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

namespace HotelManagementSystem
{
    public partial class DeleteRoom : Form
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

        public DeleteRoom()
        {
            InitializeComponent();
        }
        private void createRoombtn_Click(object sender, EventArgs e)
        {
            string floorInput = txtFloorNum.Text.Trim();
            string roomInput = txtRoomNum.Text.Trim();

            if (floorInput == "" || roomInput == "")
            {
                MessageBox.Show("Please enter both Floor Number and Room Number.","Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(floorInput, out int floorNumber))
            {
                MessageBox.Show("Floor Number must be a number.","Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult answer = MessageBox.Show("Are you sure you want to delete Room " + roomInput + " on Floor " + floorNumber + "?", "Confirm Delete",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes) return;

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string checkSql ="SELECT COUNT(*) FROM rooms " + "WHERE floor_number = @floor AND room_number = @roomNumber;";

                    NpgsqlCommand checkCmd = new NpgsqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@floor", floorNumber);
                    checkCmd.Parameters.AddWithValue("@roomNumber", roomInput);

                    long count = (long)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("No room found with Floor " + floorNumber + " and Room Number " + roomInput + ".", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string deleteSql = "DELETE FROM rooms " + "WHERE floor_number = @floor AND room_number = @roomNumber;";

                    NpgsqlCommand deleteCmd = new NpgsqlCommand(deleteSql, conn);
                    deleteCmd.Parameters.AddWithValue("@floor", floorNumber);
                    deleteCmd.Parameters.AddWithValue("@roomNumber", roomInput);
                    deleteCmd.ExecuteNonQuery();

                    MessageBox.Show("Room " + roomInput + " on Floor " + floorNumber + " deleted successfully.","Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting room: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
