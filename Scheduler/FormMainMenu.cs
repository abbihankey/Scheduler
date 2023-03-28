using MySql.Data.MySqlClient;
using Scheduler.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//<a href="https://www.flaticon.com/free-icons/calendar" title="calendar icons">Calendar icons created by Freepik - Flaticon</a>
//< a href = "https://www.flaticon.com/free-icons/teamwork" title = "teamwork icons" > Teamwork icons created by Freepik - Flaticon</a>
//<a href="https://www.flaticon.com/free-icons/ui" title="ui icons">Ui icons created by Freepik - Flaticon</a>
//<a href="https://www.flaticon.com/free-icons/time" title="time icons">Time icons created by Freepik - Flaticon</a>
//<a href="https://www.flaticon.com/free-icons/15-minutes" title="15 minutes icons">15 minutes icons created by Freepik - Flaticon</a>
//<a href="https://www.flaticon.com/free-icons/profile" title="profile icons">Profile icons created by Freepik - Flaticon</a>
//<a href="https://www.flaticon.com/free-icons/waiting" title="waiting icons">Waiting icons created by Freepik - Flaticon</a>
//<a href="https://www.flaticon.com/free-icons/caution" title="caution icons">Caution icons created by Freepik - Flaticon</a>
// https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-create-mdi-child-forms?view=netframeworkdesktop-4.8



namespace Scheduler
{
    
    public partial class FormMainMenu : Form
    {
        public static Dictionary<string, string> upcomingAppDictionary = new Dictionary<string, string>();
        //public static void writeLogin(string username, bool validInfo)
        //{
            
        //    try
        //    {
        //        //FileStream inp = new FileStream(fileName, FileMode.Open, FileAccess.Write);
        //        //fileWriter = new StreamWriter(inp);
                
        //        if (validInfo == true)
        //        {
        //            using (StreamWriter sw = new StreamWriter(@"C:\Users\LabUser\source\repos\abbihankey\Scheduler\Scheduler\Resources\TextIO\LoginRecords.txt"))
        //            {
        //                sw.AutoFlush = true;
        //                DateTime currentTime = DB.getCurrentTime();
        //                sw.WriteLine(String.Format($"{username} logged in successfully at {currentTime}"));
        //                sw.Close();
        //                MessageBox.Show("Successful login recorded.");
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            using (StreamWriter sw = new StreamWriter(@"C:\Users\LabUser\source\repos\abbihankey\Scheduler\Scheduler\Resources\TextIO\LoginRecords.txt"))
        //            {
        //                sw.AutoFlush = true;
        //                DateTime currentTime = DB.getCurrentTime();
        //                sw.WriteLine(String.Format($"{username} failed to login at {currentTime}"));
        //                sw.Close();
        //                MessageBox.Show("Failed login recorded.");
        //                return;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("An error has occured.");
        //    }

        //}

        private void changeLanguage(string name)
        {
            if (name == "es-ES")
            {
                labelPassword.Text = "Contraseña";
                labelUsername.Text = "Nombre de usuario";
                buttonSubmit.Text = "Enviar";
                var Login = new Login();
                Login.Text = "Iniciar sesión";


            }

        }


        public FormMainMenu()
        {

            changeLanguage(CultureInfo.CurrentCulture.Name);
            InitializeComponent();
            buttonDashboard.BackColor = Color.FromArgb(74, 74, 74);
            IsMdiContainer = true;
            
            //MDI
            FormDashboard newMDIChild = new FormDashboard();
                // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
                // Display the new form.
            newMDIChild.StartPosition = FormStartPosition.Manual;
            
            newMDIChild.Show();


            
        }

        public static void recordLogin(string username, bool validInfo)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendtext?view=net-8.0

            string file = "LoginRecords.txt";
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filePath = Path.Combine(directory, file);

