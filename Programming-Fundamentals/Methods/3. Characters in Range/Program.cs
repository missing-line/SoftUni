using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            PrintCharsInRange(a, b);           
        }
        public static void PrintCharsInRange(string a,string b)
        {
            List<char> printRange = new List<char>();
            int one = a[0];
            int two = b[0];
            if (one <= two)
            {
                for (int i = one + 1; i < two; i++)
                {
                    printRange.Add((char)i);
                }
                Console.WriteLine(string.Join(" ", printRange));
            }
            else
            {
                for (int i = two + 1; i < one; i++)
                {
                    printRange.Add((char)i);
                }
                Console.WriteLine(string.Join(" ", printRange));
            }
            
        }
    }
}
