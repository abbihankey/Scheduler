using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Scheduler.Resources
{
    public class DB
    {
        public static MySqlConnection con { get; set; }
        public static bool verifyInput(Panel panel)
        {
            foreach (Control child in panel.Controls)
            {
                if (child is TextBox)
                {
                    TextBox textBox = child as TextBox;
                    if (string.IsNullOrEmpty(textBox.Text))
                    {

                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                
            }
            return true;
        }
        public static int selectMaxID(string table, string id)
        {
            startConnection();
            var query = $"SELECT max({id}) FROM {table}";
            MySqlCommand comm = new MySqlCommand(query, con);
            MySqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                if (reader[0] == DBNull.Value)
                {
                    return 0;
                }
                return Convert.ToInt32(reader[0]);
            }
            return 0;
        }
        public static void startConnection()
        {
            try
            {
                //get the connection string
                string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                con = new MySqlConnection(constr);
                //open the connection
                con.Open();
                MessageBox.Show("Connection is open");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void closeConnection()
        {
            //close connection
            try
            {
                if (con != null)
                {
                    con.Close();
                }
                con = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string formatTime(DateTime dateValue)
        {
            string sqlDateTime = dateValue.ToString("yy=MM=dd HH:mm");
            return sqlDateTime;
        }
        public static void insertCustomer(int id, string name, int addressID, int active, DateTime dateTime, string user)
        {
            string sqlDateTime = formatTime(dateTime);
            startConnection();
            MySqlTransaction transaction = con.BeginTransaction();

            //query
            var query = "INSERT INTO customer (customerId, customerName, addressID, active, createDate, createdBy, lastUpdateBy) "
                + $"VALUES ('{id}', '{name}', '{addressID}', '{active}', '{formatTime(dateTime)}', '{user}', '{user}')";
            MySqlCommand comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();
            closeConnection();

        }
        //insert city
        //insert country
        //insert address
    
    
    }
        
}