            //string details = $"{username} logged in successfully at {currentTime}";
            //File.AppendAllText(file, details);

            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("New File Created");
                    sw.Flush();
                    sw.Close();
                    MessageBox.Show("Login Record file created in MyDocuments.");
                    
                }

            }
            if (validInfo == true)
            {
                DateTime currentUTCTime = DB.getCurrentTime();
                DateTime currentTime = currentUTCTime.ToLocalTime();
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine($"{username} logged in successfully at {currentTime}");
                    sw.Flush();
                    sw.Close();

                    MessageBox.Show("Successful login recorded.");

                }
            }
            else
            {

                DateTime currentTime = DB.getCurrentTime();
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine($"{username} failed to login at {currentTime}");
                    sw.Close();
                    MessageBox.Show("Failed login recorded.");
                }
            }

        }

        private static void CloseAllForms()
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "FormMainMenu")
                    f.Close();
            }


        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            panelLogo.BackColor = Color.FromArgb(192, 163, 228);
            panelTitleBar.BackColor = Color.FromArgb(192, 163, 228);
            labelTitle.Text = "DASHBOARD";
            buttonDashboard.BackColor = Color.FromArgb(74, 74, 74);

            buttonCalendar.BackColor = Color.FromArgb(90, 90, 90);
            buttonAppointments.BackColor = Color.FromArgb(90, 90, 90);
            buttonCustomers.BackColor = Color.FromArgb(90, 90, 90);
            
            CloseAllForms();

            //MDI
            FormDashboard newMDIChild = new FormDashboard();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.StartPosition = FormStartPosition.Manual;
            
            newMDIChild.Show();
            //Close other child forms
        }

        private void buttonCalendar_Click(object sender, EventArgs e)
        {
            panelLogo.BackColor = Color.FromArgb(18, 198, 218);
            panelTitleBar.BackColor = Color.FromArgb(18, 198, 218);
            labelTitle.Text = "CALENDAR";
            buttonCalendar.BackColor = Color.FromArgb(74, 74, 74);

            buttonDashboard.BackColor = Color.FromArgb(90, 90, 90);
            buttonAppointments.BackColor = Color.FromArgb(90, 90, 90);
            buttonCustomers.BackColor = Color.FromArgb(90, 90, 90);
            
            CloseAllForms();

            //MDI
            FormCalendar newMDIChild = new FormCalendar();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.StartPosition = FormStartPosition.Manual;
            newMDIChild.Show();
            newMDIChild.StartPosition = FormStartPosition.Manual;
            newMDIChild.WindowState = FormWindowState.Maximized;


        }

        private void buttonAppointments_Click(object sender, EventArgs e)
        {
            panelLogo.BackColor = Color.FromArgb(218, 134, 230);
            panelTitleBar.BackColor = Color.FromArgb(218, 134, 230);
            labelTitle.Text = "APPOINTMENTS";
            buttonAppointments.BackColor = Color.FromArgb(74, 74, 74);

            buttonDashboard.BackColor = Color.FromArgb(90, 90, 90);
            buttonCalendar.BackColor = Color.FromArgb(90, 90, 90);
            buttonCustomers.BackColor = Color.FromArgb(90, 90, 90);

            CloseAllForms();

            //MDI
            FormAppointments newMDIChild = new FormAppointments();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.StartPosition = FormStartPosition.Manual;
            newMDIChild.Show();
            //Close other child forms
            newMDIChild.StartPosition = FormStartPosition.Manual;
            newMDIChild.WindowState = FormWindowState.Maximized;
        }

        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            panelLogo.BackColor = Color.FromArgb(160, 165, 252);
            panelTitleBar.BackColor = Color.FromArgb(160, 165, 252);
            labelTitle.Text = "CUSTOMERS";
            buttonCustomers.BackColor = Color.FromArgb(74, 74, 74);

            buttonDashboard.BackColor = Color.FromArgb(90, 90, 90);
            buttonCalendar.BackColor = Color.FromArgb(90, 90, 90);
            buttonAppointments.BackColor = Color.FromArgb(90, 90, 90);

            CloseAllForms();

            //MDI
            FormCustomers newMDIChild = new FormCustomers();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.StartPosition = FormStartPosition.Manual;
            newMDIChild.Show();
            newMDIChild.StartPosition = FormStartPosition.Manual;
            newMDIChild.WindowState = FormWindowState.Maximized;
            //Close other child forms

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            bool validInfo = DB.successfulLogIn(textBoxUsername.Text, textBoxPassword.Text);
            if (validInfo == true)
            {
                
                panelLogin.Enabled = false;
                panelLogin.Visible = false;
                string username = textBoxUsername.Text;
                validInfo = true;

                recordLogin(username, validInfo);
                //record success to text file
                //upcoming appointments
                bool within15 = DB.findMeetings15Min(username);
                if (within15 == false)
                {
                    MessageBox.Show("You have no appointments in the next 15 minutes.");
                }
                else
                {
                    //var upcomingAppCustID = upcomingAppDictionary["customerId"];
                    //var upcomingAppStart = upcomingAppDictionary["start"];
                    //MessageBox.Show(string.Format("A meeting with Customer ID: {0} starting at {1}.", upcomingAppCustID, upcomingAppStart));
                    MessageBox.Show("15 Minute Reminder: Appointment(s) occuring soon. You can view these meetings on your dashboard. ");
                }
            }
            else
            {
                //record failure to text file
                if (labelPassword.Text == "Contraseña")
                {
                    MessageBox.Show("Nombre de usuario o contraseña no válidos. Inténtalo de nuevo.");
                    return;
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                    return;
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelPassword_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
