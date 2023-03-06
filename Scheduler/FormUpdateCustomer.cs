using Scheduler.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class FormUpdateCustomer : Form
    {

        public FormUpdateCustomer()
        {


            InitializeComponent();

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {

            int maxCustomerID = DB.selectMaxID("customer", "customerId");
            int newCustomerID = maxCustomerID + 1;
            int active;
            var createTime = DB.getCurrentTime();
            var username = DB.getUsername();

            bool notEmpty = DB.verifyInput(panelInsertCustomers);
            if (notEmpty == true)
            {
                if (comboBoxActive.SelectedText == "Yes")
                {
                    active = 1;
                }
                else
                {
                    active = 0;
                }

                var currentTime = DB.getCurrentTime();
                int country = DB.insertCountry(textBoxCountry.Text);
                int city = DB.insertCity(country, textBoxCity.Text);
                int address = DB.insertAddress(city, textBoxAddress.Text, textBoxPhone.Text, textBoxZipCode.Text);
                DB.insertCustomer(newCustomerID, textBoxName.Text, address, active, createTime, username);
            }
            else
            {
                MessageBox.Show("Please input into all textboxes.", "Error", MessageBoxButtons.OK);
            }

        }

        private void labelCustomerDetails_Click(object sender, EventArgs e)
        {

        }
    }
}

