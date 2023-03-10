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
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (labelAppointmentDetails.Text == "Update")
            {
                
                /* 
                updatedAppDictionary.Add("customerName", textBoxName.Text);
                updatedAppDictionary.Add("address", textBoxAddress.Text);
                updatedAppDictionary.Add("phone", textBoxPhone.Text);
                updatedAppDictionary.Add("city", textBoxCity.Text);
                updatedAppDictionary.Add("country", textBoxCountry.Text);
                

                if (comboBoxActive.SelectedText == "Yes")
                {
                    updatedCustomerDictionary.Add("active", "1");
                }
                else
                {
                    updatedCustomerDictionary.Add("active", "0");
                }
                DB.UpdateAppointment(updatedAppDictionary, selectedAppDictionary);
                panelCustomers.Visible = false;
                populateCustomerDGV(); 
                */
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
                    /*
                    var currentTime = DB.getCurrentTime();
                    int country = DB.insertCountry(textBoxCountry.Text);
                    int city = DB.insertCity(country, textBoxCity.Text);
                    int address = DB.insertAddress(city, textBoxAddress.Text, textBoxPhone.Text, textBoxZipCode.Text);
                    DB.insertCustomer(newCustomerID, textBoxName.Text, address, active, createTime, username);
                    */
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
            
        }
    }
}
