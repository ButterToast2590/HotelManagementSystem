using Guna.UI2.WinForms;
using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class editMenu : Form
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
        public editMenu()
        {
            InitializeComponent();
        }

        private void editMenu_Load(object sender, EventArgs e)
        {
            LoadMenuDropdown();
        }

        private void LoadMenuDropdown()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT id, name FROM hotel.menu ORDER BY name";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);

                        cbMenu.DataSource = null;
                        cbMenu.DataSource = table;
                        cbMenu.DisplayMember = "name";
                        cbMenu.ValueMember = "id";

                        if (cbMenu.Items.Count > 0)
                            cbMenu.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu items:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMenu.SelectedValue == null) return;
            if (!Guid.TryParse(cbMenu.SelectedValue.ToString(), out Guid selectedId)) return;

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT name, price, description, image FROM hotel.menu WHERE id = @id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNewMenu.Text = reader["name"].ToString();

                                txtOldPriceShow.Text = reader["price"] == DBNull.Value
                                    ? ""
                                    : Convert.ToDecimal(reader["price"]).ToString("0.00");

                                txtNewPrice.Text = "";

                                txtDescription.Text = reader["description"] == DBNull.Value
                                    ? ""
                                    : reader["description"].ToString();

                                if (reader["image"] != DBNull.Value)
                                {
                                    imageBytes = (byte[])reader["image"];
                                    using (var ms = new MemoryStream(imageBytes))
                                    {
                                        editMenuPicture.SizeMode = PictureBoxSizeMode.Zoom;
                                        editMenuPicture.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    editMenuPicture.Image = null;
                                    imageBytes = null;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu details:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editMenuPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "Select Menu Photo";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    editMenuPicture.SizeMode = PictureBoxSizeMode.Zoom;
                    editMenuPicture.Image = Image.FromFile(ofd.FileName);
                    imageBytes = File.ReadAllBytes(ofd.FileName);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (cbMenu.SelectedValue == null)
            {
                MessageBox.Show("Please select a menu item to edit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedId = cbMenu.SelectedValue.ToString();
            string name = txtNewMenu.Text.Trim();
            string newPriceText = txtNewPrice.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a Menu Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string priceToUse = string.IsNullOrEmpty(newPriceText) ? txtOldPriceShow.Text.Trim() : newPriceText;

            if (!decimal.TryParse(priceToUse, out decimal price))
            {
                MessageBox.Show("Please enter a valid Price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string query = @"UPDATE hotel.menu 
                                     SET name        = @name, 
                                         price       = @price,
                                         description = @description, 
                                         image       = @image 
                                     WHERE id = @id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description);
                        cmd.Parameters.AddWithValue("@image", imageBytes != null ? (object)imageBytes : DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", Guid.Parse(selectedId));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Menu item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating menu item:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}