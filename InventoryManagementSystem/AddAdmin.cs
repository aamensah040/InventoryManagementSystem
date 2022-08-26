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
    public partial class AddAdmin : Form
    {
        public AddAdmin()
        {
            InitializeComponent();
        }

        private void AddAdmin_Load(object sender, EventArgs e)
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
             string q = "Insert into users(id, name, username, role, gender, email, password) values(@id, @name, @username, role, @gender, @email, @password)";
             }
            else
            { 
                MessageBox.Show("Fields cannot be empty!!");
            }
        }
     }
}
