using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project8
{

  [XmlRoot]
   public class Product
    {
        [XmlAttribute(AttributeName ="ProductID")]
        public String ProductID { get;set; }

        [XmlAttribute(AttributeName = "ProductName")]
        public String ProductName { get; set; }

        [XmlAttribute(AttributeName = "ProductQuantity")]
        public double ProductQuantity { get; set; }

        [XmlAttribute(AttributeName = "ProductPrice")]
        public double ProductPrice { get; set; }

        public Product()
        {
        }

        public Product(string productID, string productName, double productQuantity, double productPrice)
        {
            ProductID = productID;
            ProductName = productName;
            ProductQuantity = productQuantity;
            ProductPrice = productPrice;
        }

        public override string ToString()
        {
            return  ProductName ;
        }
        //public override string ToString()
        //{
        //    return "ID:" + ProductID + " Name:" + ProductName + " Price:" + ProductPrice + " Quantity:" + ProductQuantity;
        //}

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   ProductID == product.ProductID &&
                   ProductName == product.ProductName &&
                   ProductPrice == product.ProductPrice &&
                   ProductQuantity == product.ProductQuantity;
        }

        public override int GetHashCode()
        {
            var hashCode = -2027619230;
            hashCode = hashCode * -1521134295 + ProductID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductName);
            hashCode = hashCode * -1521134295 + ProductPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + ProductQuantity.GetHashCode();
            return hashCode;
        }
    }
}
