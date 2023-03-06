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
        public FormCustomers()
        {

            InitializeComponent();
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
            /*
            try
            {
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            */

            /*
               if (txt_Name.Text != "" && txt_State.Text != "")
            {
                cmd = new SqlCommand("insert into tbl_Record(Name,State) values(@name,@state)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@name", txt_Name.Text);
                cmd.Parameters.AddWithValue("@state", txt_State.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Inserted Successfully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            */


            /*
            int min;
            int max;
            decimal price;
            int instock;

            //exception handling (check input aswell)
            try
            {
                instock = int.Parse(maskedTextBoxInStock.Text);
                price = decimal.Parse(maskedTextBoxPrice.Text);
                min = int.Parse(maskedTextBoxMin.Text);
                max = int.Parse(maskedTextBoxMax.Text);
            }
            catch
            {
                MessageBox.Show("Make sure inventory, max, min, and price are numbers. Please make the necessary changes and try again.");
                return;
            }
            if (max < min)
            {
                MessageBox.Show("Make sure max is greater than min. Please make the necessary changes and try again.");
                return;

            }
            if (instock > max)
            {
                MessageBox.Show("Make sure stock is between max and min. Please make the necessary changes and try again.");
                return;
            }
            if (instock < min)
            {
                MessageBox.Show("Make sure stock is between max and min. Please make the necessary changes and try again.");
                return;
            }

            //parse from textbox
            int id = int.Parse(maskedTextBoxID.Text);
            string name = maskedTextBoxName.Text;
            instock = int.Parse(maskedTextBoxInStock.Text);
            price = decimal.Parse(maskedTextBoxPrice.Text);
            min = int.Parse(maskedTextBoxMin.Text);
            max = int.Parse(maskedTextBoxMax.Text);


            if (radioButtonInHouse.Checked)
            {

                var uniquePartID = Inventory.Parts.Count + 1;
                foreach (Part part in Inventory.Parts)
                {
                    if (part.PartID == uniquePartID)
                    {
                        uniquePartID++;
                    }
                }

                bool success = int.TryParse(maskedTextBoxCompanyOrMachine.Text, out int machineID);
                if (success)
                {
                    Inhouse inhousePart = new Inhouse(uniquePartID, name, price, instock, max, min, machineID);
                    Inventory.AddPart(inhousePart);
                }
                else
                {
                    MessageBox.Show("Machine ID must be a number. Please enter a numerical value and try again.");
                    return;
                }


            }
            else
            {

                var uniquePartID = Inventory.Parts.Count + 1;
                foreach (Part part in Inventory.Parts)
                {
                    if (part.PartID == uniquePartID)
                    {
                        uniquePartID++;

                    }
                }
                bool success = int.TryParse(maskedTextBoxCompanyOrMachine.Text, out int company);
                if (success)
                {
                    MessageBox.Show("Company name cannot be a number. Please enter a string value and try again.");
                    return;
                }
                else
                {
                    Outsourced outsourcedPart = new Outsourced((uniquePartID), name, price, instock, max, min, maskedTextBoxCompanyOrMachine.Text);
                    Inventory.AddPart(outsourcedPart);
                }


            }
            panelCustomerDetails.Visible = false;
            */
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {

            var insertcustomerform = new FormInsertCustomer();
            insertcustomerform.Show();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

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
    }
}
