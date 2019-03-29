using System;
using System.Linq;

namespace Problem_5.__Odd_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int result = 0;
            foreach (var number in numbers)
            {
                result ^= number;
            }
            Console.WriteLine(result);
        }
    }
}
