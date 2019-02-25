namespace Miner
{
    using System;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine()
                .Split()
                .ToArray();

            string[,] matrix = new string[n, n];
            int coals = 0;

            int row = 0;
            int col = 0;
           
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] array = Console.ReadLine()
                .Split()
                .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = array[j];
                    if (array[j] == "c")
                    {
                        coals++;
                    }
                    else if (array[j] == "s")
                    {
                        row = i;
                        col = j;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == "up" && ValidateStep(matrix, row - 1, col))
                {
                    if (matrix[row - 1, col] == "e")
                    {                       
                        Console.WriteLine($"Game over! ({row - 1}, {col})");
                        return;
                    }
                    else if (matrix[row - 1, col] == "c")
                    {
                        coals--;
                    }
                    matrix[row - 1, col] = "s";
                    matrix[row, col] = "*";
                    row = row - 1;
                }
                else if (commands[i] == "down" && ValidateStep(matrix, row + 1, col))
                {
                    if (matrix[row + 1, col] == "e")
                    {                       
                        Console.WriteLine($"Game over! ({row + 1}, {col})");
                        return;
                    }
                    else if (matrix[row + 1, col] == "c")
                    {
                        coals--;
                    }
                    matrix[row + 1, col] = "s";
                    matrix[row, col] = "*";
                    row = row + 1;
                }
                else if (commands[i] == "right" && ValidateStep(matrix, row, col + 1))
                {
                    if (matrix[row, col + 1] == "e")
                    {                       
                        Console.WriteLine($"Game over! ({row}, {col + 1})");
                        return;
                    }
                    else if (matrix[row, col + 1] == "c")
                    {
                        coals--;
                    }
                    matrix[row, col + 1] = "s";
                    matrix[row, col] = "*";
                    col = col + 1;
                }
                else if (commands[i] == "left" && ValidateStep(matrix, row, col - 1))
                {

                    if (matrix[row, col - 1] == "e")
                    {
                        Console.WriteLine($"Game over! ({row}, {col - 1})");
                        return;
                    }
                    else if (matrix[row, col - 1] == "c")
                    {
                        coals--;
                    }
                    matrix[row, col - 1] = "s";
                    matrix[row, col] = "*";
                    col = col - 1;
                }
            }
            Console.WriteLine(coals == 0 ? $"You collected all coals! ({row}, {col})" : $"{coals} coals left. ({row}, {col})");
        }

        private static bool ValidateStep(string[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }
}
