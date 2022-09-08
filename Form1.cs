using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Drawing;
using Connection_DB;

namespace mark_login
{
    public partial class Form1 : Form
    {
        connection con = new connection();
        string user_name,user_password;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text != "" && txtPassword.Text != "")
                {

                    con.Open();
                    string query = "select user_name,user_password from users WHERE user_name ='" + txtUsername.Text + "' AND user_password ='" + txtPassword.Text + "'";
                    MySqlDataReader row;
                    row = con.ExecuteReader(query);
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            user_name = row["user_name"].ToString();
                            user_password = row["user_password"].ToString();
                        }
                        MessageBox.Show("Data found your username is " + user_name + " " + user_password + " " + " congs! ");
                    }
                    else
                    {
                        MessageBox.Show("Data not found", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Username or Password is empty", "Information");
                }
            }
            catch
            {
                MessageBox.Show("Connection Error", "Information");
            }
        }
    }
}