using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project8
{
   public  class OrderItem
    {
        public List<Order> List { get; set; }
        public String OrderID { get; set; }
        public String CustomerName { get; set; }
        public double ProductPrice { get; set; }
        public DateTime RequiredDate { get; set; }

      
        public OrderItem(List<Order> list, string orderID, string customerName, double productPrice, DateTime requiredDate)
        {
            List = list;
            OrderID = orderID;
            CustomerName = customerName;
            ProductPrice = productPrice;
            RequiredDate = requiredDate;
        }

        public OrderItem()
        {

        }
        public List<Order> getOrderList()
        {
            return List;
        }
        public override bool Equals(object obj)
        {
            OrderItem order1 = obj as OrderItem;
            return (order1 != null && order1.OrderID == OrderID && order1.CustomerName == CustomerName && order1.ProductPrice == ProductPrice);
        }

        public override int GetHashCode()
        {
            var hashCode = -2027619230;
            hashCode = hashCode * -1521134295;
            return hashCode;
        }

        public override string ToString()
        {
            return "OrderID:" + OrderID + " CustomerName:" + CustomerName + " ProductPrice:" + ProductPrice;
        }
    }
}