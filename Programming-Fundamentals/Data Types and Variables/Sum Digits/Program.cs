using System;

namespace Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            string nums = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int curr = int.Parse(nums[i].ToString());
                sum += curr;
            }
            Console.WriteLine(sum);
        }
    }
}
