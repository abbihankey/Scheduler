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
            dt.Clear();
            int dow = (int)currentDate.DayOfWeek;
            string startDate = currentDate.AddDays(-dow).ToString();
            DateTime tempDate = Convert.ToDateTime(startDate);
            string endDate = currentDate.AddDays(7 - dow).ToString();
            getData("SELECT * FROM Appointment WHERE start BETWEEN CAST('" + startDate + "' AS datetime) AND CAST('" + endDate + "' AS datetime);");
            //convert to local time 
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DateTime y = (DateTime)dt.Rows[i]["start"];
            //    dt.Rows[i]["start"] = y.ToLocalTime();
            //}
     
            dataGridViewCalendar.DataSource = dt;
        }
        private void handleMonth()
        {
            dt.Clear();
            int mo = (int)currentDate.Month;
            int yr = (int)currentDate.Year;
            int d = 0;
            string startDate = mo.ToString() + "/01/" + yr.ToString();
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
            string endDate = mo.ToString() + "/" + d.ToString() + "/" + yr.ToString();
            getData("SELECT * FROM Appointment WHERE start BETWEEN CAST('" + startDate + "' AS datetime) AND CAST('" + endDate + "' AS datetime);");
            dataGridViewCalendar.DataSource = dt;
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
            handleWeek();
        }

        private void radioButtonMonthly_CheckedChanged(object sender, EventArgs e)
        {
            handleMonth();
        }

        private void radioButtonDaily_CheckedChanged(object sender, EventArgs e)
        {
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
