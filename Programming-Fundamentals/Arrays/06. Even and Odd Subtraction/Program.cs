namespace _06._Even_and_Odd_Subtraction
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sumEven = nums.Where(x => x % 2 == 0).Sum();

            int sumOdd = nums.Where(x => x % 2 != 0).Sum();

            Console.WriteLine(sumEven - sumOdd);
        }
    }
}
