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
using System.Data;

namespace Scheduler.Resources
{
    public class DB
    {
        private static int userID;
        private static string username;
        public static string getUsername()
        {
            return username = "test";

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
        public static int selectUserID(string username)
        {
            //https://dev.mysql.com/doc/dev/connector-net/6.10/html/T_MySql_Data_MySqlClient_MySqlDataReader.html
            //https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqldatareader.read?view=dotnet-plat-ext-7.0

            startConnection();
            var query = $"SELECT userId FROM user WHERE '{username}' = username";
            MySqlCommand comm = new MySqlCommand(query, con);
            MySqlDataReader reader = comm.ExecuteReader();
            closeConnection();
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
                //MessageBox.Show("Connection is open");
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
            string sqlDateTime = dateValue.ToString("yy-MM-dd HH:mm");
            return sqlDateTime;
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
            int newCityID = maxCityID + 1;
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
            int newCountryID = maxCountryID + 1;

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
            int newAddressID = maxAddressID + 1;

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
        public static void UpdateCustomer(Dictionary<string, string> newCustomerDetails, Dictionary<string, string> selectedCustomerDictionary)
        {
            string user = DB.getUsername();
            DateTime currentTime = getCurrentTime();
            var formattedCurrentTime = formatTime(currentTime);


            startConnection();

            //query: update customer
            MySqlTransaction transaction = con.BeginTransaction();
            var query = $"UPDATE customer" +
                $" SET customerName = '{newCustomerDetails["customerName"]}', active = '{newCustomerDetails["active"]}', lastUpdate = '{formattedCurrentTime}', lastUpdateBy = '{user}'" +
                $" WHERE customerName = '{selectedCustomerDictionary["customerName"]}'";

            MySqlCommand comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();

            //query: update city
            /*
            transaction = con.BeginTransaction();
            query = $"UPDATE city" +
                $" SET city = '{newCustomerDetails["city"]}', lastUpdate = '{formattedCurrentTime}, lastUpdateBy = '{user}', WHERE city = '{selectedCustomerDictionary["city"]}'";
                // $" WHERE city = '{selectedCustomerDictionary["city"]}'";

            comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit(); */


            //query: update address
            transaction = con.BeginTransaction();
            query = $"UPDATE address" +
                $" SET address = '{newCustomerDetails["address"]}', postalCode = '{newCustomerDetails["postalCode"]}', lastUpdate = '{formattedCurrentTime}', lastUpdateBy = '{user}'" +
                $" WHERE address = '{selectedCustomerDictionary["address"]}'";

            comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();

            //query: update country
            transaction = con.BeginTransaction();
            query = $"UPDATE country" +
                $" SET country = '{newCustomerDetails["customerName"]}', lastUpdate = '{formattedCurrentTime}', lastUpdateBy = '{user}'" +
                $" WHERE country = '{selectedCustomerDictionary["country"]}'";

            comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();
        }
        static public Dictionary<string, string> getCustomerDictionary(int customerID)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqldatareader?view=sqlclient-dotnet-standard-5.1
            var customerId = customerID.ToString();

            startConnection();
            var query = $"SELECT * FROM customer WHERE customerId = '{customerId}'";
            MySqlCommand comm = new MySqlCommand(query, con);
            MySqlDataReader reader = comm.ExecuteReader();
            reader.Read();

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
            customerDictionary.Add("postalCode", reader[5].ToString());
            customerDictionary.Add("phone", reader[4].ToString());
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
        static public Dictionary<string, string> getAppointmentDictionary(int appointmentID)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqldatareader?view=sqlclient-dotnet-standard-5.1
            var appId = appointmentID.ToString();

            startConnection();
            var query = $"SELECT * FROM appointment WHERE appointmentId = '{appointmentID}'";
            MySqlCommand comm = new MySqlCommand(query, con);
            MySqlDataReader reader = comm.ExecuteReader();
            reader.Read();

            Dictionary<string, string> appointmentDictionary = new Dictionary<string, string>();

            //customer dictionary
            appointmentDictionary.Add("appointmentId", appId);
            appointmentDictionary.Add("customerId", reader[1].ToString());
            appointmentDictionary.Add("userId", reader[2].ToString());
            appointmentDictionary.Add("title", reader[3].ToString());
            appointmentDictionary.Add("description", reader[4].ToString());
            appointmentDictionary.Add("location", reader[5].ToString());
            appointmentDictionary.Add("type", reader[7].ToString());
            appointmentDictionary.Add("url", reader[8].ToString());
            appointmentDictionary.Add("start", reader[9].ToString());
            appointmentDictionary.Add("end", reader[10].ToString());
            
            reader.Close();
            closeConnection();
            

            return appointmentDictionary;
        }
        public static void DeleteAppointment(int rowID)
        {
            startConnection();
            MySqlTransaction transaction = con.BeginTransaction();

            //query
            var query = $"DELETE FROM appointment WHERE appointmentId = '{rowID}'";


            MySqlCommand comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();
            closeConnection();
            return;
        }
        public static void insertAppointment(int appID, int custID, string title, string description, string location, string type, DateTime start, DateTime end)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.executenonquery?view=dotnet-plat-ext-7.0
            //https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/local-transactions

            // pass in appID
            int userID = 1; //method later
            string formattedStart = formatTime(start);
            string formattedEnd = formatTime(end);
            startConnection();
            MySqlTransaction transaction = con.BeginTransaction();
            DateTime currentTime = getCurrentTime();
            var formattedCurrentTime = formatTime(currentTime);
            string user = DB.getUsername();

            //query
            var query = "INSERT INTO appointment (appointmentId, customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) "
               + $"VALUES ('{appID}', '{custID}', '{userID}', '{title}', '{description}', '{location}', 'null', '{type}', 'null', '{formattedStart}', '{formattedEnd}', '{formattedCurrentTime}', '{user}', '{formattedCurrentTime}', '{user}')";
            MySqlCommand comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();
            closeConnection();

        }
        public static void UpdateAppointment(Dictionary<string, string> updatedAppDictionary, Dictionary<string, string> selectedAppDictionary)
        {
            string user = DB.getUsername();
            DateTime currentTime = getCurrentTime();
            var formattedCurrentTime = formatTime(currentTime);
            
            
            DateTime start = Convert.ToDateTime(updatedAppDictionary["start"]);
            string formattedStart = formatTime(start);
            DateTime end = Convert.ToDateTime(updatedAppDictionary["end"]);
            string formattedEnd = formatTime(end);


            startConnection();

            //query
            MySqlTransaction transaction = con.BeginTransaction();
            var query = $"UPDATE appointment" +
                $" SET customerId = '{updatedAppDictionary["customerId"]}', title = '{updatedAppDictionary["title"]}', description = '{updatedAppDictionary["description"]}', location = '{updatedAppDictionary["location"]}', type = '{updatedAppDictionary["type"]}', start = '{formattedStart}', end = '{formattedEnd}', url = 'null', lastUpdate = '{formattedCurrentTime}', lastUpdateBy = '{user}'" +
                $" WHERE appointmentId = '{selectedAppDictionary["appointmentId"]}'";
            MySqlCommand comm = new MySqlCommand(query, con);
            comm.Transaction = transaction;
            comm.ExecuteNonQuery();
            transaction.Commit();
            closeConnection();
        }
        public static bool isOverlaping(DateTime inputStart, DateTime inputEnd)
        {
            startConnection();
            string formattedInputStart = formatTime(inputStart);
            string formattedInputEnd = formatTime(inputEnd);
            var query = $" SELECT COUNT(*) FROM appointment WHERE '{formattedInputStart}' <= end AND '{formattedInputEnd}' >= start";
            MySqlCommand cmd = new MySqlCommand(query, con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            closeConnection();
            if (count > 0)
            {
                
                return true;
            }
            else
            {
                
                return false;
            }
            
        }
        public static bool checkBusinessHours(DateTime start, DateTime end)
        {
            int startHour = start.Hour;
            int endHour = end.Hour;


            if (startHour >= 9 && startHour <= 17 && endHour >= 9 && endHour <= 17) //lambda??
            {

                return true;
            }
            else
            {

                return false;
            }
        }
        public static bool isExistingCustomer(string inputID)
        {
            startConnection();
            
            var query = $" SELECT COUNT(*) FROM customer WHERE '{inputID}' = customerId";
            MySqlCommand cmd = new MySqlCommand(query, con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            closeConnection();
            if (count > 0)
            {

                return true;
            }
            else
            {

                return false;
            }

        }
        public static bool successfulLogIn(string username, string password)
        {
            startConnection();

            var query = $" SELECT COUNT(*) FROM user WHERE '{username}' = username AND '{password}' = password";
            MySqlCommand cmd = new MySqlCommand(query, con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            closeConnection();
            if (count > 0)
            {

                return true;
            }
            else
            {

                return false;
            }
        }
        public static bool findMeetings15Min(string username)
        {
            startConnection();
            DateTime currentTime = getCurrentTime();
            var formattedCurrentTime = formatTime(currentTime);
            DateTime timePlus15Min = currentTime.AddMinutes(15);
            var formattedTimePlus15Min = formatTime(timePlus15Min);
            

            var query = $" SELECT COUNT(*) FROM appointment WHERE start BETWEEN CAST('" + formattedCurrentTime + "' AS datetime) AND CAST('" + formattedTimePlus15Min + "' AS datetime)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            closeConnection();
            if (count > 0)
            {

                return true;
            }
            else
            {

                return false;
            }
        }
        
        static public int checkUpcomingAppointments(string username)
        {
            //I cannot figure out why this isnt working, using other method
            //https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand.parameters?view=sqlclient-dotnet-standard-5.1
            DateTime currentTime = getCurrentTime();
            DateTime timePlus15Min = currentTime.AddMinutes(15);
            var formattedTimePlus15Min = formatTime(timePlus15Min);
            var formattedCurrentTime = formatTime(currentTime);
            int userID = selectUserID(username);
            //I DONT THINK THE QUERY IS WORKING, TRYING PARAM
            //var commandText = "SELECT customerId, start FROM appointment WHERE userId = @userId AND start BETWEEN @formattedCurrentTime AND @formattedTimePlus15Min;";

            //MySqlCommand command = new MySqlCommand(commandText, con);
            //command.Parameters.AddWithValue("@UserId", userID);
            //command.Parameters["@userId"].Value = userID;
            //command.Parameters.Add("@formattedCurrentTime", (MySqlDbType)SqlDbType.DateTime);
            //command.Parameters["@formattedCurrentTime"].Value = formattedCurrentTime;
            //command.Parameters.Add("@formattedTimePlus15Min", (MySqlDbType)SqlDbType.DateTime);
            //command.Parameters["@formattedTimePlus15Min"].Value = formattedTimePlus15Min;


            //startConnection();
            //Dictionary<string, string> upcomingAppDictionary = new Dictionary<string, string>();
            //using (var query = new MySqlCommand("SELECT customerId FROM appointment WHERE userId = @userId AND start BETWEEN @formattedCurrentTime AND @formattedTimePlus15Min;", con))
            //{

            //   query.Parameters.AddWithValue("@userId", userID);
            //   query.Parameters.AddWithValue("@formattedCurrentTime", formattedCurrentTime);
            //   query.Parameters.AddWithValue("@formattedTimePlus15Min", formattedTimePlus15Min);

            //   query.ExecuteScalar();
            //   //MySqlDataReader reader = query.ExecuteReader();
            //   //reader.Read();
            //   //if (reader.Read())
            //   // {
            //   //     upcomingAppDictionary.Add("customerId", reader[0].ToString());
            //   //     upcomingAppDictionary.Add("start", reader[1].ToString());
            //   //     reader.Close();
            //   //}
            //   //else
            //   //{
            //   //     upcomingAppDictionary.Add("customerId", null);
            //   //     upcomingAppDictionary.Add("start", null);
            //   //     reader.Close();
            //   //}
            //}

            startConnection();
            //$"SELECT customerId FROM appointment WHERE userId = '{userID}' AND start >= '{formattedCurrentTime}' AND start <= '{formattedTimePlus15Min}'";
            var query = $"SELECT * FROM appointment WHERE start BETWEEN CAST('" + formattedCurrentTime + "' AS datetime) AND CAST('" + formattedTimePlus15Min + "' AS datetime);";
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
    }  
}
