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
        public static Dictionary<string, string> customerDetails = new Dictionary<string, string>();

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
        public static void DeleteCustomer(int rowID)
        {
            startConnection();
            MySqlTransaction transaction = con.BeginTransaction();

            //query
            var query = $"DELETE FROM customer WHERE customerId = '{rowID}'";


            MySqlCommand comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();
            closeConnection();
            return;
        }
        public static void UpdateCustomer(Dictionary<string, string> newCustomerDetails)
        {
            string user = DB.getUsername();
            DateTime currentTime = getCurrentTime();
            var formattedCurrentTime = formatTime(currentTime);

            startConnection();

            //query: update customer
            MySqlTransaction transaction = con.BeginTransaction();
            var query = $"UPDATE customer" +
                $"SET customerName = '{newCustomerDetails["customerName"]}', active = '{newCustomerDetails["active"]}', lastUpdate = '{formattedCurrentTime}', lastUpdatedBy = '{user}'" +
                $"WHERE customerName = '{customerDetails["customerName"]}'";

            MySqlCommand comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();

            //query: update city
            transaction = con.BeginTransaction();
            query = $"UPDATE city" +
                $"SET country = '{newCustomerDetails["city"]}', lastUpdate = '{formattedCurrentTime}, lastUpdatedBy = '{user}'" +
                $"WHERE city = '{customerDetails["city"]}'";

            comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();


            //query: update address
            transaction = con.BeginTransaction();
            query = $"UPDATE address" +
                $"SET address = '{newCustomerDetails["address"]}', postalCode = '{newCustomerDetails["postalCode"]}', lastUpdate = '{formattedCurrentTime}', lastUpdatedBy = '{user}'" +
                $"WHERE address = '{customerDetails["address"]}'";

            comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();

            //query: update country
            transaction = con.BeginTransaction();
            query = $"UPDATE country" +
                $"SET country = '{newCustomerDetails["customerName"]}', lastUpdate = '{formattedCurrentTime}', lastUpdatedBy = '{user}'" +
                $"WHERE country = '{customerDetails["country"]}'";

            comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();
        }
        static public Dictionary<string, string> getCustomerDictionary(int customerID)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqldatareader?view=sqlclient-dotnet-standard-5.1

            startConnection();
            //customer query
            MySqlTransaction transaction = con.BeginTransaction();
            var query = $"SELECT * FROM customer WHERE customerId = '{customerID}'";
            MySqlCommand comm = new MySqlCommand(query, con);
            // Use reader?
            MySqlDataReader reader = comm.ExecuteReader();
            reader.Read();
            // comm.Transaction = transaction;
            // comm.ExecuteNonQuery();
            // transaction.Commit();
            closeConnection();

            Dictionary<string, string> customerDictionary = new Dictionary<string, string>();

            //customer dictionary
            customerDictionary.Add("customerName", reader[1].ToString());
            customerDictionary.Add("addressId", reader[2].ToString());
            customerDictionary.Add("active", reader[3].ToString());
            reader.Close();

            //address query
            query = $"SELECT * FROM address WHERE addressId = '{customerDictionary["addressId"]}'";
            comm = new MySqlCommand(query, con);
            reader = comm.ExecuteReader();
            reader.Read();

            //address dictionary
            customerDictionary.Add("address", reader[1].ToString());
            customerDictionary.Add("cityId", reader[3].ToString());
            customerDictionary.Add("postalCode", reader[4].ToString());
            customerDictionary.Add("address", reader[1].ToString());
            reader.Close();

            //city query
            query = $"SELECT * FROM city WHERE cityId = '{customerDictionary["cityId"]}'";
            comm = new MySqlCommand(query, con);
            reader = comm.ExecuteReader();
            reader.Read();

            //city dictionary
            customerDictionary.Add("city", reader[1].ToString());
            customerDictionary.Add("countryId", reader[2].ToString());
            reader.Close();

            //country query
            query = $"SELECT * FROM country WHERE countryId = '{customerDictionary["countryId"]}'";
            comm = new MySqlCommand(query, con);
            reader = comm.ExecuteReader();
            reader.Read();

            //county dictionary
            customerDictionary.Add("country", reader[1].ToString());
            reader.Close();
            closeConnection();
            
            return customerDictionary;
        }
        //update customer (pass in dict)
        public bool updateCustomer(Dictionary<string, string> newCustomerDetails)
        {
            startConnection();

            //query update customer
            
        }
    }

        
}
