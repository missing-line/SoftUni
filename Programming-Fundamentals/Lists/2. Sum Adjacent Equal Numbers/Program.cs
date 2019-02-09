namespace _2._Sum_Adjacent_Equal_Numbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine().Split().Select(double.Parse).ToList();
            while (true)
            {
                bool print = true;
                for (int i = 0; i < nums.Count - 1; i++)
                {
                    if (nums[i] == nums[i + 1])
                    {
                        nums[i] += nums[i + 1];
                        nums.RemoveAt(i + 1);
                        print = false;
                        break;
                    }
                }
                if (print)
                {
                    break;
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
