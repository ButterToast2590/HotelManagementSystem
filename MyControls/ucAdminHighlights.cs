using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Npgsql;

namespace HotelManagementSystem.MyControls
{
    public partial class ucAdminHighlights : UserControl
    {
        private string connString =
                        "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
                        "Port=26257;" +
                        "Username=dbhotelmanagement;" +
                        "Password=fdqYxIcKcPtSZV90PyNTNg;" +
                        "Database=hotelmanagement;" +
                        "SslMode=require;" +
                        "Trust Server Certificate=true;";

        public ucAdminHighlights()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }
        private void ucAdminHighlights_Load(object sender, EventArgs e)
        {
            LoadHighlights();
        }
        private void LoadHighlights()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT id, name, description, image FROM hotel.highlights ORDER BY name";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);

                        dataGridView1.AutoGenerateColumns = false;

                        colLandmarkAmenities.DataPropertyName = "name";
                        colDescription.DataPropertyName = "description";

                        dataGridView1.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading highlights:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var row = dataGridView1.CurrentRow;
            var dataRow = (DataRowView)row.DataBoundItem;

            lblName.Text = dataRow["name"]?.ToString() ?? "";
            tbDescription.Text = dataRow["description"]?.ToString() ?? "";

            if (dataRow["image"] != DBNull.Value && dataRow["image"] != null)
            {
                byte[] imageBytes = (byte[])dataRow["image"];
                using (var ms = new MemoryStream(imageBytes))
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

        private void btnAddHighlights_Click(object sender, EventArgs e)
        {
            using (var form = new addHighlights())
                form.ShowDialog(this.ParentForm);
            LoadHighlights();
        }

        private void btnEditHigh_Click(object sender, EventArgs e)
        {
            using (var form = new editHighlights())
                form.ShowDialog(this.ParentForm);
            LoadHighlights();
        }

        private void btnDeleteHigh_Click(object sender, EventArgs e)
        {
            using (var form = new DeleteHighlights())
                form.ShowDialog(this.ParentForm);
            LoadHighlights();
        }
    }
}