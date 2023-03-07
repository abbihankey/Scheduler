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
            //populate text boxes w selected row

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            
            //get row id and pass into update method
            
            
            
            
            int maxCustomerID = DB.selectMaxID("customer", "customerId");
            int newCustomerID = maxCustomerID + 1;
            int active;
            var createTime = DB.getCurrentTime();
            var username = DB.getUsername();

            bool notEmpty = DB.verifyInput(panelInsertCustomers);
            if (notEmpty == true)
            {
                DB.UpdateCustomer();
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

