using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace LeopoldPlan
{
    public partial class Taskform : Form
    {
        private string userRole;

        
        public Taskform(string role)
        {
            InitializeComponent();
            userRole = role;
            SetupRoleUI();
            DisplayData();
        }

        private void SetupRoleUI()
        {
            if (userRole == "User")
            {
                
                UpdateBtn.Enabled = false;
                DeleteBtn.Enabled = false;
                RegisterBtn.Enabled = false;
                ReportBtn.Enabled = false; 
            }
            else if (userRole == "Admin")
            {
                
                UpdateBtn.Enabled = true;
                DeleteBtn.Enabled = true;
                RegisterBtn.Enabled = true;
                ReportBtn.Enabled = true;
            }
        }

        string strCon = "Data Source=DESKTOP-UG1MIDI;Initial Catalog=LeopoldDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                string query = "INSERT INTO Task VALUES(@taskName, @sts)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@taskName", "Data structure");
                cmd.Parameters.AddWithValue("@sts", "In progress");
                cmd.ExecuteNonQuery();
            }
            DisplayData();
        }

        private void DisplayData()
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                string query = "SELECT * FROM Task";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Task");
                taskGridView.DataSource = ds.Tables["Task"];
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                int taskId;

                if (int.TryParse(searchBox.Text, out taskId))
                {
                    string query = "UPDATE Task SET taskName=@taskName, status=@status WHERE taskID=@taskID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@taskID", taskId);
                    cmd.Parameters.AddWithValue("@taskName", taskNameBox.Text);
                    cmd.Parameters.AddWithValue("@status", statusCombo.Text);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    DisplayData();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show($"No record found with taskID = {taskId}.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid Task ID.");
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                int taskId;
                if (int.TryParse(searchBox.Text, out taskId))
                {
                    string query = "DELETE FROM Task WHERE taskID=@taskID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@taskID", taskId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    DisplayData();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show($"No record found with taskID = {taskId}.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid Task ID.");
                }
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                int taskId;
                if (int.TryParse(searchBox.Text, out taskId))
                {
                    string query = "SELECT * FROM Task WHERE taskID = @taskID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@taskID", taskId);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "Task");
                    taskGridView.DataSource = ds.Tables["Task"];
                }
                else
                {
                    MessageBox.Show("Please enter a valid Task ID.");
                }
            }
        }
    }
}
