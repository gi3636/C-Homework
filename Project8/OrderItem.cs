using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project8
{
   public  class OrderItem
    {
        public String OrderID { get; set; }
        public String ProductID { get; set; }
        public double ProductPrice { get; set; }

        public OrderItem()
        {

        }
        public override bool Equals(object obj)
        {
            OrderItem order1 = obj as OrderItem;
            return (order1 != null && order1.OrderID == OrderID && order1.ProductID == ProductID && order1.ProductPrice == ProductPrice);
        }

        public override int GetHashCode()
        {
            var hashCode = -2027619230;
            hashCode = hashCode * -1521134295 + OrderID.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "OrderID:" + OrderID + " ProductID:" + ProductID + " ProductPrice:" + ProductPrice;
        }
    }
}