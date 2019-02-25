namespace Snake_Moves
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
            string input = Console.ReadLine();

            int row = 0;
            int col = 0;
            int count = 0;

            string[,] matrix = new string[size[0], size[1]];

            while (count != size[0] * size[1])
            {
                string line = input;
                while (line != string.Empty && count != size[0] * size[1])
                {
                    matrix[row, col] = line[0].ToString();
                    line = line.Remove(0, 1);
                    count++;
                    if (col < matrix.GetLength(1) - 1)
                    {
                        col++;
                    }
                    else if (row + 1 < matrix.GetLength(0))
                    {
                        row++;
                        col = 0;
                    }
                }
            }
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
