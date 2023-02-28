using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scheduler.Resources;

namespace Scheduler
{
    static class Program
    {
        /* try
    {
        using(con = new SqlConnection(Properties.Settings.Default.SchoolConnectionString))
        {
            con.Open();
            string sqlCommand = "Update (Table) set value=@Value where id=@ID";
            SqlCommand cmd = new SqlCommand(sqlCommand, con);
            cmd.Parameters.AddWithValue("@Value", updatedValue);
            cmd.Parameters.AddWithValue("@ID", idOfRowToUpdate);
            int rowsAffected = cmd.ExecuteNonQuery();
            if(rowsAffected == 1)
            {
                MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    } */














        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /* 
                  
 
         */
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DBConnection.startConnection();
            Application.Run(new FormMainMenu());
            DBConnection.closeConnection();
        }
    }
}
