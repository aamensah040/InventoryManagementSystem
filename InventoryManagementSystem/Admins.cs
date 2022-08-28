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
    public partial class Admins : Form
    {
        public Admins()
        {
            InitializeComponent();
            LoadAdmins();
        }

        public void LoadAdmins() 
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            string query = "Select * from users"; 
            db_con.OpenConn();
            MySqlCommand command;
            command = new MySqlCommand(query, db_con.con);

            MySqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["name"].ToString(), dr["username"].ToString(), dr["role"].ToString());
            }
            dr.Close();
            db_con.CloseConn();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Hide();
           AddAdmin addAdmin = new AddAdmin();
           addAdmin.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddAdmin addAdmin = new AddAdmin();
            addAdmin.Show(this);
        }
    }
}
