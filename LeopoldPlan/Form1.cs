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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string strCon = "Data Source=DESKTOP-UG1MIDI;Initial Catalog=LeopoldDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        private void loginBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                string query = "SELECT role FROM User1 WHERE email=@em AND password=@pw";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@em", txtEmail.Text);
                cmd.Parameters.AddWithValue("@pw", txtPassword.Text);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string roleFromDB = result.ToString();

                    Taskform tf = new Taskform(roleFromDB);
                    tf.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid email or password!");
                }
            }


        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register regForm = new Register();
            regForm.Show();
            this.Hide();
        }
    }
}
