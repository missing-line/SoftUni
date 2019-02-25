namespace _01.Socks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] firstSocks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] secondSocks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Array.Reverse(secondSocks);

            Stack<int> first = new Stack<int>(firstSocks);
            Stack<int> second = new Stack<int>(secondSocks);

            List<int> pairs = new List<int>();

            while (first.Count != 0 && second.Count != 0)
            {
                int num1 = first.Pop();
                int num2 = second.Pop();
                if (num1 == num2)
                {
                    num1++;
                    first.Push(num1);
                }
                else if (num1 < num2)
                {
                    second.Push(num2);
                }
                else if (num1 > num2)
                {
                    num1 += num2;
                    pairs.Add(num1);
                }
            }
            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(" ",pairs));
        }
    }
}
