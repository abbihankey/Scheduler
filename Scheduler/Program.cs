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
