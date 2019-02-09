namespace _1._Remove_Negatives_and_Reverse
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> print = nums.Where(x => x > 0).ToList();
            print.Reverse();
            if (print.Count == 0)
            {
                Console.WriteLine("empty");
                return;
            }
            Console.WriteLine(string.Join(" ", print));
        }
    }
}
