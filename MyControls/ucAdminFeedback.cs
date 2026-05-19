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
    public partial class ucAdminFeedback : UserControl
    {
        private string connString =
            "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
            "Port=26257;" +
            "Username=dbhotelmanagement;" +
            "Password=fdqYxIcKcPtSZV90PyNTNg;" +
            "Database=hotelmanagement;" +
            "SslMode=require;" +
            "Trust Server Certificate=true;";

        public ucAdminFeedback()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Load += ucAdminFeedback_Load;
        }

        private void ucAdminFeedback_Load(object sender, EventArgs e)
        {
            LoadStats();
            LoadRecentReviews();
        }

        private void LoadStats()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string totalSql = "SELECT COUNT(*) FROM hotel.feedback";
                    using (var cmd = new NpgsqlCommand(totalSql, conn))
                    {
                        long total = (long)cmd.ExecuteScalar();
                        lblTotalRev.Text = total.ToString();
                    }

                    string fiveStarSql = "SELECT COUNT(*) FROM hotel.feedback WHERE overall_experience = 5";
                    using (var cmd = new NpgsqlCommand(fiveStarSql, conn))
                    {
                        long fiveStar = (long)cmd.ExecuteScalar();
                        lblTotal5Star.Text = fiveStar.ToString();
                    }
                    string attentionSql = "SELECT COUNT(*) FROM hotel.feedback WHERE overall_experience <= 3";
                    using (var cmd = new NpgsqlCommand(attentionSql, conn))
                    {
                        long attention = (long)cmd.ExecuteScalar();
                        lblNumAttention.Text = attention.ToString();
                    }
                    string avgSql = @"SELECT 
                                        ROUND(AVG(room_cleanliness), 1),
                                        ROUND(AVG(room_service), 1),
                                        ROUND(AVG(staff_service), 1),
                                        ROUND(AVG(food_beverage), 1),
                                        ROUND(AVG(facilities_amenities), 1),
                                        ROUND(AVG(overall_experience), 1)
                                      FROM hotel.feedback";

                    using (var cmd = new NpgsqlCommand(avgSql, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                double roomClean = reader.IsDBNull(0) ? 0 : Convert.ToDouble(reader[0]);
                                double roomService = reader.IsDBNull(1) ? 0 : Convert.ToDouble(reader[1]);
                                double staff = reader.IsDBNull(2) ? 0 : Convert.ToDouble(reader[2]);
                                double food = reader.IsDBNull(3) ? 0 : Convert.ToDouble(reader[3]);
                                double amenities = reader.IsDBNull(4) ? 0 : Convert.ToDouble(reader[4]);
                                double overall = reader.IsDBNull(5) ? 0 : Convert.ToDouble(reader[5]);

                                double avgAll = (roomClean + roomService + staff + food + amenities + overall) / 6.0;
                                lblAvgRating.Text = Math.Round(avgAll, 1).ToString("0.0") + " / 5.0";

                                lblRoomNumRate.Text = roomClean.ToString("0.0") + " / 5.0";
                                lblRoomService.Text = roomService.ToString("0.0") + " / 5.0";
                                lblStaff.Text = staff.ToString("0.0") + " / 5.0";
                                lblFood.Text = food.ToString("0.0") + " / 5.0";
                                lblAmenities.Text = amenities.ToString("0.0") + " / 5.0";
                                lblOverall.Text = overall.ToString("0.0") + " / 5.0";

                                pbRoomRate.Maximum = 5;
                                pbRoomService.Maximum = 5;
                                pbStaff.Maximum = 5;
                                pbFood.Maximum = 5;
                                pbAmenities.Maximum = 5;
                                pbOverall.Maximum = 5;

                                pbRoomRate.Value = (int)Math.Round(roomClean);
                                pbRoomService.Value = (int)Math.Round(roomService);
                                pbStaff.Value = (int)Math.Round(staff);
                                pbFood.Value = (int)Math.Round(food);
                                pbAmenities.Value = (int)Math.Round(amenities);
                                pbOverall.Value = (int)Math.Round(overall);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stats: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentReviews()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string sql = @"SELECT 
                                u.first_name || ' ' || u.last_name AS guest_name,
                                'N/A' AS room_number,
                                f.comments,
                                f.created_at
                                FROM hotel.feedback f
                                JOIN hotel.users u ON f.user_id = u.user_id
                                ORDER BY f.created_at DESC
                                LIMIT 50";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            adminReviewsGrid.Rows.Clear();

                            while (reader.Read())
                            {
                                string guestName = reader.IsDBNull(0) ? "" : reader.GetString(0);
                                string roomNumber = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                                string feedback = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                DateTime date = reader.GetDateTime(3);

                                adminReviewsGrid.Rows.Add(
                                    guestName,
                                    roomNumber,
                                    feedback,
                                    date.ToString("MM/dd/yyyy")
                                );
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
        private void lblAvgRating_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }

}