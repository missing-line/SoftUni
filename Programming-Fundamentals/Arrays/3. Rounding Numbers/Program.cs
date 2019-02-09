namespace Rounding_Numbers_Away_from_Zero
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Program
    {
        public static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " => ");
                Console.WriteLine(Math.Round(nums[i], MidpointRounding.AwayFromZero));
            }
        }
    }
}

