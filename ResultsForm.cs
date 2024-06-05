using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VotingSystemWinForms
{
    public partial class ResultsForm : Form
    {
        private static string connectionString = "Server=DESKTOP-DRL8MH9\\SQLEXPRESS01; Database=ElectionVotingSystem; Integrated Security=True;";

        public ResultsForm()
        {
            InitializeComponent();
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            LoadResults();
        }

        private void LoadResults()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT c.Name AS Candidate, COUNT(v.VoteID) AS Votes FROM Votes v JOIN Candidates c ON v.CandidateID = c.CandidateID GROUP BY c.Name";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable resultsTable = new DataTable();
                adapter.Fill(resultsTable);
                dgvResults.DataSource = resultsTable;
            }
        }
    }
}
