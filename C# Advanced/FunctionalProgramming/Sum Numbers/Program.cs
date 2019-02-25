namespace Sum_Numbers
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int sum = nums.Sum();
            Console.WriteLine(nums.Length);
            Console.WriteLine(sum);
        }
    }
}
