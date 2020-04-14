using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project8
{
    [Serializable]
   public class Order
    {
        
        [XmlAttribute]
        public String OrderID { get; set; }

        [XmlAttribute]
        public String CustomerName { get; set; }

        [XmlAttribute]
        public String ProductName { get; set; }

        [XmlAttribute]
        public  DateTime RequiredDate { get; set; }

        [XmlAttribute]
        public double SumPrice { get; set; }

        [XmlAttribute]
        public double Quantity { get; set; }

        public Order()
        {

        }
        public Order(string orderID, string customerName, string productName, DateTime requiredDate, double sumPrice, double quantity)
        {
            OrderID = orderID;
            CustomerName = customerName;
            ProductName = productName;
            RequiredDate = requiredDate;
            SumPrice = sumPrice;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return "OrderID:" + OrderID + " CustomerName:" + CustomerName + " ProductName:" + ProductName + " RequiredDate:" + RequiredDate +" Quantity:"+Quantity+ " SumPrice:" + SumPrice; 
        }

        public override bool Equals(object obj)
        {
            Order order1 = obj as Order;
            return (order1 != null && order1.OrderID == OrderID &&  order1.Quantity == Quantity && order1.RequiredDate == RequiredDate &&order1.ProductName == ProductName && order1.SumPrice==SumPrice);
        }

        public override int GetHashCode()
        {
            var hashCode = -2027619230;
            hashCode = hashCode * -1521134295;
            return hashCode;
        }

        
    }

}
