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
    public partial class DeleteHighlights : Form
    {
        private string connString =
                        "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
                        "Port=26257;" +
                        "Username=dbhotelmanagement;" +
                        "Password=fdqYxIcKcPtSZV90PyNTNg;" +
                        "Database=hotelmanagement;" +
                        "SslMode=require;" +
                        "Trust Server Certificate=true;";

        public DeleteHighlights()
        {
            InitializeComponent();
        }
        private void DeleteHighlights_Load(object sender, EventArgs e)
        {
            dataGridViewHighlights.AutoGenerateColumns = false;
            dataGridViewHighlights.EditingControlShowing += (s, ev) =>
            {
                if (ev.Control is ComboBox combo)
                    combo.DroppedDown = true;
            };
            LoadHighlights();
        }
        private void LoadHighlights()
        {
            try
            {
                dataGridViewHighlights.Rows.Clear();

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT id, name, status FROM hotel.highlights ORDER BY name";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int rowIdx = dataGridViewHighlights.Rows.Add(
                                reader["name"].ToString(),
                                reader["status"].ToString()
                            );
                            dataGridViewHighlights.Rows[rowIdx].Tag = reader["id"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading highlights:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewHighlights_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colStatus.Index) return;

            string newStatus = dataGridViewHighlights.Rows[e.RowIndex].Cells[colStatus.Index].Value?.ToString();
            string selectedId = dataGridViewHighlights.Rows[e.RowIndex].Tag?.ToString();
            string selectedName = dataGridViewHighlights.Rows[e.RowIndex].Cells[colHighlights.Index].Value?.ToString();

            if (newStatus == "Delete")
            {
                DialogResult confirm = MessageBox.Show(
                    $"Are you sure you want to delete \"{selectedName}\"?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) { LoadHighlights(); return; }

                try
                {
                    using (var conn = new NpgsqlConnection(connString))
                    {
                        conn.Open();
                        string query = "DELETE FROM hotel.highlights WHERE id = @id";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", Guid.Parse(selectedId));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Highlight deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHighlights();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting highlight:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dataGridViewHighlights_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewHighlights.IsCurrentCellDirty)
                dataGridViewHighlights.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
