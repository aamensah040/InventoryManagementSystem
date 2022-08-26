using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace InventoryManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db_con.OpenConn();
            MySqlCommand command;
            if (usernameTxt.Text != "" && passwordTxt.Text != "")
            {
                try
                {
                    //string enc_pass = Encrypt.HashString(password.Text)
                    string query = "Select * from users where username = '" + usernameTxt.Text + "' && password ='" + passwordTxt.Text + "'";
                    command = new MySqlCommand(query, db_con.con);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        this.Hide();
                        reader.Close();
                        Home homeScreen = new Home();
                        homeScreen.Show();

                    }
                    else
                    {
                        reader.Close();
                        MessageBox.Show("Incorrect credentials!!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    db_con.CloseConn();
                }
            }
            else
            {
                MessageBox.Show("Username or Password cannot be empty");
            }
        }
    }
}
