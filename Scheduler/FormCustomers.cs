using MySql.Data.MySqlClient;
using Scheduler.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class FormCustomers : Form
    {
        public static Dictionary<string, string> selectedCustomerDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> updatedCustomerDictionary = new Dictionary<string, string>();
        public FormCustomers()
        {
            

            InitializeComponent();
            panelUpdateCustomers.Visible = false;
            populateCustomerDGV();


            

        }
        public void populateCustomerDGV()
        {
            //populate data grid
            string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            string sqlString = "SELECT * FROM Customer";
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridViewCustomers.DataSource = dt;
        }
 
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {

            var insertcustomerform = new FormInsertCustomer();
            insertcustomerform.Show();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                
                
                
                
                
                panelUpdateCustomers.Visible = true;
                int selectedIndex = dataGridViewCustomers.SelectedRows[0].Index;
                int customerID = int.Parse(dataGridViewCustomers[0, selectedIndex].Value.ToString());
                // populate textboxes in form DB.getCustomerDetails(customerID);
                // show update form 
                selectedCustomerDictionary = DB.getCustomerDictionary(customerID);
                textBoxCustomerID.Text = customerID.ToString();
                textBoxName.Text = selectedCustomerDictionary["customerName"];
                textBoxAddress.Text = selectedCustomerDictionary["address"];
                textBoxPhone.Text = selectedCustomerDictionary["phone"];
                textBoxCity.Text = selectedCustomerDictionary["city"];
                textBoxCountry.Text = selectedCustomerDictionary["country"];
                textBoxZipCode.Text = selectedCustomerDictionary["postalCode"];
                if (selectedCustomerDictionary["active"] == "True")
                {
                    comboBoxActive.SelectedText = "Yes";
                    return;
                }
                else
                {
                    comboBoxActive.SelectedText = "No";
                    return;
                }

            }
            else
            {
               MessageBox.Show("Please select a row from the data grid.", "Error", MessageBoxButtons.OK);
               return;
            }
            
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
                if (dataGridViewCustomers.SelectedRows.Count > 0)
                {
                    int selectedIndex = dataGridViewCustomers.SelectedRows[0].Index;
                    int rowID = int.Parse(dataGridViewCustomers[0, selectedIndex].Value.ToString());
                    DB.DeleteCustomer(rowID);
                    //update dgv
                    populateCustomerDGV();
                }
                else
                {
                    MessageBox.Show("Please select a row from the data grid.", "Error", MessageBoxButtons.OK);
                    return;
                }
            }
            else return;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            populateCustomerDGV();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            panelUpdateCustomers.Visible = false;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            updatedCustomerDictionary.Add("customerName", textBoxName.Text);
            updatedCustomerDictionary.Add("address", textBoxAddress.Text);
            updatedCustomerDictionary.Add("phone", textBoxPhone.Text);
            updatedCustomerDictionary.Add("city", textBoxCity.Text);
            updatedCustomerDictionary.Add("country", textBoxCountry.Text);
            updatedCustomerDictionary.Add("postalCode", textBoxZipCode.Text);

            if (comboBoxActive.SelectedText == "Yes") 
            {
                updatedCustomerDictionary.Add("active", "True");
            }
            else
            {
                updatedCustomerDictionary.Add("active", "False");
            }

            /* if (DB.UpdateCustomer(updatedCustomerDictionary))
            {
                MessageBox.Show("Update successful. Please refresh the table to view the updates.");
                return;
            }
            else
            {
                MessageBox.Show("Error: Update unsuccessful.");
                return;
            } */
            DB.UpdateCustomer(updatedCustomerDictionary);

        }
    }
}
