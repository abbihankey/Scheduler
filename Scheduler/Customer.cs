using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class Customer
    {
        public int customerId { get; set; }
        public string customerName { get; set; }
        public int addressId { get; set; }
        public int active { get; set; }
        public DateTime createDate { get; set; }
        public DateTime lastUpdate { get; set; }
        public string createdBy { get; set; }
        public string lastUpdateBy { get; set; }

        public Customer(int ID, string name, int address)
        {
            customerId = ID;
            customerName = name;
            address = addressId;
        }

    }
}
