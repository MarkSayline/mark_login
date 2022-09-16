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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string dbConn = "datasource=localhost;database=mark;username=root;password=";

                string Query = "insert into users(user_name,user_password) values('" + this.txtUsername.Text + "','" + this.txtPassword.Text + "');";

                MySqlConnection con = new MySqlConnection(dbConn);

                MySqlCommand sqlCommand = new MySqlCommand(Query, con);

                MySqlDataReader MyReader2;

                con.Open();
                MyReader2 = sqlCommand.ExecuteReader();
                MessageBox.Show("Registration Successfull,use your username and password to login");
                this.Hide();
                Form1 login = new Form1();
                login.Show();
                while (MyReader2.Read())
                {
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
