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
            populateAppointmentDGV();
            populateTypeDGV();


        }
        public void populateTypeDGV()
        {
            //populate data grid
            string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string sqlString = "SELECT type, start, end FROM Appointment";
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
    }
}
