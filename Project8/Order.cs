using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project8
{
   public class Order
    {
        [XmlAttribute]
        public String OrderID { get; set; }

        [XmlAttribute]
        public String CustomerID { get; set; }

        [XmlAttribute]
        public String ProductID { get; set; }

        [XmlAttribute]
        public  DateTime RequiredDate { get; set; }

        [XmlAttribute]
        public double SumPrice { get; set; }

        [XmlAttribute]
        public double Quantity { get; set; }

        public Order()
        {

        }
        public Order(string orderID, string customerID, string productID, DateTime requiredDate, double sumPrice, double quantity)
        {
            OrderID = orderID;
            CustomerID = customerID;
            ProductID = productID;
            RequiredDate = requiredDate;
            SumPrice = sumPrice;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return "OrderID:" + OrderID + " CustomerID:" + CustomerID + " ProductID:" + ProductID + " RequiredDate:" + RequiredDate +" Quantity:"+Quantity+ " SumPrice:" + SumPrice; 
        }

        public override bool Equals(object obj)
        {
            Order order1 = obj as Order;
            return (order1 != null && order1.OrderID == OrderID &&  order1.Quantity == Quantity && order1.RequiredDate == RequiredDate &&order1.ProductID==ProductID &&order1.SumPrice==SumPrice);
        }

        public override int GetHashCode()
        {
            var hashCode = -2027619230;
            hashCode = hashCode * -1521134295 + OrderID.GetHashCode();
            return hashCode;
        }

        
    }

}
