using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace InventoryManagementSystem
{
    internal class db_con
    {
        public static string cs = @"server=localhost; userid=root; password=; database=inventory_system;";  
        public static MySqlConnection con = new MySqlConnection(cs);
        public static MySqlCommand cmd = new MySqlCommand();    
        public static void OpenConn()
        {
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CloseConn()
        {
            try
            {
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DataTable getTable(string q)
        {
            OpenConn();
            cmd = new MySqlCommand(q, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            CloseConn();
            return table;
        }

        public double ExtractDBData(string q)
        {
            OpenConn();
            cmd = new MySqlCommand(q, con);
            double data = double.Parse(cmd.ExecuteScalar().ToString());
            CloseConn();

            return data;
        }

    }
}
