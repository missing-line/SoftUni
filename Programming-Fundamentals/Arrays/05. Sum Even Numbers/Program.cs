namespace _05._Sum_Even_Numbers
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(string.Join(" ", nums.Where(x => x % 2 == 0).Sum()));
        }
    }
}
