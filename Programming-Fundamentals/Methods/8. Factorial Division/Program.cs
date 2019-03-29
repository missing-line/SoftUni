using System;
using System.Linq;
using System.Collections.Generic;

namespace _8._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            double result = Factorial(first) / Factorial(second);
            Console.WriteLine($"{result:f2}");
            
        }
        public static double Factorial(int currNumber)
        {
            double sum = 1;
            for (int i = 1; i <= currNumber; i++)
            {
                sum *= i;
            }
            return sum;
        }
    }
}
