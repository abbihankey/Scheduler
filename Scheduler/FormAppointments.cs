using MySql.Data.MySqlClient;
using Scheduler.Resources;
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

    public partial class FormAppointments : Form
    {
        public static Dictionary<string, string> selectedAppDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> updatedAppDictionary = new Dictionary<string, string>();
        public FormAppointments()
        {
            InitializeComponent();
            panelAppointmentDetails.Visible = false;
            populateAppointmentDGV();
            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            dateTimePickerStart.CustomFormat = "MM/dd/yyyy hh:mm:ss";



            //CONVERT FROM UTC TO LOCAL TIMES
        }
        public void populateAppointmentDGV()
        {
            //populate data grid
            string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string sqlString = "SELECT * FROM Appointment";
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridViewAppointments.DataSource = dt;

            //CONVERT FROM UTC TO LOCAL TIMES

           
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            panelAppointmentDetails.Visible = true;
            labelAppointmentDetails.Text = "Insert";
            textBoxTitle.Clear();
            textBoxDescription.Clear();
            textBoxAppointmentID.Clear();
            textBoxCustomerID.Clear();
            textBoxUserID.Clear();
            textBoxTitle.Clear();
            textBoxDescription.Clear();
            textBoxLocation.Clear();
            textBoxType.Clear();


        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (labelAppointmentDetails.Text == "Update")
            {
                
                
                updatedAppDictionary.Add("customerId", textBoxCustomerID.Text);
                updatedAppDictionary.Add("title", textBoxTitle.Text);
                updatedAppDictionary.Add("description", textBoxDescription.Text);
                updatedAppDictionary.Add("location", textBoxLocation.Text);
                updatedAppDictionary.Add("type", textBoxType.Text);
                updatedAppDictionary.Add("start", dateTimePickerStart.CustomFormat);
                updatedAppDictionary.Add("end", dateTimePickerEnd.CustomFormat);


                DB.UpdateAppointment(updatedAppDictionary, selectedAppDictionary);
                panelAppointmentDetails.Visible = false;
                populateAppointmentDGV(); 
                
            }
            else
            {
                
                int maxAppID = DB.selectMaxID("appointment", "appointmentId");
                int newAppID = maxAppID + 1;
                textBoxCustomerID.Text = newAppID.ToString();
                var createTime = DB.getCurrentTime();
                var username = DB.getUsername();

                
                bool notEmpty = DB.verifyInput(panelAppointmentDetails);
                if (notEmpty == true)
                {
                    
                    int custID = Convert.ToInt32(textBoxCustomerID.Text);
                    string title = textBoxTitle.Text;
                    string description = textBoxDescription.Text;
                    string location = textBoxLocation.Text;
                    string type = textBoxType.Text;
                    DateTime start = dateTimePickerStart.Value;
                    DateTime end = dateTimePickerEnd.Value;



                    DB.insertAppointment(newAppID, custID, title, description, location, type, start, end);
                }
                else
                {
                    MessageBox.Show("Please input into all textboxes.", "Error", MessageBoxButtons.OK);
                }
                panelAppointmentDetails.Visible = false;
                populateAppointmentDGV();
                
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            panelAppointmentDetails.Visible = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            

            string message = "Are you sure you want to delete?";
            string caption = "Please confirm.";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(this, message, caption, buttons);
            if (result == DialogResult.Yes)
            {
                if (dataGridViewAppointments.SelectedRows.Count > 0)
                {
                    int selectedIndex = dataGridViewAppointments.SelectedRows[0].Index;
                    int rowID = int.Parse(dataGridViewAppointments[0, selectedIndex].Value.ToString());
                    DB.DeleteAppointment(rowID);
                    //update dgv
                    populateAppointmentDGV();
                }
                else
                {
                    MessageBox.Show("Please select a row from the data grid.", "Error", MessageBoxButtons.OK);
                    return;
                }
            }
            else return;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            labelAppointmentDetails.Text = "Update";
            panelAppointmentDetails.Visible = true;

            if (dataGridViewAppointments.SelectedRows.Count > 0)
            {

                
                int selectedIndex = dataGridViewAppointments.SelectedRows[0].Index;
                int appointmentID = int.Parse(dataGridViewAppointments[0, selectedIndex].Value.ToString());
                // populate textboxes in form 
                // show update form 
                selectedAppDictionary = DB.getAppointmentDictionary(appointmentID);
                textBoxAppointmentID.Text = appointmentID.ToString();
                textBoxCustomerID.Text = selectedAppDictionary["customerId"];
                textBoxUserID.Text = selectedAppDictionary["userId"];
                textBoxTitle.Text = selectedAppDictionary["title"];
                textBoxDescription.Text = selectedAppDictionary["description"];
                textBoxLocation.Text = selectedAppDictionary["location"];
                textBoxType.Text = selectedAppDictionary["type"];
                dateTimePickerStart.CustomFormat = selectedAppDictionary["start"];
                dateTimePickerEnd.CustomFormat = selectedAppDictionary["end"];

            }
            else
            {
                MessageBox.Show("Please select a row from the data grid.", "Error", MessageBoxButtons.OK);
                panelAppointmentDetails.Visible = false;
                return;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
