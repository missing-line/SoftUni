using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Longest_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            int countNew = 0;
            int countOld = 0;
            int currNew = 0;
            int currOld = 0;

            for (int i = 1; i < nums.Count; i++)
            {
                currNew = nums[i];
                countNew = 0;
                for (int i1 = i - 1; i1 < nums.Count; i1++)
                {
                    if (nums[i] == nums[i1] )
                    {
                        countNew++;
                    }
                }
                if (countNew > countOld)
                {
                    countOld = countNew;
                    currOld = currNew;
                }
            }
            for (int i = 1; i <= countOld; i++)
            {
                Console.Write(currOld + " ");
            }
            Console.WriteLine();
        }
    }
}
