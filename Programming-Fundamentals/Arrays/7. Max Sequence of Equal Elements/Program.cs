namespace __Max_Sequence_of_Equal_ElementsArrays
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int maxCount = 0;
            int num = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int count = 0;
                for (int i1 = i; i1 < nums.Length; i1++)
                {
                    if (nums[i] == nums[i1])
                    {
                        count++;
                    }
                    else                           
                    {
                        break;
                    }
                    if (count > maxCount)
                    {
                        maxCount = count;
                        num = nums[i];
                    }
                }
            }

            for (int i = 1; i <= maxCount; i++)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
