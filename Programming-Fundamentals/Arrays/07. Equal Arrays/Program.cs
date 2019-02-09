namespace _07._Equal_Arrays
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] nums2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool isEquals = true;
            int n = 0;

            for (int i = 0; i < nums1.Length; i++)
            {
                for (int i1 = i; i1 < nums2.Length; i1++)
                {
                    if (nums1[i] != nums2[i1])
                    {
                        n = i1;
                        isEquals = false;
                        break;
                    }
                    break;
                }
                if (!isEquals)
                {
                    break;
                }
            }
            if (isEquals)
            {
                Console.WriteLine($"Arrays are identical. Sum: {nums1.Sum()}");
            }
            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {n} index");
            }
        }
    }
}
