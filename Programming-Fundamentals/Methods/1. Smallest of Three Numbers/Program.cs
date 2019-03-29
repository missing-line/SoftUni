using System;
using System.Linq;

namespace _1._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] threeNums = new int[3];
            for (int i = 0; i < 3; i++)
            {
                int num = int.Parse(Console.ReadLine());
                threeNums[i] = num;
            }
            int result = ReturnSmallestNum(threeNums);
            Console.WriteLine(result);
        }
        public static int ReturnSmallestNum(int[] numbers)
        {
            int smallestNum = numbers.Min();
            return smallestNum;           
        }
    }
}
