using Guna.UI2.WinForms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class editHighlights : Form
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
        public editHighlights()
        {
            InitializeComponent();
        }
        private void editHighlights_Load(object sender, EventArgs e)
        {
            LoadHighlightsDropdown();
        }
        private void LoadHighlightsDropdown()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT id, name FROM hotel.highlights ORDER BY name";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);

                        cbHighlights.DataSource = null; 
                        cbHighlights.DataSource = table;
                        cbHighlights.DisplayMember = "name";
                        cbHighlights.ValueMember = "id";

                        if (cbHighlights.Items.Count > 0)
                            cbHighlights.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading highlights:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbHighlights_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHighlights.SelectedValue == null) return;
            if (!Guid.TryParse(cbHighlights.SelectedValue.ToString(), out Guid selectedId)) return;

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT name, description, image FROM hotel.highlights WHERE id = @id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtHighlightsName.Text = reader["name"].ToString();
                                txtDescription.Text = reader["description"] == DBNull.Value ? "" : reader["description"].ToString();

                                if (reader["image"] != DBNull.Value)
                                {
                                    imageBytes = (byte[])reader["image"];
                                    using (var ms = new MemoryStream(imageBytes))
                                    {
                                        guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                        guna2PictureBox1.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    guna2PictureBox1.Image = null;
                                    imageBytes = null;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading highlight details:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (cbHighlights.SelectedValue == null)
            {
                MessageBox.Show("Please select a highlight to edit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedId = cbHighlights.SelectedValue.ToString();
            string name = txtHighlightsName.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a Highlights Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string query = @"UPDATE hotel.highlights 
                             SET name = @name, 
                                 description = @description, 
                                 image = @image 
                             WHERE id = @id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description);
                        cmd.Parameters.AddWithValue("@image", imageBytes != null ? (object)imageBytes : DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", Guid.Parse(selectedId));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Highlight updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating highlight:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
