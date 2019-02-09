namespace _14._Mixed_up_Lists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> nums2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> range = new List<int>();
            int first = 0;
            int second = 0;
            if (nums1.Count > nums2.Count)
            {
                first = nums1[nums1.Count - 1];
                second = nums1[nums1.Count - 2];
                nums1.RemoveRange(nums1.Count - 2, 2);
            }
            else if (nums1.Count < nums2.Count)
            {
                first = nums2[0];
                second = nums2[1];
                nums2.RemoveRange(0, 2);
            }
            range = nums1.ToList();
            for (int i = 0; i < nums2.Count; i++)
            {
                range.Add(nums2[i]);
            }
            range = range.Where(x => x > first && x < second || x < first && x > second).ToList();
            foreach (var i in range.OrderBy(x => x))
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
