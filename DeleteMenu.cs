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
    public partial class DeleteMenu : Form
    {
        private string connString =
                "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
                "Port=26257;" +
                "Username=dbhotelmanagement;" +
                "Password=fdqYxIcKcPtSZV90PyNTNg;" +
                "Database=hotelmanagement;" +
                "SslMode=require;" +
                "Trust Server Certificate=true;";
        public DeleteMenu()
        {
            InitializeComponent();
        }
        private void DeleteMenu_Load(object sender, EventArgs e)
        {
            menuDelete.AutoGenerateColumns = false;
            menuDelete.EditingControlShowing += (s, ev) =>
            {
                if (ev.Control is ComboBox combo)
                    combo.DroppedDown = true;
            };
            LoadMenu();
        }
        private void LoadMenu()
        {
            try
            {
                menuDelete.Rows.Clear();

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT id, name, status FROM hotel.menu ORDER BY name";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int rowIdx = menuDelete.Rows.Add(
                                reader["name"].ToString(),
                                reader["status"].ToString()
                            );
                            menuDelete.Rows[rowIdx].Tag = reader["id"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu items:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuDelete_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colStatus.Index) return;

            string newStatus = menuDelete.Rows[e.RowIndex].Cells[colStatus.Index].Value?.ToString();
            string selectedId = menuDelete.Rows[e.RowIndex].Tag?.ToString();
            string selectedName = menuDelete.Rows[e.RowIndex].Cells[colMenu.Index].Value?.ToString();

            if (newStatus == "Delete")
            {
                DialogResult confirm = MessageBox.Show($"Are you sure you want to delete \"{selectedName}\"?","Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) { LoadMenu(); return; }

                try
                {
                    using (var conn = new NpgsqlConnection(connString))
                    {
                        conn.Open();
                        string query = "DELETE FROM hotel.menu WHERE id = @id";

                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", Guid.Parse(selectedId));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Menu item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMenu();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting menu item:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void menuDelete_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (menuDelete.IsCurrentCellDirty)
                menuDelete.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }


        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
