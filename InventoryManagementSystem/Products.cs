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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            LoadProducts();
        }

        public void LoadProducts()
        {
            int i = 0;
            dgview.Rows.Clear();
            string query = "Select * from products order by name";
            db_con.OpenConn();
            MySqlCommand command;
            command = new MySqlCommand(query, db_con.con);

            MySqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgview.Rows.Add(i, dr["name"].ToString(), dr["quantity"].ToString(), dr["category_id"].ToString(), dr["price"].ToString(), dr["barcode"].ToString(), dr["reorder"].ToString()); 
            }
            dr.Close();
            db_con.CloseConn();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Products_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProducts addProducts = new AddProducts();
            addProducts.Show(this);
        }

        private void dgview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
