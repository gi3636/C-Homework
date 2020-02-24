using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkQ2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array;
            Console.WriteLine("请输入数组长度：");
            int n = int.Parse(Console.ReadLine());
            array = new int[n];
            for(int i=0;i<n;i++)
            {
                Console.WriteLine("请输入第" + (i + 1) + "元素：");
                array[i] = int.Parse(Console.ReadLine());
            }
            for(int k=0;k<n;k++)
            {
                Console.WriteLine("第" + (k + 1) + "元素: "+array[k]);
            }
            ArrayFun(array);
            Console.ReadKey();
        }

        static void ArrayFun(int []array)
        {
            int max=array[0];
            int min = array[0];
            int sum = 0;
            for (int j=1;j<array.Length;j++)
            {
                 max = max>array[j]?max:array[j];

            }
            Console.WriteLine("最大数为："+max.ToString());

            for (int j = 1; j < array.Length; j++)
            {
                min = min < array[j] ? min : array[j];

            }
            Console.WriteLine("最小数为：" + min.ToString());

            for (int j = 0; j < array.Length; j++)
            {
                sum += array[j];

            }
            int avg = sum / array.Length;
            Console.WriteLine("总数为：" + sum.ToString());
            Console.WriteLine("平均数为：" + avg.ToString());
        }
    }
}
