using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    public class Node<T>
    {
        
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
            
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        static int count = 0;
        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
            count++;
        }
      
        public void copyForeach(Action<T> action)
        {
            for (Node<T> node = this.Head; node != null; node = node.Next)
            {
                action(node.Data);
            }
        }
    }


    class Program
    {
        static int sum = 0; 
        static int max = 0;
        static int min = 0;
        //1、为示例中的泛型链表类添加类似于List<T>类的ForEach(Action<T> action)方法。通过调用这个方法打印链表元素，求最大值、最小值和求和（使用lambda表达式实现）。

          
        static void Main(string[] args)
        {         
            GenericList<int> initlist = new GenericList<int>();
            for(int x=0;x<10;x++)
            {
                initlist.Add(x);
            }
            initlist.Add(int.Parse("10"));

            initlist.copyForeach(x=>Console.WriteLine(x));
            initlist.copyForeach(i => sum += i);
            Console.WriteLine("sum="+sum);
            Action<int> maxAction = delegate (int num)
              {
                  if (num > max)
                  {
                      max = num;
                  }
              };
            initlist.copyForeach(maxAction);
            Console.WriteLine("max=" + max);
            Action<int> minAction = delegate (int num)
            {
                if (num < min)
                {
                    min = num;
                }
            };
            initlist.copyForeach(minAction);
            Console.WriteLine("min=" + min);
            Console.ReadLine();
        }

        
    }
}
