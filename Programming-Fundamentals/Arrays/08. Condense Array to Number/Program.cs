namespace _08._Condense_Array_to_Number
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] numbers = new int[nums.Length - 1];

            int sum = 0;

            if (nums.Length == 1)
            {
                Console.WriteLine(nums[0]);
                return;
            }
            for (int i = 0; i <= nums.Length - 1; i++)
            {
                i = 0;
                for (int i1 = i + 1; i1 <= nums.Length - 1; i1++)
                {
                    int curr = nums[i] + nums[i1];
                    sum += curr;
                    numbers[i] = curr;
                    i++;
                }
                nums = numbers;
                numbers = new int[nums.Length - 1];
            }
            Console.WriteLine(sum);
        }
    }
}
