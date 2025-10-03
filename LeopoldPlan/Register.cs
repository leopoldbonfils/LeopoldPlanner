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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            comboBox1.Items.Add("User");
            comboBox1.Items.Add("Admin");
            comboBox1.SelectedIndex = 0;
        }
        string strCon = "Data Source=DESKTOP-UG1MIDI;Initial Catalog=LeopoldDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";


        private void linkRegister1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            

        }

        private void loginBtn1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                string query = "INSERT INTO User1 (email, password, role) VALUES (@em, @pw, @role)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@em", txtEmail1.Text);
                cmd.Parameters.AddWithValue("@pw", txtPassword1.Text);
                cmd.Parameters.AddWithValue("@role", comboBox1.SelectedItem.ToString());
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration successful! You can now log in.");
                    this.Hide();
                    Form1 loginForm = new Form1();
                    loginForm.Show();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) 
                    {
                        MessageBox.Show("This email is already registered. Please use a different email.");
                    }
                    else
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }

        }
    }
}
