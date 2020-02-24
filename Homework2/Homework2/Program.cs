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
            Console.WriteLine();
            Console.Write("请输入埃拉托斯特尼筛法的数：");
            int a = int.Parse(Console.ReadLine());
            IsPrime(a);//埃拉托斯特尼筛法
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

        public static void IsPrime(int n)//埃拉托斯特尼筛法
        {

            bool[] mark = new bool[n + 1]; //用于标记，true表示是素数，false表示非素数

            for (int i = 2; i <= n; i++)
            {
                mark[i] = true;
            }

            for (int i = 2; i < mark.Length; i++)
            {
                if (mark[i] == true)
                {
                    for (int j = i; j * i <= n; j++)
                    {
                        mark[i * j] = false;
                    }
                }
            }

            for (int i = 2; i <= n; i++)
            {
                if (mark[i] == true)
                {
                    Console.WriteLine(i + " ");
                   
                }
            }
        }
    }
}
