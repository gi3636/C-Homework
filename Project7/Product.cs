using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7
{
    class Product
    {
        public double ProductID { get; set; }
        public String ProductName { get; set; }
        public Double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }

        public Product(double productID, string productName, double productPrice, int productQuantity)
        {
            ProductID = productID;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductQuantity = productQuantity;
        }
        public Product()
        {

        }
        public Product createProduct()
        {
            return new Product();
        }

        public override string ToString()
        {
            return "ID: "+ProductID +" Name: " + ProductName+" Price: "+ProductPrice+" Quantity: "+ProductQuantity;
        }

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
