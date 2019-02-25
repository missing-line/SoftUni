namespace Diagonal_Difference
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            
            int sumLeft = 0;
            int sumRight = 0;

            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] array = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = array[j];
                }

                sumLeft += array[i];
                sumRight += array[array.Length - i - 1];
            }
            Console.WriteLine(Math.Abs(sumLeft - sumRight));
        }
    }
}
