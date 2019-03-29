using System;
using System.Linq;

namespace Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            numbers[0] = n1;
            numbers[1] = n2;
            numbers[2] = n3;
            ResultOfMultipy(numbers);
        }
        public static void ResultOfMultipy(int[] nums)
        {
            int[] negative = nums.Where(y => y < 0).ToArray();
            if (nums.Contains(0))
            {
                Console.WriteLine("zero");
            }          
            else if (negative.Length % 2 != 0)
            {
                Console.WriteLine("negative");
            }
            else
            {
                Console.WriteLine("positive");
            }
        }
    }
}
