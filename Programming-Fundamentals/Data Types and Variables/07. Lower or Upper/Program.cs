using System;
using System.Linq;

namespace _07._Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            string letter = Console.ReadLine();
            if (letter.Any(char.IsUpper))
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
