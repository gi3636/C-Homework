using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project8
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("FG", "China", "1001", 15236975);
            OrderService orderService = new OrderService();
            orderService.Export();
            orderService.ImportProductList();
            while (true)
            {
                Console.WriteLine("请根据需求选择你要的操作:");
                Console.WriteLine("1.添加货物");
                Console.WriteLine("2.显示货物");
                Console.WriteLine("3.添加订单");
                Console.WriteLine("4.查看订单详情");
                Console.WriteLine("5.查询订单金额");
                Console.WriteLine("6.删除订单");
                Console.WriteLine("7.序列化订单");
                Console.WriteLine("8.载入订单");
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
                        Product product = new Product(orderService.getRandomID().ToString(), productName, productPrice, productQuantity);
                        orderService.addProduct(product);
                        break;
                    case 2:
                        orderService.printProductList();
                        break;
                    case 3:
                        orderService.addOrder(customer);
                        break;
                    case 4:
                        orderService.printOrderItem();
                        break;
                    case 5:
                        orderService.queryOrderById();
                        break;
                    case 6:
                        orderService.deleteOrder();
                        break;
                    case 7:
                        orderService.Export();
                        break;
                    case 8:
                        orderService.Import();
                        break;
                }
            }
        }
    }
}
