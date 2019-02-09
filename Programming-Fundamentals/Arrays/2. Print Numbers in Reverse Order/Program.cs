namespace _2._Print_Numbers_in_Reverse_Order
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                int curr = int.Parse(Console.ReadLine());
                nums[i] = curr;
            }

            int[] print = new int[n];
            var count = 0;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                print[count] = nums[i];
                count++;
            }
            Console.WriteLine(string.Join(" ", print));
        }
    }
}
