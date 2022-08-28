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
    public partial class ProductCategory : Form
    {
        public ProductCategory()
        {
            InitializeComponent();
            LocalProductCategory();
        }
        public void LocalProductCategory()
        {
            int i = 0;
            dgvw.Rows.Clear();
            string query = "Select * from product_category order by category_name";
            db_con.OpenConn();
            MySqlCommand command;
            command = new MySqlCommand(query, db_con.con);
            MySqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvw.Rows.Add(i, dr["category_name"].ToString(), dr["description"].ToString()); 
            }
            dr.Close();
            db_con.CloseConn();
        }


    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProductCategory addProductCategory = new AddProductCategory();
            addProductCategory.ShowDialog(this);
        }

        private void ProductCategory_Load(object sender, EventArgs e)
        {

        }
    }
}
