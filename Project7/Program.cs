using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project7
{
    /*写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
提示：主要的类有Order（订单）、OrderItem（订单明细项），OrderService（订单服务），订单数据可以保存在OrderService中一个List中。在Program里面可以调用OrderService的方法完成各种订单操作。
要求：
（1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
（3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
（4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
（5）OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。
*/

    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("FG","China",1001,15236975);
            OrderService orderService = new OrderService();
            Product product1 = new Product(orderService.getRandomID(), "Asus Computer", 3000, 50);
            Product product2 = new Product(orderService.getRandomID(), "MSI Computer", 4500, 25);
            Product product3 = new Product(orderService.getRandomID(), "Alienware Computer", 8000, 8);
            Product product4 = new Product(orderService.getRandomID(), "Acer Computer", 2000, 35);
            orderService.addProduct(product1);
            orderService.addProduct(product2);
            orderService.addProduct(product3);
            orderService.addProduct(product4);
            while (true)
            {
                Console.WriteLine("请根据需求选择你要的操作:");
                Console.WriteLine("1.添加货物");
                Console.WriteLine("2.显示货物");
                Console.WriteLine("3.添加订单");
                Console.WriteLine("4.查看订单详情");
                Console.WriteLine("5.订单总结算");
                Console.WriteLine("6.删除货物");
                Console.WriteLine("7.删除订单");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("请输入货物名称:");
                        String productName = Console.ReadLine();
                        Console.WriteLine("请输入物品价钱:");
                        double productPrice = double.Parse(Console.ReadLine());
                        Console.WriteLine("货物的数量");
                        int productQuantity = int.Parse(Console.ReadLine());
                        Product product = new Product(orderService.getRandomID(), productName, productPrice, productQuantity);
                        orderService.addProduct(product);
                        
                        break;
                    case 2:
                        orderService.printProductList(orderService);
                        break;
                    case 3:
                        Order order = new Order();
                        orderService.addOrder(order, customer);
                        break;
                    case 4:
                        orderService.printOrder();
                        break;
                    case 5:
                        orderService.sumOrderList();
                        break;
                    case 6:
                        orderService.deleteProduct();
                        break;
                    case 7:
                        orderService.deleteOrder();
                        break;
                }
            }
        }
    }

}
