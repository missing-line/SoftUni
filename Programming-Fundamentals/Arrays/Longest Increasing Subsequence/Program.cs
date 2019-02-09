namespace Longest_Increasing_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> numbers = new List<int>();

            int[] lent = new int[nums.Length];
            int[] prev = new int[nums.Length];
            lent[0] = 1;
            prev[0] = -1;
            for (int i = 1; i <= nums.Length - 1; i++)
            {
                if (nums[i - 1] < nums[i])
                {
                    int[] arr = new int[i];
                    arr = CurrArr(arr, lent);
                    int value = arr.Max();
                    int indexValue = Array.IndexOf(arr, value);
                    while (true)
                    {
                        if (nums[indexValue] < nums[i])
                        {
                            lent[i] = lent[indexValue] + 1;
                            prev[i] = indexValue;
                            break;
                        }
                        else
                        {
                            arr[indexValue] = 0;
                            value = arr.Max();
                            indexValue = Array.IndexOf(arr, value);
                        }
                    }
                }
                else
                {
                    int[] arr = new int[i];
                    arr = CurrArr(arr, lent);
                    int value = arr.Max();
                    int indexValue = Array.IndexOf(arr, value);
                    while (arr.Max() != 0)
                    {
                        if (nums[indexValue] < nums[i])
                        {
                            lent[i] = lent[indexValue] + 1;
                            prev[i] = indexValue;
                            break;
                        }
                        else
                        {
                            arr[indexValue] = 0;
                            value = arr.Max();
                            indexValue = Array.IndexOf(arr, value);
                        }
                    }
                    if (value == 0)
                    {
                        lent[i] = 1;
                        prev[i] = -1;
                    }
                }
            }

            int start = lent.Max();
            int startIndex = Array.IndexOf(lent, start);
            while (startIndex >= 0)
            {
                numbers.Add(nums[startIndex]);
                startIndex = prev[startIndex];
            }
            numbers.Reverse();
            Console.WriteLine(string.Join(" ", numbers));
        }
        static int[] CurrArr(int[] arr, int[] arr2)
        {
            int[] curr = new int[arr.Length];
            for (int i = 0; i < curr.Length; i++)
            {
                curr[i] = arr2[i];
            }
            return curr;
        }
    }
}
