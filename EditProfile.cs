using Guna.UI2.WinForms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class EditProfile : Form
    {
        private string newImagePath = "";
        private bool imageChanged = false;

        public EditProfile()
        {
            InitializeComponent();
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            firstNametxt.Text = UserSession.FirstName1;
            lastNametxt.Text = UserSession.LastName1;
            contactNumtxt.Text = UserSession.Phone1;
            emailAddtxt.Text = UserSession.Email1;

            if (!string.IsNullOrEmpty(UserSession.Gender1))
                guna2ComboBox1.SelectedItem = UserSession.Gender1;

            string[] addrParts = (UserSession.Address1 ?? "").Split(',');
            streettxt.Text = addrParts.Length > 0 ? addrParts[0].Trim() : "";
            barangaytxt.Text = addrParts.Length > 1 ? addrParts[1].Trim() : "";
            citytxt.Text = addrParts.Length > 2 ? addrParts[2].Trim() : "";
            if (UserSession.ProfilePictureData1 != null && UserSession.ProfilePictureData1.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(UserSession.ProfilePictureData1))
                    {
                        guna2CirclePictureBox4.Image = new Bitmap(Image.FromStream(ms));
                    }
                }
                catch { }
            }
            else if (!string.IsNullOrEmpty(UserSession.ProfilePicturePath1))
            {
                string fullPath = Path.Combine(Application.StartupPath, UserSession.ProfilePicturePath1);
                if (File.Exists(fullPath))
                {
                    using (var temp = Image.FromFile(fullPath))
                    {
                        guna2CirclePictureBox4.Image = new Bitmap(temp);
                    }
                }
            }

            imageChanged = false;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "Select Profile Photo";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = Path.Combine(Application.StartupPath, "HotelImages");
                    if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                    string fileName = "user_pic_" + DateTime.Now.Ticks.ToString() + Path.GetExtension(ofd.FileName);
                    string saveLocation = Path.Combine(folderPath, fileName);

                    File.Copy(ofd.FileName, saveLocation, true);

                    guna2CirclePictureBox4.Image = Image.FromFile(saveLocation);
                    guna2CirclePictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                    guna2CirclePictureBox4.Padding = new Padding(0);

                    System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                    gp.AddEllipse(0, 0, guna2CirclePictureBox4.Width, guna2CirclePictureBox4.Height);
                    guna2CirclePictureBox4.Region = new Region(gp);

                    newImagePath = Path.Combine("HotelImages", fileName);
                    imageChanged = true;
                }
            }
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            editProfilebtn_Click(sender, e);
        }

        private void editProfilebtn_Click(object sender, EventArgs e)
        {
            string connString = "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
                                "Port=26257;" +
                                "Username=dbhotelmanagement;" +
                                "Password=fdqYxIcKcPtSZV90PyNTNg;" +
                                "Database=hotelmanagement;" +
                                "SslMode=require;" +
                                "Trust Server Certificate=true;";
            byte[] imageBytes = null;
            if (imageChanged && guna2CirclePictureBox4.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Bitmap bmp = new Bitmap(guna2CirclePictureBox4.Image))
                    {
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageBytes = ms.ToArray();
                    }
                }
            }

            string fName = !string.IsNullOrWhiteSpace(firstNametxt.Text) ? firstNametxt.Text.Trim() : UserSession.FirstName1;
            string lName = !string.IsNullOrWhiteSpace(lastNametxt.Text) ? lastNametxt.Text.Trim() : UserSession.LastName1;
            string gender = guna2ComboBox1.SelectedIndex != -1 ? guna2ComboBox1.SelectedItem.ToString() : UserSession.Gender1;
            string phone = !string.IsNullOrWhiteSpace(contactNumtxt.Text) ? contactNumtxt.Text.Trim() : UserSession.Phone1;
            string email = !string.IsNullOrWhiteSpace(emailAddtxt.Text) ? emailAddtxt.Text.Trim() : UserSession.Email1;

            string[] addrParts = (UserSession.Address1 ?? "").Split(',');
            string street = !string.IsNullOrWhiteSpace(streettxt.Text) ? streettxt.Text.Trim() : (addrParts.Length > 0 ? addrParts[0].Trim() : "");
            string brgy = !string.IsNullOrWhiteSpace(barangaytxt.Text) ? barangaytxt.Text.Trim() : (addrParts.Length > 1 ? addrParts[1].Trim() : "");
            string city = !string.IsNullOrWhiteSpace(citytxt.Text) ? citytxt.Text.Trim() : (addrParts.Length > 2 ? addrParts[2].Trim() : "");
            string fullAddress = $"{street}, {brgy}, {city}";

            using (Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string sql;
                    if (imageChanged && imageBytes != null)
                    {
                        sql = @"UPDATE hotel.users SET 
                                first_name = @fName, last_name = @lName, gender = @gender, 
                                phone_number = @phone, email = @email, address = @addr,
                                profile_picture_data = @pic
                                WHERE user_id = @uId";
                    }
                    else
                    {
                        sql = @"UPDATE hotel.users SET 
                                first_name = @fName, last_name = @lName, gender = @gender, 
                                phone_number = @phone, email = @email, address = @addr
                                WHERE user_id = @uId";
                    }

                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@fName", fName);
                        cmd.Parameters.AddWithValue("@lName", lName);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@addr", fullAddress);
                        cmd.Parameters.AddWithValue("@uId", UserSession.UserId1);

                        if (imageChanged && imageBytes != null)
                            cmd.Parameters.AddWithValue("@pic", imageBytes);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            UserSession.FirstName1 = fName;
                            UserSession.LastName1 = lName;
                            UserSession.Gender1 = gender;
                            UserSession.Phone1 = phone;
                            UserSession.Email1 = email;
                            UserSession.Address1 = fullAddress;

                            if (imageChanged && imageBytes != null)
                            {
                                UserSession.ProfilePictureData1 = imageBytes;
                                UserSession.ProfilePicturePath1 = "";
                            }

                            Form mainForm = Application.OpenForms["lblUserNameDisplay"];
                            if (mainForm != null)
                            {
                                var profileUC = FindControlRecursive(mainForm, "ucProfile1") as MyControls.ucProfile;
                                if (profileUC != null)
                                    profileUC.RefreshProfileData();
                            }

                            MessageBox.Show("Profile Saved Successfully!", "Zedlink United");
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private Control FindControlRecursive(Control parent, string name)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.Name == name) return ctrl;
                Control found = FindControlRecursive(ctrl, name);
                if (found != null) return found;
            }
            return null;
        }
    }
}