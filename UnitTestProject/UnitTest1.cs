using Project8;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System;

namespace Project8.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        public static int count = 1;
        public static int countOrder = 1;
        public static object _lock = new object();
        OrderItem orderItem = new OrderItem();
        Customer customer = new Customer("FG", "China", "1001", 15236975);
        [XmlAttribute("Product")]
        List<Product> productList = new List<Product>();

        [XmlAttribute("Order")]
        List<Order> orderList = new List<Order>();


        [TestMethod()]
        public void ExportTest()
        {
            XmlSerializer writer = new XmlSerializer(orderList.GetType());
            StreamWriter myWriter = new StreamWriter("OrderList.xml");
            writer.Serialize(myWriter, orderList);
            myWriter.Close();
        }

        [TestMethod()]
        public void ImportTest()
        {
            XmlSerializer mySerializer = new XmlSerializer(orderList.GetType());
            var myFileStream = new FileStream("OrderList.xml", FileMode.Open);
            orderList = (List<Order>)mySerializer.Deserialize(myFileStream);
            foreach (Order p in orderList)
            {
                Console.WriteLine(p);
            }

        }

        //[TestMethod()]
        //public void queryOrderByIdTest()
        //{

        //    var query = from order in orderList
        //                orderby order.SumPrice ascending
        //                select order;

        //    foreach (var q in query)
        //    {
        //        Console.WriteLine(q);
        //    }
        //}

        [TestMethod()]
        public double getRandomIDTest()
        {
            lock (_lock)
            {
                if (count >= 10000)
                {
                    count = 1;
                }
                var number = Double.Parse(DateTime.Now.ToString("yyMMddHHmmss" + count));
                count++;
                return number;
            }
        }

        [TestMethod()]
        public void initialProductListTest()
        {
            Product product1 = new Product(this.getRandomID().ToString(), "Asus Computer", 3000, 50);
            Product product2 = new Product(this.getRandomID().ToString(), "MSI Computer", 4500, 25);
            Product product3 = new Product(this.getRandomID().ToString(), "Alienware Computer", 8000, 8);
            Product product4 = new Product(this.getRandomID().ToString(), "Acer Computer", 2000, 35);
            this.addProductTest(product1);
            this.addProductTest(product2);
            this.addProductTest(product3);
            this.addProductTest(product4);
        }

        private object getRandomID()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void addProductTest(Product product)
        {
            productList.Add(product);
        }

        [TestMethod()]
        public void printProductListTest()
        {
            foreach (Product product in productList)
            {
                Console.WriteLine(product);
            }
        }

        [TestMethod()]
        public void addOrderTest()
        {

            while (true)
            {
                Order order = new Order();
                foreach (Product i in this.productList)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("请问你要买什么？(请输入货物ID)");
                String id = Console.ReadLine();
                foreach (Product product in this.productList)
                {
                    if (product.ProductID == id)
                    {
                        Console.WriteLine("你要买几个?");
                        double k = double.Parse(Console.ReadLine());
                        Console.WriteLine("你确定要买？(Y/N)");
                        Console.WriteLine(product);
                        String anwser = Console.ReadLine();
                        if (anwser == "Y")
                        {
                            order.OrderID = "R" + countOrder.ToString();
                            order.Quantity = k;
                            order.ProductID = product.ProductID;
                            order.CustomerID = customer.CustomerID;
                            order.RequiredDate = DateTime.Now;
                            order.SumPrice = k * product.ProductPrice;
                            product.ProductQuantity = product.ProductQuantity - k;
                            countOrder++;
                            orderList.Add(order);

                        }

                    }

                }
                break;
            }
        }

        [TestMethod()]
        public void printOrderItemTest()
        {
            OrderItem orderItem = new OrderItem();
            double sum = 0;
            orderItem.ProductPrice = 0;
            foreach (Order order in orderList)
            {
                orderItem.OrderID = order.OrderID;
                orderItem.ProductID = order.ProductID;
                orderItem.ProductPrice = order.SumPrice;
                Console.WriteLine(orderItem);
                sum += order.SumPrice;
            }
            Console.WriteLine("总共:" + sum);
        }

        [TestMethod()]
        public void deleteOrderTest()
        {
            try
            {
                Console.WriteLine("请问你要删除哪个？(请输入OrderID)");
                String k = Console.ReadLine();
                orderList.RemoveAll(s => (s.OrderID == k));
            }
            catch (Exception)
            {
                throw new SystemException();
            }
        }

    }

}
