namespace DeleteRange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == n[0])
                {
                    if (n[1] >= nums.Count - i)
                    {
                        nums.RemoveRange(i + 1, nums.Count - i - 1);//
                        nums.RemoveRange(i - n[1], n[1]);
                        nums.Remove(n[0]);
                    }
                    else if (n[1] >= i)
                    {
                        nums.RemoveRange(i + 1, n[1]);
                        nums.RemoveRange(0, i);//
                        nums.Remove(n[0]);
                    }
                    else
                    {
                        nums.RemoveRange(i - n[1], n[1]);
                        nums.RemoveRange(i, n[1]);
                        nums.Remove(n[0]);
                    }
                }
            }
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] != n[0])
                {
                    sum += nums[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
