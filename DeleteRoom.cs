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
        private bool _isLoading = false;

        private string connString =
            "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
            "Port=26257;" +
            "Username=dbhotelmanagement;" +
            "Password=fdqYxIcKcPtSZV90PyNTNg;" +
            "Database=hotelmanagement;" +
            "SslMode=require;" +
            "Trust Server Certificate=true;";

        public DeleteRoom()
        {
            InitializeComponent();
        }

        private void DeleteRoom_Load(object sender, EventArgs e)
        {
            dataGridViewRooms.AutoGenerateColumns = false;
            dataGridViewRooms.EditingControlShowing += (s, ev) =>
            {
                if (ev.Control is ComboBox combo)
                    combo.DroppedDown = true;
            };
            LoadRooms();
        }

        private void LoadRooms()
        {
            _isLoading = true;
            try
            {
                dataGridViewRooms.Rows.Clear();

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT room_id, room_number, room_type FROM hotel.rooms ORDER BY room_number";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int rowIdx = dataGridViewRooms.Rows.Add(
                                reader["room_number"].ToString(),
                                reader["room_type"].ToString(),
                                "Active"
                            );
                            dataGridViewRooms.Rows[rowIdx].Tag = reader["room_id"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rooms:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void dataGridViewRooms_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_isLoading) return;
            if (e.RowIndex < 0 || e.ColumnIndex != colStatus.Index) return;

            string newStatus = dataGridViewRooms.Rows[e.RowIndex].Cells[colStatus.Index].Value?.ToString();
            string selectedId = dataGridViewRooms.Rows[e.RowIndex].Tag?.ToString();
            string selectedRoomNumber = dataGridViewRooms.Rows[e.RowIndex].Cells[colRoomNum.Index].Value?.ToString();

            if (newStatus == "Delete")
            {
                DialogResult confirm = MessageBox.Show(
                    $"Are you sure you want to delete Room \"{selectedRoomNumber}\"?", "Confirm Delete", MessageBoxButtons.YesNo,  MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) { LoadRooms(); return; }

                try
                {
                    using (var conn = new NpgsqlConnection(connString))
                    {
                        conn.Open();
                        string query = "DELETE FROM hotel.rooms WHERE room_id = @id";

                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", long.Parse(selectedId));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Room deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRooms();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting room:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewRooms_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewRooms.IsCurrentCellDirty)
                dataGridViewRooms.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e) { }
    }
}