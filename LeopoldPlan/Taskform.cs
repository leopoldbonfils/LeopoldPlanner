using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeopoldPlan
{
    public partial class Taskform : Form
    {
        public Taskform()
        {
            InitializeComponent();

        }
        string strCon = "Data Source=DESKTOP-UG1MIDI;Initial Catalog=LeopoldDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strCon);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "INSERT INTO Task VALUES(@taskName, @sts)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@taskName", "Data structure");
            cmd.Parameters.AddWithValue("@sts", "In progress");
            cmd.ExecuteNonQuery();
            conn.Close();
            DisplayData();
        }
        private void DisplayData()
        {
            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            string query = "SELECT * FROM Task";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Task");
            taskGridView.DataSource = ds.Tables["Task"];
            conn.Close();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strCon);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            int taskId;
            
            if (int.TryParse(searchBox.Text, out taskId))
            {
                string query = "UPDATE Task SET taskName=@taskName, status=@status WHERE taskID=@taskID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@taskID", taskId);
                cmd.Parameters.AddWithValue("@taskName", taskNameBox.Text);
                cmd.Parameters.AddWithValue("@status", statusCombo.Text);
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                DisplayData();
                if (rowsAffected == 0)
                {
                    MessageBox.Show($"No record found with taskID = {taskId}.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Task ID.");
                conn.Close();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strCon);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            int taskId;
            if (int.TryParse(searchBox.Text, out taskId))
            {
                string query = "DELETE FROM Task WHERE taskID=@taskID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@taskID", taskId);
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                DisplayData();
                if (rowsAffected == 0)
                {
                    MessageBox.Show($"No record found with taskID = {taskId}.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Task ID.");
                conn.Close();
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strCon);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
          
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
            conn.Close();
        }
    }
}
