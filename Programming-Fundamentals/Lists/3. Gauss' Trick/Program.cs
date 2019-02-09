using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> print = new List<int>();
            if (nums.Count % 2 != 0)
            {
                int lastElement = nums[nums.Count / 2];
                nums.RemoveAt(nums.Count / 2);
                for (int i = 0; i < nums.Count / 2; i++)
                {
                    print.Add(nums[i] + nums[nums.Count - (1 + i)]);
                }
                print.Add(lastElement);
            }
            else
            {
                for (int i = 0; i < nums.Count/ 2; i++)
                {
                    print.Add(nums[i] + nums[nums.Count - (1 + i)]);
                }
            }
            Console.WriteLine(string.Join(" ",print));
        }
    }
}
