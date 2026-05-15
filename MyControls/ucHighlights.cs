using Npgsql;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagementSystem.MyControl
{
    public partial class ucHighlights
    {
        private string connString =
                "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
                "Port=26257;" +
                "Username=dbhotelmanagement;" +
                "Password=fdqYxIcKcPtSZV90PyNTNg;" +
                "Database=hotelmanagement;" +
                "SslMode=require;" +
                "Trust Server Certificate=true;";
        public ucHighlights()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }
        private void ucHighlights_Load(object sender, EventArgs e)
        {
            LoadHighlights();
        }
        private void LoadHighlights()
        {
            try
            {
                dataGridView1.Rows.Clear();

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT id, name, description, image FROM hotel.highlights WHERE status = 'Active' ORDER BY name";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int rowIdx = dataGridView1.Rows.Add(
                                reader["name"].ToString(),
                                reader["description"].ToString()
                            );
                            dataGridView1.Rows[rowIdx].Tag = new object[]
                            {
                                reader["id"].ToString(),
                                reader.IsDBNull(reader.GetOrdinal("image")) ? null : (byte[])reader["image"]
                            };
                        }
                    }
                }

                if (dataGridView1.Rows.Count > 0)
                    dataGridView1.Rows[0].Selected = true;
                ShowDetails(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading highlights:\n" + ex.Message);
            }
        }
        private void ShowDetails(int rowIndex)
        {
            var row = dataGridView1.Rows[rowIndex];
            var tag = (object[])row.Tag;
            byte[] imageBytes = tag[1] as byte[];

            lblHighlightsName.Text = row.Cells["colLandmarkAmenities"].Value?.ToString();
            txtDescription.Text = row.Cells["colDescription"].Value?.ToString();

            if (imageBytes != null && imageBytes.Length > 0)
            {
                using (var ms = new System.IO.MemoryStream(imageBytes))
                    guna2PictureBox1.Image = Image.FromStream(ms);
            }
            else
            {
                guna2PictureBox1.Image = null;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView1.Rows[e.RowIndex].Tag == null) return;

            ShowDetails(e.RowIndex);
        }

        private void MAINpanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
