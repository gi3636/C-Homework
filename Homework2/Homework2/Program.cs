using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入要分解的数：");
            int n = int.Parse(Console.ReadLine());
            Analyze(n);
            Console.ReadKey();
        }

        private static void Analyze(int n)
        {
            Console.Write(n + "的因子有 ");
            while (n % 2 == 0)
            {
                n = n / 2;
                Console.Write("2 ");
            }
            while (n % 3 == 0)
            {
                n = n / 3;
                Console.Write("3 ");
            }
            while(n%5==0)
            {
                n = n / 5;
                Console.Write("5 ");
            }
            for(int i = 5;i <=n*3;i+=6)
            {
                while(n%i==0)
                {
                    n = n / i;
                    Console.Write(i + " ");
                }
                while (n % (i + 2) == 0)
                {
                    n = n / (i + 2);
                    Console.Write((i + 2) + " ");
                }
            }
        }
    }
}
