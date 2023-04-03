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

namespace Scheduler
{
    public partial class FormCalendar : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
        DataTable dt = new DataTable();
        DateTime currentDate;
        

        private void getData(string s)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                MySqlCommand cmd = new MySqlCommand(s, con);
                con.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();

            }
        }

        
        
        private void handleDay()
        {
            dt.Clear();
            getData("SELECT * FROM Appointment WHERE start = CAST('" + currentDate + "' AS datetime);");
            dataGridViewCalendar.DataSource = dt;
        }
        private void handleWeek()
        {
            

            string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            //int dow = (int)currentDate.DayOfWeek;
            //string startDate = currentDate.AddDays(-dow).ToString();
            //DateTime startDate = Convert.ToDateTime(currentDate.ToString());
            //DateTime formattedStartDate = Convert.ToDateTime(startDate);
            //DateTime endDate = Convert.ToDateTime(currentDate.AddDays(7).ToString());
            //DateTime formattedEndDate = Convert.ToDateTime(endDate);

            //getData("SELECT * FROM Appointment WHERE start BETWEEN CAST('" + startDate + "' AS datetime) AND CAST('" + endDate + "' AS datetime);");

            int mo = (int)currentDate.Month;
            
            int yr = (int)currentDate.Year;
            int d = (int)currentDate.Day;
            int endD = ((int)currentDate.Day) + 7;
            string startDate = yr.ToString() + "-" + mo.ToString() + "-" + d.ToString();
            DateTime tempDate = Convert.ToDateTime(startDate);
            
            string endDate = yr.ToString() + "/" + mo.ToString() + "/" + endD.ToString();

            string sqlString = "SELECT * FROM Appointment WHERE start BETWEEN CAST('" + startDate + "' AS datetime) AND CAST('" + endDate + "' AS datetime);";
            //string sqlString = $"SELECT * FROM Appointment WHERE start BETWEEN '{formattedStartDate}' = start AND '{formattedEndDate}' = end";
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridViewCalendar.DataSource = dt;
            con.Close();


        }
        private void handleMonth()
        {
            
            string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);

            int mo = (int)currentDate.Month;
            int yr = (int)currentDate.Year;
            int d = 0;
            string startDate = yr.ToString() + "-" + mo.ToString() + "-01";
            DateTime tempDate = Convert.ToDateTime(startDate);
            switch (mo)
            {
                case 1:
                case 2:
                case 3:
                case 5:
                case 8:
                case 10:
                    d = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    d = 30;
                    break;
                default:
                    d = 29;
                    break;
            }
            string endDate = yr.ToString() + "/" + mo.ToString() + "/" + d.ToString();

            string sqlString = "SELECT * FROM Appointment WHERE start BETWEEN CAST('" + startDate + "' AS datetime) AND CAST('" + endDate + "' AS datetime);"; 
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridViewCalendar.DataSource = dt;
            con.Close();
            //dt.Clear();

            //getData("SELECT * FROM Appointment WHERE start BETWEEN CAST('" + startDate + "' AS datetime) AND CAST('" + endDate + "' AS datetime);");
            //dataGridViewCalendar.DataSource = dt;


        }
        public FormCalendar()
        {
            InitializeComponent();
            currentDate = DateTime.Now;
            getData("SELECT * FROM Appointment");
            dataGridViewCalendar.DataSource = dt;
        }


        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string sqlString = "SELECT * FROM Appointment"; //WHERE USER ID MATCHES CURRENT LOGGED IN USER?
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridViewCalendar.DataSource = dt;
        }

        private void radioButtonWeekly_CheckedChanged(object sender, EventArgs e)
        {
            dt.Clear();
            handleWeek();
        }

        private void radioButtonMonthly_CheckedChanged(object sender, EventArgs e)
        {
            dt.Clear();
            handleMonth();
        }

        private void radioButtonDaily_CheckedChanged(object sender, EventArgs e)
        {
            dt.Clear();
            handleDay();
        }

        private void dataGridViewCalendar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                var UTCdate = (DateTime)e.Value;
                var localDate = UTCdate.ToLocalTime();
                e.Value = localDate;

            }
        }
    
    }
}
