namespace PascalTriangle
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine(1);
                return;
            }

            long[][] matrix = new long[n][];

            matrix[0] = new long[] { 1 };
            matrix[1] = new long[] { 1, 1 };


            for (int i = 2; i < matrix.Length; i++)
            {
                matrix[i] = new long[i + 1];
                matrix[i][0] = 1;
                for (int j = 1; j < matrix[i].Length - 1; j++)
                {
                    matrix[i][j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
                }
                matrix[i][matrix[i].Length - 1] = 1;
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
