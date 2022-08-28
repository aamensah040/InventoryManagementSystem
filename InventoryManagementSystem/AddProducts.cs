
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
    public partial class AddProducts : Form
    {
        public AddProducts()
        {
            InitializeComponent();
        }

        public void LoadCategory()
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddProducts_Load(object sender, EventArgs e)
        {

       }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this product","Save Product",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db_con.OpenConn();
                    MySqlCommand mySqlCommand = new MySqlCommand();
                    string q = "insert into products(name,quantity,category_id,price,barcode,reorder) values(@name,@qty,@cat,@price,@barcode,@reorder)";
                    mySqlCommand = new MySqlCommand(q,db_con.con);
                    mySqlCommand.Parameters.AddWithValue("@name",txtPname.Text);
                    mySqlCommand.Parameters.AddWithValue("@qty",txtQty.Text);
                    mySqlCommand.Parameters.AddWithValue("@cat", cboCat.Text);
                    mySqlCommand.Parameters.AddWithValue("@price",double.Parse(nudPrice.Text));
                    mySqlCommand.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                    mySqlCommand.Parameters.AddWithValue("@reorder", double.Parse(nudReorder.Text));
                    mySqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Product has been added successfully");
                    db_con.CloseConn();
                    this.Dispose();

                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
