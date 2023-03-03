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
        private static int userID;
        private static string username;
        public static string getUsername()
        {
            return username; 
        }

        public static MySqlConnection con { get; set; }
        
        public static bool verifyInput(Panel panel) //https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.control.controls?view=windowsdesktop-7.0
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
        public static int selectMaxID(string table, string iD)
        {
            //https://dev.mysql.com/doc/dev/connector-net/6.10/html/T_MySql_Data_MySqlClient_MySqlDataReader.html
            //https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqldatareader.read?view=dotnet-plat-ext-7.0

            startConnection();
            var query = $"SELECT max({iD}) FROM {table}";
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
        public static DateTime currentTime()
        {
            DateTime currentTime = DateTime.Now.ToUniversalTime();
            return currentTime;
        }
        public static void insertCustomer(int id, string name, int addressID, int active, DateTime createTime, string username) 
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.executenonquery?view=dotnet-plat-ext-7.0
            //https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/local-transactions

            // string sqlDateTime = formatTime(dateTime); //is this needed??
            startConnection();
            MySqlTransaction transaction = con.BeginTransaction();
            string createDate = formatTime(createTime);


            string user = DB.getUsername();

            DateTime currentTime = getCurrentTime();
            var formattedCurrentTime = formatTime(currentTime);

            //query
            var query = "INSERT INTO customer (customerId, customerName, addressId, active, createDate, createdBy, lastUpdateBy) "
                + $"VALUES ('{id}', '{name}', '{addressID}', '{active}', '{formattedCurrentTime}', '{user}', '{user}')";
            MySqlCommand comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();
            closeConnection();

        }
        //insert city
        public static int insertCity(int countryID, string city)
        {
            int maxCityID = selectMaxID("city", "cityId");
            int newCityID = maxCityID +1;
            string user = DB.getUsername();

            DateTime currentTime = getCurrentTime();
            var formattedCurrentTime = formatTime(currentTime);

            // DateTime lastUpdate = "null"; //get actual value

            startConnection(); //not needed
            MySqlTransaction transaction = con.BeginTransaction();

            //query
            var query = "INSERT INTO city (cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy)"
                + $"VALUES ('{newCityID}', '{city}', '{countryID}', '{formattedCurrentTime}', '{user}', '{formattedCurrentTime}', '{user}')";
            MySqlCommand comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();
            closeConnection();
            return newCityID;

        }

        //insert country
        public static int insertCountry(string country)
        {
            int maxCountryID = selectMaxID("country", "countryID");
            int newCountryID = maxCountryID +1;
            
            DateTime currentTime = getCurrentTime();
            var formattedCurrentTime = formatTime(currentTime);

            string user = DB.getUsername();

            startConnection(); //not needed
            MySqlTransaction transaction = con.BeginTransaction();

            //query
            var query = "INSERT INTO country (countryId, country, createDate, createdBy, lastUpdateBy)"
                + $"VALUES ('{newCountryID}', '{country}', '{formattedCurrentTime}', '{user}', '{user}')";
            MySqlCommand comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();
            closeConnection();
            return newCountryID;

        }
        //insert address
        public static int insertAddress(int cityID, string address, string zip, string phone)
        {
            int maxAddressID = selectMaxID("address", "addressID");
            int newAddressID = maxAddressID +1;

            DateTime currentTime = getCurrentTime();
            var formattedCurrentTime = formatTime(currentTime);

            string user = DB.getUsername();

            startConnection(); //not needed
            MySqlTransaction transaction = con.BeginTransaction();
            var address2 = "null";

            //query
            var query = "INSERT INTO address (addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy)"
                + $"VALUES ('{newAddressID}', '{address}','{address2}','{cityID}','{zip}','{phone}','{formattedCurrentTime}','{user}', '{user}')";
            MySqlCommand comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();
            closeConnection();
            return newAddressID;

        }
        public static DateTime getCurrentTime()
        {
            return DateTime.Now.ToUniversalTime();
        }
    
    }
        
}
