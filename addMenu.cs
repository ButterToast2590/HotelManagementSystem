using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Npgsql;
namespace HotelManagementSystem
{
    public partial class addMenu : Form
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
        public addMenu()
        {
            InitializeComponent();
        }
        private void menuPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "Select Menu Photo";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    menuPicture.SizeMode = PictureBoxSizeMode.Zoom;
                    menuPicture.Image = Image.FromFile(ofd.FileName);

                    imageBytes = File.ReadAllBytes(ofd.FileName);
                }
            }
        }
        private void addMenubtn_Click(object sender, EventArgs e)
        {
            string name = txtMenuName.Text.Trim();
            string priceText = lblPrice.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a Menu Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(priceText) || !decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Please enter a valid Price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    string query = @"INSERT INTO hotel.menu (name, price, description, image, status) 
                                     VALUES (@name, @price, @description, @image, 'Active')";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@image", imageBytes);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Menu item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving menu item:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
