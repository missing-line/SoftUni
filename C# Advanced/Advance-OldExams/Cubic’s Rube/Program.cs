namespace Cubic_s_Rube
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            long sumValues = 0;
            int sumOfNegativeCells = size * size * size;

            string input;

            while ((input = Console.ReadLine()) != "Analyze")
            {
                int[] arr = input.Split().Select(int.Parse).ToArray();

                int x = arr[0];
                int y = arr[1];
                int z = arr[2];
                int value = arr[3];

                if (isValid(x, y, z, value, size))
                {
                    sumValues += value;
                    sumOfNegativeCells--;
                }
            }
            Console.WriteLine(sumValues);
            Console.WriteLine(sumOfNegativeCells);
        }

        private static bool isValid(int x, int y, int z,int value , int size)
        {
            return (x >= 0 &&
                x < size
                &&
                y >= 0
                &&
                y < size
                &&
                z >= 0
                &&
                z < size 
                &&
                value != 0);
        }
    }
}
