namespace Reverse_and_Exclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int n = int.Parse(Console.ReadLine());

            Predicate<int> divisible = x => x % n != 0;
            Func<int, bool> filter = x => divisible(x);

            nums = nums.Where(filter).ToList();
            nums.Reverse();
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
