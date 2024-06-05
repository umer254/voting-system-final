using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VotingSystemWinForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(LoginForm_Load);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Initialize any data or settings here
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateLogin(username, password))
            {
                VotingForm votingForm = new VotingForm(username);
                this.Hide();
                votingForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateLogin(string username, string passwordEnteredByUser)
        {
            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-DRL8MH9\\SQLEXPRESS01; Database=ElectionVotingSystem; Integrated Security=True;"))
            {
                connection.Open();
                string sql = "SELECT Password FROM Users WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    string storedPassword = (string)command.ExecuteScalar();
                    return storedPassword != null && passwordEnteredByUser == storedPassword;
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            registerForm.Show();
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
