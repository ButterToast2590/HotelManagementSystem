using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Npgsql;

namespace HotelManagementSystem
{
    public partial class addHighlights : Form
    {
        private string connString =
                "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
                "Port=26257;" +
                "Username=dbhotelmanagement;" +
                "Password=fdqYxIcKcPtSZV90PyNTNg;" +
                "Database=hotelmanagement;" +
                "SslMode=require;" +
                "Trust Server Certificate=true;";

        private byte[] imageBytes = null;
        public addHighlights()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "Select Highlight Photo";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    guna2PictureBox1.Image = Image.FromFile(ofd.FileName);

                    imageBytes = File.ReadAllBytes(ofd.FileName);
                }
            }
        }
        private void createRoombtn_Click(object sender, EventArgs e)
        {
            string name = txtHighlightsName.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a Highlights Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please enter a Description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (imageBytes == null)
            {
                MessageBox.Show("Please select an image.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string query = @"INSERT INTO hotel.highlights (name, description, image, status) 
                             VALUES (@name, @description, @image, 'Active')";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@image", imageBytes);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Highlight added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving highlight:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
