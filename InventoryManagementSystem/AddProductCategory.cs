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
    public partial class AddProductCategory : Form
    {
        public AddProductCategory()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Category", "Save Category", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db_con.OpenConn();
                    MySqlCommand mySqlCommand = new MySqlCommand();
                    string q = "insert into product_category(category_name,description) values(@name,@desc)";
                    mySqlCommand = new MySqlCommand(q, db_con.con);
                    mySqlCommand.Parameters.AddWithValue("@name", txtCname.Text);
                    mySqlCommand.Parameters.AddWithValue("@desc", txtDesc.Text);
                    mySqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Category had been successfully saved");
                    db_con.CloseConn();
                    this.Dispose();

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
