namespace Maximal_Sum
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];
            int[,] bestMatrix = new int[3, 3];
            int bestSum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] array = Console.ReadLine()
                    .Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = array[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                int[,] array = new int[3, 3];
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    array[0, 0] = matrix[i, j];
                    array[0, 1] = matrix[i, j + 1];
                    array[0, 2] = matrix[i, j + 2];
                    array[1, 0] = matrix[i + 1, j];
                    array[1, 1] = matrix[i + 1, j + 1];
                    array[1, 2] = matrix[i + 1, j + 2];
                    array[2, 0] = matrix[i + 2, j];
                    array[2, 1] = matrix[i + 2, j + 1];
                    array[2, 2] = matrix[i + 2, j + 2];
                    int currSum = BestSum(array);
                    if (bestSum < currSum)
                    {
                        bestSum = currSum; ;
                        bestMatrix[0, 0] = array[0, 0];
                        bestMatrix[0, 1] = array[0, 1];
                        bestMatrix[0, 2] = array[0, 2];
                        bestMatrix[1, 0] = array[1, 0];
                        bestMatrix[1, 1] = array[1, 1];
                        bestMatrix[1, 2] = array[1, 2];
                        bestMatrix[2, 0] = array[2, 0];
                        bestMatrix[2, 1] = array[2, 1];
                        bestMatrix[2, 2] = array[2, 2];
                    }
                }
            }
            Console.WriteLine($"Sum = {bestSum}");
            for (int i = 0; i < bestMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < bestMatrix.GetLength(1); j++)
                {
                    Console.Write(bestMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int BestSum(int[,] array)
        {
            int sum = 0;
            foreach (var index in array)
            {
                sum += index;
            }
            return sum;
        }
    }
}
