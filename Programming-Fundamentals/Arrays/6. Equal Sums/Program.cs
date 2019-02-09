namespace _6._Equal_Sums
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int index = -1;
            if (line.Length == 1)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < line.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                for (int i1 = 0; i1 < i; i1++)
                {
                    leftSum += line[i1];
                }

                for (int i2 = i + 1; i2 < line.Length; i2++)
                {
                    rightSum += line[i2];
                }
                if (leftSum == rightSum)
                {
                    index = i;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("no");
            }
            else
            {
                Console.WriteLine(index);
            }
        }
    }
}
