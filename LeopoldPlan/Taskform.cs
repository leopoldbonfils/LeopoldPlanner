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

            statusCombo.Items.Add("Pending");
            statusCombo.Items.Add("In Progress");
            statusCombo.Items.Add("Completed");
            statusCombo.SelectedIndex = 0; 
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
                string query = "INSERT INTO Task (taskName, status, StartDate, EndDate) VALUES(@taskName, @sts, @StartDate, @EndDate)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@taskName", taskNameBox.Text);
                cmd.Parameters.AddWithValue("@sts", statusCombo.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@StartDate", startDate.Value.Date);
                cmd.Parameters.AddWithValue("@EndDate", endDate.Value.Date);

                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0 ) { 
                    MessageBox.Show("Registration successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to Registration.");
                }
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
                    string query = "UPDATE Task SET taskName=@taskName, status=@status, StartDate=@StartDate, EndDate=@EndDate WHERE taskID=@taskID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@taskID", taskId);
                    cmd.Parameters.AddWithValue("@taskName", taskNameBox.Text);
                    cmd.Parameters.AddWithValue("@status", statusCombo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@StartDate", startDate.Value.Date);
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Value.Date);
                    int rowsAffected = cmd.ExecuteNonQuery();

                  

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Update successful!");
                    }
                    else
                    {
                        MessageBox.Show("No record found with Task ID = {taskId}.");
                    }

                    DisplayData();
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
                    if (rowsAffected > 0) {
                        MessageBox.Show("Delete successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No record found with taskID = {taskId}.");
                    }


                    DisplayData();

                   
                }
                else
                {
                    MessageBox.Show("Please enter Task ID.");
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

                    
                    if (ds.Tables["Task"].Rows.Count > 0)
                    {
                        DataRow row = ds.Tables["Task"].Rows[0];

                        
                        taskNameBox.Text = row["taskName"].ToString();
                        statusCombo.SelectedItem = row["status"].ToString();

                       
                        if (row["StartDate"] != DBNull.Value)
                            startDate.Value = Convert.ToDateTime(row["StartDate"]);
                        else
                            startDate.Value = DateTime.Now;

                        if (row["EndDate"] != DBNull.Value)
                            endDate.Value = Convert.ToDateTime(row["EndDate"]);
                        else
                            endDate.Value = DateTime.Now;

                        MessageBox.Show("Record loaded successfully!");
                    }
                    else
                    {
                        MessageBox.Show($"No record found with Task ID = {taskId}");
                        taskNameBox.Clear();
                        statusCombo.SelectedIndex = -1;
                    }
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
