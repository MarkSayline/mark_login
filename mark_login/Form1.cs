using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mark_login
{
    public partial class Form1 : Form
    {
        mark_db_connection con = new mark_db_connection();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text != "" && txtPassword.Text != "")
                {

                    con.Open();
                    string query = "SELECT user_name,user_password FROM users WHERE user_name ='" + txtUsername.Text + "' AND user_password ='" + txtPassword.Text + "'";
                    MySqlDataReader row;
                    row = con.ExecuteReader(query);
                    if (row.HasRows)
                    {

                        MessageBox.Show("Logged in Successfully......");
                        this.Hide();
                        Form3 landing_page = new Form3();
                        landing_page.Show();
                    }
                    else
                    {
                        MessageBox.Show("Check Username and passwsord");
                    }
                }
                else
                {
                    MessageBox.Show("All fields are required");
                }
            }
            catch
            {
                MessageBox.Show("Connection Failed");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 register = new Form2();
            register.Show();
        }
    }
}
