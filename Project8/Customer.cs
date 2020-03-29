using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project8
{
  public  class Customer
    {
        public String CustomerName { get; set; }
        public String CustomerID { get; set; }
        public String CustomerAddress { get; set; }
        public double CustomerPhoneNumber { get; set; }

        public Customer(string customerName, string customerID, string customerAddress, double customerPhoneNumber)
        {
            CustomerName = customerName;
            CustomerID = customerID;
            CustomerAddress = customerAddress;
            CustomerPhoneNumber = customerPhoneNumber;
        }
    }
}
