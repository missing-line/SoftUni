
namespace Print_Even_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(arr.Where(x => x % 2 == 0));

            Console.WriteLine(string.Join(" ",queue.ToArray()));
        }
    }
}
