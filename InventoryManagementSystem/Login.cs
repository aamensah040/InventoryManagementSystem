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
        public string _role = "";
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
                    bool _exists = false;
                    string enc_pass = Encrypt.HashString(passwordTxt.Text);
                    string query = "Select * from users where username = '" + usernameTxt.Text + "' && password ='" + enc_pass + "'";
                    command = new MySqlCommand(query, db_con.con);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        _exists = true;
                        _role = reader["role"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("Incorrect credentials!!");
                    }
                    reader.Close();

                    if(_exists)
                    {
                        if(_role =="Administrator")
                        {
                            this.Hide();
                            AdminDashboard adminDashboard = new AdminDashboard();
                            adminDashboard.Show();
                        }
                        if(_role == "Attendant")
                        {
                            this.Hide();
                            AttendantDash attendantDash = new AttendantDash();
                            attendantDash.Show();
                        }
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
