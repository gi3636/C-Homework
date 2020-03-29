using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Project8
{
    //    写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
    //提示：主要的类有Order（订单）、OrderItem（订单明细项），OrderService（订单服务），订单数据可以保存在OrderService中一个List中。在Program里面可以调用OrderService的方法完成各种订单操作。
    //要求：
    //（1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
    //（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
    //（3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
    //（4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
    //（5）OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。

    //1、在OrderService中添加一个Export方法，可以将所有的订单序列化为XML文件；添加一个Import方法可以从XML文件中载入订单。
    //2、对订单程序中OrderService的各个Public方法添加测试用例。

   public class OrderService
    {
        public static int count = 1;
        public static int countOrder = 1;
        public static object _lock = new object();

        [XmlAttribute("Product")]
        List<Product> productList = new List<Product>();

        [XmlAttribute("Order")]
        List<Order> orderList = new List<Order>();


        public void Export()
        {
            XmlSerializer writer = new XmlSerializer(orderList.GetType());
            StreamWriter myWriter = new StreamWriter("OrderList.xml");
            writer.Serialize(myWriter, orderList);
            myWriter.Close();
        }
        public void Import()
        {
            XmlSerializer mySerializer = new XmlSerializer(orderList.GetType());           
            var myFileStream = new FileStream("OrderList.xml", FileMode.Open);
            orderList = (List<Order>)mySerializer.Deserialize(myFileStream);
            foreach (Order p in orderList)
            {
                Console.WriteLine(p);
            }
        }

    public void queryOrderById()
        {
            
            var query = from order in orderList
                        orderby order.SumPrice ascending
                        select order;

            foreach(var q in query)
            {
                Console.WriteLine(q);
            }
        }

        public double getRandomID()//获得唯一单号
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

        public void initialProductList()
        {
            Product product1 = new Product(this.getRandomID().ToString(), "Asus Computer", 3000, 50);
            Product product2 = new Product(this.getRandomID().ToString(), "MSI Computer", 4500, 25);
            Product product3 = new Product(this.getRandomID().ToString(), "Alienware Computer", 8000, 8);
            Product product4 = new Product(this.getRandomID().ToString(), "Acer Computer", 2000, 35);
            this.addProduct(product1);
            this.addProduct(product2);
            this.addProduct(product3);
            this.addProduct(product4);
        }
        public void addProduct(Product product)//添加产品
        {
            productList.Add(product);
        }

        public void printProductList()
        {
            foreach(Product product in productList)
            {
                Console.WriteLine(product);
            }
        }

        public void addOrder(Customer customer)
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

        public void printOrderItem()
        {
            OrderItem orderItem = new OrderItem();
            double sum = 0;
            orderItem.ProductPrice = 0;
            foreach(Order order in orderList)
            {
                orderItem.OrderID = order.OrderID;
                orderItem.ProductID = order.ProductID;
                orderItem.ProductPrice = order.SumPrice;
                Console.WriteLine(orderItem);
                sum += order.SumPrice;
            }
            Console.WriteLine("总共:" + sum);

        }

        public void deleteOrder()
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
