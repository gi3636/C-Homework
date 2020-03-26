using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project7
{
    class OrderService
    {
        public static int count = 1;
        public static int countOrder = 1;
        public static object _lock = new object();
        List<Product> productList = new List<Product>();
        List<Order> orderList = new List<Order>();


        public double  getRandomID()
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
        public void addProduct(Product products)
        {
            this.productList.Add(products);
        }

        public void deleteProduct()
        {
            try{
                Console.WriteLine("请问你要删除哪个？(请输入货物ID)");
                double k = double.Parse(Console.ReadLine());
                productList.RemoveAll(s => (s.ProductID == k));
            }
            catch (Exception)
            {
                throw new SystemException();
            }
        }

        public void deleteOrder()
        {
            try { 
            Console.WriteLine("请问你要删除哪个？(请输入OrderID)");
            double k = double.Parse(Console.ReadLine());
            orderList.RemoveAll(s => (s.OrderID == k));
            }
            catch (Exception)
            {
                throw new SystemException();
            }
        }
        public void printProductList(OrderService orderService)
        {
            foreach (Product i in orderService.productList)
            {
                Console.WriteLine(i);
            }
        }

        public void printOrder()
        {
            foreach (Order o in this.orderList)
            {
                Console.WriteLine(o);
            }
        }



        public void addOrder(Order order,Customer customer)
        {
            order.customer1 = customer;
            while (true)
            {
                foreach (Product i in this.productList)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("请问你要买什么？(请输入货物ID)");
                double n = Double.Parse(Console.ReadLine());
                foreach(Product i in this.productList)
                {
                    if (i.ProductID == n)
                    {
                        Console.WriteLine("你要买几个?");
                        int k=int.Parse(Console.ReadLine());
                        Console.WriteLine("你确定要买？(Y/N)");
                        Console.WriteLine(i);
                        String anwser =Console.ReadLine();
                        if (anwser == "Y")
                        {
                            order.product1 = i;
                            order.Quantity = k;
                            order.OrderID = countOrder;
                            order.RequiredDate = DateTime.Now;
                            countOrder++;
                            orderList.Add(order);
                        }
                    }
   
                }
                break;
                   
            }
        }
        public void sumOrderList()
        {
            double sum = 0;
            foreach(Order o in orderList)
            {
                sum += o.product1.ProductPrice*o.Quantity;
                o.product1.ProductQuantity=o.product1.ProductQuantity - o.Quantity;
            }
            Console.WriteLine("总结算："+sum);
        }
    }
}
