namespace _8._Magic_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = int.Parse(Console.ReadLine());

            List<int> bestSum = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                for (int i1 = i + 1; i1 < nums.Length; i1++)
                {
                    if (nums[i] + nums[i1] == n)
                    {
                        Console.WriteLine(nums[i] + " " + nums[i1]);
                    }
                }
            }
        }
    }
}
