namespace Sort_Even_Numbers
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[] evens = nums.Where(x => x % 2 == 0).ToArray();

            Console.WriteLine(string.Join(", ", evens.OrderBy(x => x)));
        }
    }
}
