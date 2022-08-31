using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class Dashboard : Form
    {
        db_con db = new db_con();
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender,EventArgs e)
        {
            lblTotalAdmins.Text = db.ExtractDBData("select count(*) from users where role = 'Administrator'").ToString("#,##0");
            lblTotalAtt.Text = db.ExtractDBData("select count(*) from users where role = 'Attendant'").ToString("#,##0");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
