using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

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
            // Normalize role text (remove spaces, make lowercase)
            string normalizedRole = userRole.Trim().ToLower();

            // Optional: show what role is logged in (for debugging)
            MessageBox.Show($"Logged in as: {normalizedRole}");

            if (normalizedRole == "user")
            {
                // Hide admin-only buttons for normal users
                UpdateBtn.Visible = false;
                DeleteBtn.Visible = false;
                RegisterBtn.Visible = false;
                ReportBtn.Visible = false;

                // Or if you prefer disabling them instead:
                // UpdateBtn.Enabled = false;
                // DeleteBtn.Enabled = false;
                // RegisterBtn.Enabled = false;
                // ReportBtn.Enabled = false;
            }
            else if (normalizedRole == "admin")
            {
                // Show all admin buttons
                UpdateBtn.Visible = true;
                DeleteBtn.Visible = true;
                RegisterBtn.Visible = true;
                ReportBtn.Visible = true;
            }
            else
            {
                MessageBox.Show("Unknown role. Limited access only.");
                UpdateBtn.Visible = false;
                DeleteBtn.Visible = false;
                RegisterBtn.Visible = false;
                ReportBtn.Visible = false;
            }
        }

        string strCon = "Data Source=DESKTOP-UG1MIDI;Initial Catalog=LeopoldDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                string query = "INSERT INTO Task (taskName, status) VALUES(@taskName, @sts)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@taskName", taskNameBox.Text);
                cmd.Parameters.AddWithValue("@sts", statusCombo.Text);
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

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void ReportBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF files|*.pdf", FileName = "TaskReport.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var writer = new iText.Kernel.Pdf.PdfWriter(sfd.FileName))
                        {
                            var pdf = new iText.Kernel.Pdf.PdfDocument(writer);
                            var document = new iText.Layout.Document(pdf);

                            document.Add(new iText.Layout.Element.Paragraph("Task Report").SetFontSize(18));

                            var table = new iText.Layout.Element.Table(taskGridView.Columns.Count);

                            
                            foreach (DataGridViewColumn column in taskGridView.Columns)
                            {
                                table.AddHeaderCell(column.HeaderText);
                            }

                            
                            foreach (DataGridViewRow row in taskGridView.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    table.AddCell(cell.Value?.ToString() ?? "");
                                }
                            }

                            document.Add(table);
                            document.Close();
                        }

                        MessageBox.Show("Report saved successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error creating PDF: " + ex.Message);
                    }
                }
            }
        }
    }
}
