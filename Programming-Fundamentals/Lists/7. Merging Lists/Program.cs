using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> nums2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> print = new List<int>();
            int min = Math.Min(nums1.Count,nums2.Count);

            for (int i = 0; i < min; i++)
            {
                print.Add(nums1[i]);
                print.Add(nums2[i]);
            }
            if (nums1.Count > nums2.Count)
            {
                nums1.RemoveRange(0, min);
                print.AddRange(nums1);
            }
            else if (nums1.Count < nums2.Count)
            {
                nums2.RemoveRange(0, min);
                print.AddRange(nums2);
            }
            Console.WriteLine(string.Join(" ",print));
        }
    }
}
