using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelManagementSystem
{
    public partial class SignUpForm : Form
    {
        private string connString =
            "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
            "Port=26257;" +
            "Username=DBHotelManagement;" +
            "Password=iMTxPnyvC50blvD2UcopKA;" +
            "Database=hotelmanagement;" +
            "SslMode=VerifyFull;";

        public SignUpForm()
        {
            InitializeComponent();
        }
        private void submitRegistrationbtn_Click(object sender, EventArgs e)
        {

            if (!IsValidInput())
            {
                return;
            }

            string gender = "";
            if (maleRbtn.Checked) gender = "Male";
            else if (femaleRbtn.Checked) gender = "Female";
            else if (otherRbtn.Checked) gender = "Other";

            CreateUser(
                usernametxt.Text.Trim(),
                emailAddtxt.Text.Trim(),
                passwordtxt.Text.Trim(),
                contactNumtxt.Text.Trim(),
                firstNametxt.Text.Trim(),
                lastNametxt.Text.Trim(),
                addresstxt.Text.Trim(),
                birthdatePicker.Value,
                gender );

            MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            firstNametxt.Text = "";
            lastNametxt.Text = "";
            addresstxt.Text = "";
            usernametxt.Text = "";
            passwordtxt.Text = "";
            confirmPasswordtxt.Text = "";
            contactNumtxt.Text = "";
            emailAddtxt.Text = "";
            maleRbtn.Checked = false;
            femaleRbtn.Checked = false;
            otherRbtn.Checked = false;
            birthdatePicker.Value = DateTime.Now; 

            logInForm loginForm = new logInForm();
            loginForm.Show();
            this.Close();
        }
        private bool IsValidInput()
        {
            var requiredFields = new Dictionary<Guna.UI2.WinForms.Guna2TextBox, string> {

                { firstNametxt, "First Name" },
                { lastNametxt, "Last Name" },
                { addresstxt, "Address" },
                { usernametxt, "Username" },
                { passwordtxt, "Password" },
                { confirmPasswordtxt, "Confirm Password" },
                { contactNumtxt, "Contact Number" },
                { emailAddtxt, "Email Address" } };

            // Loop through each field and list the missing ones
            var errors = new List<string>();

            foreach (var field in requiredFields)
            {
                if (string.IsNullOrWhiteSpace(field.Key.Text))
                    errors.Add($"{field.Value} is required.");
            }

            if (errors.Any())
            {
                MessageBox.Show(string.Join("\n", errors), "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Birthdate check
            if (birthdatePicker.Value == null)
            {
                MessageBox.Show("Birthdate is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                birthdatePicker.Focus();
                return false;
            }

            // Password match check
            if (passwordtxt.Text != confirmPasswordtxt.Text)
            {
                MessageBox.Show("Password and Confirm Password must match.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passwordtxt.Focus();
                confirmPasswordtxt.Focus();
                return false;
            }

            if (passwordtxt.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passwordtxt.Focus();
                return false;
            }
            return true;
        }

        private void CreateUser(string username, string email, string plainPassword,
                        string contactNumber, string firstName, string lastName,
                        string address, DateTime birthday, string gender)
        {
            using (var conn = new Npgsql.NpgsqlConnection(connString))
            {
                conn.Open();

                string sql = @"INSERT INTO hotel.users 
                       (user_id, username, email, password, phone_number, gender, birthday, address, first_name, last_name) 
                       VALUES (unique_rowid(), @username, @email, @password, @phone, @gender, @birthday, @address, @firstName, @lastName)";

                using (var cmd = new Npgsql.NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", plainPassword);
                    cmd.Parameters.AddWithValue("@phone", (object)contactNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@birthday", birthday);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logInHeader_lbl_Click(object sender, EventArgs e)
        {

        }

        private void subHeader_lbl_Click(object sender, EventArgs e)
        {

        }

        private void birthdatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void logIntxt_Click(object sender, EventArgs e)
        {
            logInForm logInForm = new logInForm();
            logInForm.Show();
            this.Hide();
        }
    }
}
