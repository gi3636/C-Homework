using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7
{
    class Order
    {
        public int OrderID { get; set; }
  
        public int Quantity { get;set; }
        public DateTime RequiredDate { get; set; }

        public Product product1;

        public Customer customer1;

        public Order()
        {
        }

        public override string ToString()
        {
            return " OrderID:" + OrderID + " CustomerID:" + customer1.CustomerID+" Product:" + product1.ProductName +" Quantity:" + Quantity + " RequiredDate:" + RequiredDate;
        }

        public override bool Equals(object obj)
        {
            Order order1 = obj as Order;
                return (order1 != null && order1.OrderID == OrderID &&order1.product1==product1 && order1.Quantity==Quantity && order1.customer1==customer1 && order1.RequiredDate == RequiredDate);
        }

        public override int GetHashCode()
        {
            return OrderID + customer1.CustomerID;
        }



    }
}
