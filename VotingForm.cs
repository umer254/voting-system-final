using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VotingSystemWinForms
{
    public partial class VotingForm : Form
    {
        private string loggedInUser;

        public VotingForm(string username)
        {
            InitializeComponent();
            loggedInUser = username;
            this.Load += new EventHandler(VotingForm_Load);
        }

        private void VotingForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {loggedInUser}";
            LoadCandidates();
            CheckIfUserHasVoted();
        }

        private void LoadCandidates()
        {
            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-DRL8MH9\\SQLEXPRESS01; Database=ElectionVotingSystem; Integrated Security=True;"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT CandidateID, Name FROM Candidates", connection);
                SqlDataReader reader = command.ExecuteReader();
                Dictionary<int, string> candidates = new Dictionary<int, string>();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    candidates.Add(id, name);
                }

                cmbCandidates.DataSource = new BindingSource(candidates, null);
                cmbCandidates.DisplayMember = "Value";
                cmbCandidates.ValueMember = "Key";
                reader.Close();
            }
        }

        private void CheckIfUserHasVoted()
        {
            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-DRL8MH9\\SQLEXPRESS01; Database=ElectionVotingSystem; Integrated Security=True;"))
            {
                connection.Open();
                string sql = "SELECT COUNT(*) FROM Votes WHERE UserID = (SELECT UserID FROM Users WHERE Username = @Username)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", loggedInUser);
                    int voteCount = (int)command.ExecuteScalar();
                    if (voteCount > 0)
                    {
                        MessageBox.Show("You have already voted.", "Vote Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnVote.Enabled = false;
                    }
                }
            }
        }

        private void btnVote_Click(object sender, EventArgs e)
        {
            if (cmbCandidates.SelectedItem == null)
            {
                MessageBox.Show("Please select a candidate to vote.", "Vote Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KeyValuePair<int, string> selectedCandidate = (KeyValuePair<int, string>)cmbCandidates.SelectedItem;
            int candidateID = selectedCandidate.Key;

            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-DRL8MH9\\SQLEXPRESS01; Database=ElectionVotingSystem; Integrated Security=True;"))
            {
                connection.Open();
                string sql = "INSERT INTO Votes (UserID, CandidateID, Timestamp) VALUES ((SELECT UserID FROM Users WHERE Username = @Username), @CandidateID, GETDATE());";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", loggedInUser);
                    command.Parameters.AddWithValue("@CandidateID", candidateID);
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thank you, you voted successfully.", "Vote Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnVote.Enabled = false; // Disable the vote button after successful vote
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while recording your vote: " + ex.Message, "Vote Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            ResultsForm resultsForm = new ResultsForm();
            resultsForm.Show();
        }
    }
}
