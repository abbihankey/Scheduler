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
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            //var searchValue = 1;
            //populateAppointmentDGV();
            //populateTypeDGV();


        }
        public void populateTypeDGV()
        {
            //populate data grid
            string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string sqlString = "SELECT type, count(*) FROM Appointment";
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridViewType.DataSource = dt;

            //CONVERT FROM UTC TO LOCAL TIMES


        }
        public void populateAppointmentDGV()
        {
            //populate data grid
            string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string sqlString = "SELECT appointmentId, start, end, type FROM Appointment";
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridViewUserAppointments.DataSource = dt;

            //CONVERT FROM UTC TO LOCAL TIMES


        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // populateAppointmentDGV();
            // bool results = false;
            if (string.IsNullOrEmpty(this.textBoxSearch.Text))
            {
                MessageBox.Show("Please enter an user ID.");
                return;
            }
            if (!int.TryParse(this.textBoxSearch.Text, out int searchID))
            {
                MessageBox.Show("Please enter an user ID.");
                return;
            }
            else
            {
                var searchValue = textBoxSearch.Text;
                string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                MySqlConnection con = new MySqlConnection(constr);
                string sqlString = $" SELECT appointmentId, start, end, type FROM appointment WHERE userId = '{searchValue}'";
                MySqlCommand cmd = new MySqlCommand(sqlString, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridViewUserAppointments.DataSource = dt;
                
            }
            if (dataGridViewUserAppointments.Rows.Count == 0)
            {
                MessageBox.Show("There are 0 appointments associated with the user ID.");
                return;
            }
            return;









        }

        private void buttonSearchByMonth_Click(object sender, EventArgs e)
        {
            //dataGridViewType.Rows.Clear();
            //string[] Months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            var searchValue = comboBoxMonth.SelectedItem;
            

            
            string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string sqlString = $" SELECT type, count(*) FROM appointment WHERE monthname(start) = '{searchValue}' GROUP BY type";
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridViewType.DataSource = dt;
        }

        private void buttonSearchCustSched_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBoxSearchCust.Text))
            {
                MessageBox.Show("Please enter a customer ID.");
                return;
            }
            if (!int.TryParse(this.textBoxSearchCust.Text, out int searchID))
            {
                MessageBox.Show("Please enter a customer ID.");
                return;
            }
            else
            {
                var searchValue = textBoxSearchCust.Text;
                string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                MySqlConnection con = new MySqlConnection(constr);
                string sqlString = $" SELECT appointmentId, start, end, type FROM appointment WHERE customerId = '{searchValue}'";
                MySqlCommand cmd = new MySqlCommand(sqlString, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridViewCustomerSchedules.DataSource = dt;

            }
            if (dataGridViewCustomerSchedules.Rows.Count == 0)
            {
                MessageBox.Show("There are 0 appointments associated with the customer ID.");
                return;
            }
            return;
        }

        private void dataGridViewUserAppointments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                var UTCdate = (DateTime)e.Value;
                var localDate = UTCdate.ToLocalTime();
                e.Value = localDate;

            }
        }

        private void dataGridViewType_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                var UTCdate = (DateTime)e.Value;
                var localDate = UTCdate.ToLocalTime();
                e.Value = localDate;

            }
        }

        private void dataGridViewCustomerSchedules_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
