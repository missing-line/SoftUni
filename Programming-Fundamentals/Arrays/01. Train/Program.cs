namespace _1._Train
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int curr = int.Parse(Console.ReadLine());
                nums[i] = curr;
                sum += curr;
            }
            Console.WriteLine(string.Join(" ", nums));
            Console.WriteLine(sum);
        }
    }
}
