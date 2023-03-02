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
    public partial class FormInsertCustomer : Form
    {
        public FormInsertCustomer()
        {
            InitializeComponent();
        }
        
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int maxCustomerID = DB.selectMaxID("customer", "customerId");
            int newCustomerID = maxCustomerID++;
            int active;
            

            
            bool notEmpty = DB.verifyInput(panelInsertCustomers);
            if (notEmpty == true)
            {
                int country = DB.insertCountry(textBoxCountry.Text);
                int city = DB.insertCity(country, textBoxCity);
                int address = DB.insertAddress(city, textBoxAddress.Text, textBoxPhone.Text)
                DB.insertCustomer(newCustomerID, textBoxName.Text, address, )
            }
            else
            {
                MessageBox.Show("Please input into all textboxes.", "Error", MessageBoxButtons.OK);
            }
        
        }
    
    
    }
}

