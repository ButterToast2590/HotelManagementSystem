using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class SignUpForm : Form
    {
        private string connString =
            "Host=dbhotel-14349.jxf.gcp-us-west2.cockroachlabs.cloud;" +
            "Port=26257;" +
            "Username=DBHotelManagement;" +
            "Password=fdqYxIcKcPtSZV90PyNTNg;" +
            "Database=hotelmanagement;" +
            "SslMode=VerifyFull;";

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            DateTime legalDate = DateTime.Today.AddYears(-18);
            birthdatePicker.Value = legalDate;
            birthdatePicker.MaxDate = legalDate;

            InitializePasswordfield(passwordtxt);
            InitializePasswordfield(confirmPasswordtxt);

            contactNumtxt.KeyPress += contactNumtxt_KeyPress;
        }

        private void InitializePasswordfield(Guna.UI2.WinForms.Guna2TextBox txt)
        {
            txt.UseSystemPasswordChar = true;
            txt.IconRight = Properties.Resources.show;
            txt.IconRightCursor = Cursors.Hand;
        }

        private void passwordtxt_IconRightClick(object sender, EventArgs e) {
            ToggleGunaPassword(passwordtxt);
        }
        private void confirmPasswordtxt_IconRightClick(object sender, EventArgs e) {
            ToggleGunaPassword(confirmPasswordtxt);
        }

        private void ToggleGunaPassword(Guna.UI2.WinForms.Guna2TextBox txt)
        {
            txt.UseSystemPasswordChar = !txt.UseSystemPasswordChar;
            txt.IconRight = txt.UseSystemPasswordChar ? Properties.Resources.show : Properties.Resources.eye;
            txt.Refresh();
        }

        private void submitRegistrationbtn_Click(object sender, EventArgs e)
        {
            if (!IsValidInput()) return;
            DialogResult confirm = MessageBox.Show( "Your username cannot be changed after registration.\n\n" + "Username: " + usernametxt.Text.Trim() + "\n\n" +
                "Do you want to continue with this username?", "Confirm Username", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            string gender = maleRbtn.Checked ? "Male" : femaleRbtn.Checked ? "Female" : "Other";
            string fullAddress = $"{streettxt.Text.Trim()}, {barangaytxt.Text.Trim()}, {citytxt.Text.Trim()}";

            CreateUser(
                usernametxt.Text.Trim(),
                emailAddtxt.Text.Trim(),
                passwordtxt.Text.Trim(),
                contactNumtxt.Text.Trim(),
                firstNametxt.Text.Trim(),
                lastNametxt.Text.Trim(),
                fullAddress,
                birthdatePicker.Value,
                gender);

            MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearFields();

            logInForm login = new logInForm();
            login.Show();
            this.Close();
        }

        private bool DoesUsernameExist(string username)
        {
            using (var conn = new Npgsql.NpgsqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM hotel.users WHERE username = @u";

                using (var cmd = new Npgsql.NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void ClearFields()
        {
            firstNametxt.Text = lastNametxt.Text = citytxt.Text = streettxt.Text =
            barangaytxt.Text = usernametxt.Text = passwordtxt.Text =
            confirmPasswordtxt.Text = contactNumtxt.Text = emailAddtxt.Text = "";
            maleRbtn.Checked = femaleRbtn.Checked = otherRbtn.Checked = false;
            birthdatePicker.Value = DateTime.Now;

            DateTime legalDate = DateTime.Today.AddYears(-18);
            birthdatePicker.Value = legalDate;

            maleRbtn.Checked = false;
            femaleRbtn.Checked = false;
            otherRbtn.Checked = false;
        }

        private bool IsValidInput()
        {
            if (IsAnyFieldEmpty())
            {
                MessageBox.Show("Please fill in all required text fields before submitting.","Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (passwordtxt.Text.Length < 8)
            {
                MessageBox.Show("For your security, passwords must be at least 8 characters.","Password Too Short", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passwordtxt.Focus();
                return false;
            }

            if (passwordtxt.Text != confirmPasswordtxt.Text)
            {
                MessageBox.Show("The passwords you entered do not match. Please try again.", "Typo Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                confirmPasswordtxt.Focus();
                return false;
            }

            DateTime birthDate = birthdatePicker.Value;
            DateTime minAgeDate = DateTime.Today.AddYears(-18);

            if (birthDate > minAgeDate)
            {
                MessageBox.Show("You must be at least 18 years old to register.", "Age Requirement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (contactNumtxt.Text.Trim().Length < 11)
            {
                MessageBox.Show("Contact number must be at least 11 digits.", "Invalid Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (DoesUsernameExist(usernametxt.Text.Trim()))
            {
                MessageBox.Show("This username is already taken. Please choose a different one.",
                                "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                usernametxt.Focus();
                return false;
            }

            if (!maleRbtn.Checked && !femaleRbtn.Checked && !otherRbtn.Checked)
            {
                MessageBox.Show("Please select a gender.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void contactNumtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;

            if (contactNumtxt.Text.Length >= 11 && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private bool IsAnyFieldEmpty()
        {
            if (
                string.IsNullOrWhiteSpace(firstNametxt.Text)
                ) return true;
            if (
                string.IsNullOrWhiteSpace(lastNametxt.Text)
                ) return true;
            if (
                string.IsNullOrWhiteSpace(usernametxt.Text)
                ) return true;
            if (
                string.IsNullOrWhiteSpace(emailAddtxt.Text)
                ) return true;
            if (
                string.IsNullOrWhiteSpace(passwordtxt.Text)
                ) return true;
            if (
                string.IsNullOrWhiteSpace(confirmPasswordtxt.Text)
                ) return true;
            if (
                string.IsNullOrWhiteSpace(citytxt.Text)
                ) return true;
            if (
                string.IsNullOrWhiteSpace(barangaytxt.Text)
                ) return true;
            if (
                string.IsNullOrWhiteSpace(streettxt.Text)
                ) return true;

            return false;
        }

        private void CreateUser(string username, string email, string pass, string phone,
                                string first, string last, string addr, DateTime bday, string gen)
        {
            using (var conn = new Npgsql.NpgsqlConnection(connString))
            {
                conn.Open();
                string sql = @"INSERT INTO hotel.users 
                               (user_id, username, email, password, phone_number, gender, birthday, address, first_name, last_name, role) 
                               VALUES (unique_rowid(), @u, @e, @p, @ph, @g, @b, @a, @f, @l, 'user')";

                using (var cmd = new Npgsql.NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@e", email);
                    cmd.Parameters.AddWithValue("@p", pass);
                    cmd.Parameters.AddWithValue("@ph", (object)phone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@g", gen);
                    cmd.Parameters.AddWithValue("@b", bday);
                    cmd.Parameters.AddWithValue("@a", addr);
                    cmd.Parameters.AddWithValue("@f", first);
                    cmd.Parameters.AddWithValue("@l", last);
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
        private void logIntxt_Click(object sender, EventArgs e)
        {
            new logInForm().Show();
            this.Hide();
        }

        private void logInHeader_lbl_Click(object sender, EventArgs e) { 
        
        }
        private void subHeader_lbl_Click(object sender, EventArgs e) {
        
        }
        private void birthdatePicker_ValueChanged(object sender, EventArgs e) {
        
        }
        private void passwordtxt_TextChanged(object sender, EventArgs e) {
        
        }
    }
}