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
