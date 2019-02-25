namespace Bomb_the_Basement
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[size[0], size[1]];

            int[] bomb = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            GetMatrix(matrix, bomb);           
            PrintMatrix(matrix);
        }

        public static void BlastArea(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                
                int count = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] == 1)
                    {
                        count++;                      
                    }                  
                }
                for (int h = 0; h < count; h++)
                {
                    matrix[h,i] = 1;
                }
                for (int k = count; k < matrix.GetLength(0); k++)
                {
                    matrix[k, i] = 0;
                }
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            BlastArea(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void GetMatrix(int[,] matrix, int[] bomb)
        {
            int row = bomb[0];
            int col = bomb[1];
            int radius = bomb[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (Math.Pow((row - i), 2) + Math.Pow((col - j), 2) <= Math.Pow(radius, 2))
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
        }
    }
}
