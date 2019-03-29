using System;
using System.Collections.Generic;
using System.Numerics;

namespace Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());           
            int a = 1;
            int b = 1;
            int c = 2;
            if (n == 0)
            {
                Console.WriteLine($"{0}");
                return;
            }
            if (n == 1)
            {
                Console.WriteLine($"{1}");
                return;
            }
            if (n == 2)
            {
                Console.WriteLine($"{1} {1}");
                return;
            }
            if (n == 3)
            {
                Console.WriteLine($"{1} {1} {2}");
                return;
            }
            Console.Write($"{a} {b} {c}");
            for (int i = 4; i <= n; i++)
            {               
                int result = a + b + c;
                Console.Write($" {result}");
                a = b;
                b = c;
                c = result;
            }
            Console.WriteLine();
        }
    }
}
