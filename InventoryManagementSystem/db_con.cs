using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace InventoryManagementSystem
{
    internal class db_con
    {
        public static string cs = @"server=localhost; userid=root; password=; database=inventory_system;";  
        public static MySqlConnection con = new MySqlConnection(cs);

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
    }
}
