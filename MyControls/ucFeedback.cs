using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace HotelManagementSystem.MyControls
{
    public partial class ucFeedback : UserControl
    {
        private string connString =
            "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
            "Port=26257;" +
            "Username=dbhotelmanagement;" +
            "Password=fdqYxIcKcPtSZV90PyNTNg;" +
            "Database=hotelmanagement;" +
            "SslMode=require;" +
            "Trust Server Certificate=true;";

        private int currentPage = 1;
        private int pageSize = 10;

        public ucFeedback()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Load += ucFeedback_Load;
        }

        private void ucFeedback_Load(object sender, EventArgs e)
        {
            LoadPreviousReviews();
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e) 
        {
            if (starCat1.Value == 0 || starCat2.Value == 0 || starCat3.Value == 0 ||
        starCat4.Value == 0 || starCat5.Value == 0 || starCat6.Value == 0)
            {
                MessageBox.Show("Please rate all categories before submitting.", "Zedlink United",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(commentBox.Text))
            {
                MessageBox.Show("Please write a comment before submitting.", "Zedlink United",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string sql = @"INSERT INTO hotel.feedback 
                                  (user_id, room_cleanliness, room_service, staff_service, 
                                   food_beverage, facilities_amenities, overall_experience, comments)
                                  VALUES 
                                  (@userId, @cat1, @cat2, @cat3, @cat4, @cat5, @cat6, @comments)";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                        cmd.Parameters.AddWithValue("@cat1", (short)starCat1.Value);
                        cmd.Parameters.AddWithValue("@cat2", (short)starCat2.Value);
                        cmd.Parameters.AddWithValue("@cat3", (short)starCat3.Value);
                        cmd.Parameters.AddWithValue("@cat4", (short)starCat4.Value);
                        cmd.Parameters.AddWithValue("@cat5", (short)starCat5.Value);
                        cmd.Parameters.AddWithValue("@cat6", (short)starCat6.Value);
                        cmd.Parameters.AddWithValue("@comments", commentBox.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thank you for your feedback!", "Zedlink United",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                starCat1.Value = 0;
                starCat2.Value = 0;
                starCat3.Value = 0;
                starCat4.Value = 0;
                starCat5.Value = 0;
                starCat6.Value = 0;
                commentBox.Text = "";

                currentPage = 1;
                LoadPreviousReviews();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving feedback: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPreviousReviews()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string sql = @"SELECT comments, overall_experience, created_at 
                                   FROM hotel.feedback 
                                   WHERE user_id = @userId
                                   ORDER BY created_at DESC
                                   LIMIT @limit OFFSET @offset";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", UserSession.UserId1);
                        cmd.Parameters.AddWithValue("@limit", pageSize);
                        cmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize);

                        using (var reader = cmd.ExecuteReader())
                        {
                            reviewsDataGridView.Rows.Clear();

                            while (reader.Read())
                            {
                                string comment = reader.IsDBNull(0) ? "" : reader.GetString(0);
                                int rating = reader.GetInt16(1);
                                DateTime date = reader.GetDateTime(2);

                                reviewsDataGridView.Rows.Add(comment, rating.ToString(), date.ToString("MM/dd/yyyy"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reviews: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblOrderTitle_Click(object sender, EventArgs e) { }
        private void lblRateTitle_Click(object sender, EventArgs e) { }
    }
}