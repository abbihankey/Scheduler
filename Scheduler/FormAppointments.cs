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
            dateTimePickerEnd.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dateTimePickerStart.CustomFormat = "MM/dd/yyyy hh:mm tt";
            //string username = new FormMainMenu.Get_LoginUsername();

            FormMainMenu formMainMenu = new FormMainMenu();
            string username = formMainMenu.textBoxUsername.Text;
            int userID = DB.selectUserID(username);



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

            //not using, using cell formatting event handler instead
            /*
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                dt.Rows[index]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[index]["start"], TimeZoneInfo.Local).ToString();
            }
            for (int index = 0; index < dt.Rows.Count; index++)
            {

                var end = dt.Rows[index]["end"];
                // dt.Rows[index]["end"] = end.ToLocalTime();
            }
            */




        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            panelAppointmentDetails.Visible = true;
            labelAppointmentDetails.Text = "Insert";
            textBoxTitle.Clear();
            textBoxDescription.Clear();
            textBoxAppointmentID.Clear();
            textBoxCustomerID.Clear();
            //textBoxUserID.Clear();
            textBoxTitle.Clear();
            textBoxDescription.Clear();
            textBoxLocation.Clear();
            textBoxType.Clear();
            int maxAppID = DB.selectMaxID("appointment", "appointmentId");
            int newAppID = maxAppID + 1;
            textBoxAppointmentID.Text = newAppID.ToString();


        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            DateTime start = dateTimePickerStart.Value;
            DateTime UTCStart = start.ToUniversalTime();

            DateTime end = dateTimePickerEnd.Value;
            DateTime UTCEnd = end.ToUniversalTime();
            
            //expression lambda using func delegate that makes sure the start and end picker values are on the same date
            //inline declaration reduces total lines in program, did not have to create another function in DB class
            //function only called once, not worth the extra lines to create a full class
            Func<DateTime, DateTime, bool> testForEquality = (x, y) => x.Date == y.Date;
            var equal = testForEquality(UTCEnd, UTCStart);

            if(equal == true)
            {
                try
                {
                    Convert.ToInt32(textBoxCustomerID.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Customer ID must be a number.", "Error", MessageBoxButtons.OK);
                    return;
                }
                var inputID = textBoxCustomerID.Text;

                if (DB.isExistingCustomer(inputID) == true)
                {
                    if (labelAppointmentDetails.Text == "Update")
                    {
                        DB.checkBusinessHours(UTCStart, UTCEnd);
                        
                        bool withinBusinessHours = DB.checkBusinessHours(UTCStart, UTCEnd);

                        if (withinBusinessHours == true)
                        {
                            
                            
                           updatedAppDictionary.Add("customerId", textBoxCustomerID.Text);
                           updatedAppDictionary.Add("title", textBoxTitle.Text);
                           updatedAppDictionary.Add("description", textBoxDescription.Text);
                           updatedAppDictionary.Add("location", textBoxLocation.Text);
                           updatedAppDictionary.Add("type", textBoxType.Text);

                           updatedAppDictionary.Add("start", UTCStart.ToString());
                           updatedAppDictionary.Add("end", UTCEnd.ToString());


                           DB.UpdateAppointment(updatedAppDictionary, selectedAppDictionary);
                           panelAppointmentDetails.Visible = false;
                           populateAppointmentDGV();
                            
                        }
                        else
                        {
                            MessageBox.Show("Please input into all textboxes.", "Error", MessageBoxButtons.OK);
                        }


                    }
                    else
                    {

                        //FORMAT TO UTC
                        //DateTime start = dateTimePickerStart.Value;
                        //DateTime UTCStart = start.ToUniversalTime();

                        //DateTime end = dateTimePickerEnd.Value;
                        //DateTime UTCEnd = end.ToUniversalTime();


                        bool overlap = DB.isOverlaping(UTCStart, UTCEnd);
                        bool withinBusinessHours = DB.checkBusinessHours(UTCStart, UTCEnd);
                        int maxAppID = DB.selectMaxID("appointment", "appointmentId");
                        int newAppID = maxAppID + 1;
                        textBoxAppointmentID.Text = newAppID.ToString();
                        var createTime = DB.getCurrentTime();
                        //var username = DB.getUsername();
                        bool notEmpty = DB.verifyInput(panelAppointmentDetails);
                        

                        if (withinBusinessHours == true)
                        {
                            if (overlap == true)
                            {
                                MessageBox.Show("The start/end dates you selected overlap currently scheduled appointments. Please make changes and try again.");
                            }
                            else
                            {
                                if (notEmpty == true)
                                {

                                    int custID = Convert.ToInt32(textBoxCustomerID.Text);
                                    string title = textBoxTitle.Text;
                                    string description = textBoxDescription.Text;
                                    string location = textBoxLocation.Text;
                                    string type = textBoxType.Text;
                                    ////FORMAT TO UTC
                                    //DateTime start = DateTime.Parse(dateTimePickerStart.CustomFormat);
                                    //DateTime UTCStart = start.ToUniversalTime();

                                    //DateTime end = DateTime.Parse(dateTimePickerEnd.CustomFormat);
                                    //DateTime UTCEnd = end.ToUniversalTime();



                                    DB.insertAppointment(newAppID, custID, title, description, location, type, UTCStart, UTCEnd);
                                }
                                else
                                {
                                    MessageBox.Show("Please input into all textboxes.", "Error", MessageBoxButtons.OK);
                                }
                                panelAppointmentDetails.Visible = false;
                                populateAppointmentDGV();
                            }
                        }
                        else
                        {
                            MessageBox.Show("The start / end dates you selected are outside of business hours (9 AM to 5 PM). Please make changes and try again.", "Error", MessageBoxButtons.OK);
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Please use the ID of an existing customer or create a new one with the desired ID on the Customer tab.", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Please select appointment values for start and end on the same date.", "Error", MessageBoxButtons.OK);
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
                // textBoxUserID.Text = selectedAppDictionary["userId"];
                textBoxTitle.Text = selectedAppDictionary["title"];
                textBoxDescription.Text = selectedAppDictionary["description"];
                textBoxLocation.Text = selectedAppDictionary["location"];
                textBoxType.Text = selectedAppDictionary["type"];
                dateTimePickerStart.Value = DateTime.Parse(selectedAppDictionary["start"]).ToLocalTime();
                dateTimePickerEnd.Value = DateTime.Parse(selectedAppDictionary["end"]).ToLocalTime();

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

        private void dataGridViewAppointments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (e.Value is DateTime)
            {
                var UTCdate = (DateTime)e.Value;
                var localDate = UTCdate.ToLocalTime();
                e.Value = localDate;
            }
            
        }

        private void panelAppointmentDetails_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBoxType_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
