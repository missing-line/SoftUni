namespace Bombs
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] arr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

            int[] bombs = Console.ReadLine()
                    .Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            for (int i = 0; i < bombs.Length - 1; i += 2)
            {
                int row = bombs[i];
                int col = bombs[i + 1];
                if (ValidCoordinates(matrix, row, col) && matrix[row, col] > 0)
                {
                    if (ValidCoordinates(matrix, row - 1, col - 1))
                    {
                        matrix[row - 1, col - 1] -= matrix[row, col];
                    }
                    if (ValidCoordinates(matrix, row - 1, col))
                    {
                        matrix[row - 1, col] -= matrix[row, col];
                    }
                    if (ValidCoordinates(matrix, row - 1, col + 1))
                    {
                        matrix[row - 1, col + 1] -= matrix[row, col];
                    }
                    if (ValidCoordinates(matrix, row, col - 1))
                    {
                        matrix[row, col - 1] -= matrix[row, col];
                    }
                    if (ValidCoordinates(matrix, row, col + 1))
                    {
                        matrix[row, col + 1] -= matrix[row, col];
                    }
                    if (ValidCoordinates(matrix, row + 1, col - 1))
                    {
                        matrix[row + 1, col - 1] -= matrix[row, col];
                    }
                    if (ValidCoordinates(matrix, row + 1, col))
                    {
                        matrix[row + 1, col] -= matrix[row, col];
                    }
                    if (ValidCoordinates(matrix, row + 1, col + 1))
                    {
                        matrix[row + 1, col + 1] -= matrix[row, col];
                    }
                    matrix[row, col] = 0;
                }
            }
            TakeSumAndLiveCells(matrix);
            PrintMatrix(matrix);
        }

        private static void TakeSumAndLiveCells(int[,] matrix)
        {
            int count = 0;
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
            }
            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j != matrix.GetLength(1) - 1)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(matrix[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        private static bool ValidCoordinates(int[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1) && matrix[row, col] > 0;
        }
    }
}
