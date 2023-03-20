using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler.Resources.TextIO
{
    class recordLogin
    {
        public static void recordLogIn(string username, string password, bool validInfo)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendtext?view=net-8.0

            string path = @"LoginRecords.txt";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                if (validInfo == true)
                {

                    DateTime currentTime = DB.getCurrentTime();
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine($"{username}logged in successfully at {currentTime}");

                    }
                }
                else
                {
                    DateTime currentTime = DB.getCurrentTime();
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine($"{username} failed to login at {currentTime}");

                    }
                }

            }
            else
            {
                MessageBox.Show("Could not find text file.");
            }
        }
    }
}
