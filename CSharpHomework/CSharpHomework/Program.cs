using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1;
            int number2;
            Console.WriteLine("Please input the number.");
            number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please input the second number.");
            number2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type the symbol of the arithmetic you want.");
            String symbol = Console.ReadLine();
            switch(symbol)
            {
                case "+":
                    Console.WriteLine(number1+"+"+number2+"="+(number1+number2));
                    break;
                case "-":
                    Console.WriteLine(number1 + "-" + number2 + "=" + (number1 - number2));
                    break;
                case "*":
                    Console.WriteLine(number1 + "*" + number2 + "=" + (number1 * number2));
                    break;
                case "/":
                    Console.WriteLine(number1 + "/" + number2 + "=" + (number1 / number2));
                    break;
            }
            Console.ReadKey();
        }
    }
}
