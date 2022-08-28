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
    public partial class AddAttendant : Form
    {
        public AddAttendant()
        {
            InitializeComponent();
        }

        private void AddAttendant_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            db_con.OpenConn();
            MySqlCommand cmd;
            bool user_found = false;
            if (txtName.Text != "" && txtUsername.Text != "" && txtPassword.Text != "")
            {
                string q = "select * from users where username = ' " + txtUsername.Text + "'";
                cmd = new MySqlCommand(q, db_con.con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("There exists a username");
                    user_found = true;

                }
                else
                {
                    user_found = false;
                }
                reader.Close();
            }

            if (!user_found)
            {
                string role = "Administrator";
                string q = "Insert into users(name, username, password,role) values(name, @username, @password,@role)";
                cmd = new MySqlCommand(q, db_con.con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account created successfully", "Save Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //LoadUser();
                //Clear();
            }

            else
            {
                MessageBox.Show("Fields cannot be empty!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtName.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
