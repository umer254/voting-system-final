using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VotingSystemWinForms
{
    public partial class RegisterForm : Form
    {
        private static string connectionString = "Server=DESKTOP-DRL8MH9\\SQLEXPRESS01; Database=ElectionVotingSystem; Integrated Security=True;";

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // Initialize any data or settings here
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string id = txtID.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (RegisterUser(username, fullName, id, password))
            {
                MessageBox.Show("User registered successfully.", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Registration failed. ID may already exist.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool RegisterUser(string username, string fullName, string id, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO Users (Username, FullName, ID, Password) VALUES (@Username, @FullName, @ID, @Password)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Password", password);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (SqlException ex)
                {
                    // Log the exception message for debugging purposes
                    MessageBox.Show($"An error occurred: {ex.Message}", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}
