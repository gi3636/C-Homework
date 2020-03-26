using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7
{
    class Customer
    {
        private String CustomerName { get; set; }
        private String CustomerAddress { get; set; }
        public int CustomerID { get; set; }
        private int CustomerPhoneNumber { get; set; }

        public Customer(string customerName, string customerAddress, int customerID, int customerPhoneNumber)
        {
            this.CustomerName = customerName;
            this.CustomerAddress = customerAddress;
            this.CustomerID = customerID;
            this.CustomerPhoneNumber = customerPhoneNumber;
        }

        public override string ToString()
        {
            return "Customer Name:" + CustomerName + " CustomerAddress: " + CustomerAddress + " CustomerID:" + CustomerID + " CustomerPhoneNumber: " + CustomerPhoneNumber;

        }

    

        public override int GetHashCode()
        {
            return CustomerPhoneNumber;
        }
    }
}
