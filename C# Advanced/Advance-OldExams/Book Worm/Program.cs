namespace Book_Worm
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string initial = Console.ReadLine();

            int size = int.Parse(Console.ReadLine());

            string[][] matrix = new string[size][];

            int[,] positions = new int[1, 2];

            FillMatrix(matrix, size, positions);

            MovingOnTheField(initial, matrix, positions);
        }

        private static void MovingOnTheField(string initial, string[][] matrix, int[,] positions)
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                int row = positions[0, 0];
                int col = positions[0, 1];

                if (command == "down")
                {
                    if (isInMatrix(matrix, row + 1, col))
                    {
                        if (matrix[row + 1][col] != "-")
                        {
                            initial = initial + matrix[row + 1][col];
                        }
                        positions[0, 0] = row + 1;
                        matrix[row + 1][col] = "P";
                        matrix[row][col] = "-";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(initial))
                        {
                            initial = initial.Substring(0, initial.Length - 1);
                        }
                    }
                }
                else if (command == "up")
                {
                    if (isInMatrix(matrix, row - 1, col))
                    {
                        if (matrix[row - 1][col] != "-")
                        {
                            initial = initial + matrix[row - 1][col];
                        }
                        positions[0, 0] = row - 1;
                        matrix[row - 1][col] = "P";
                        matrix[row][col] = "-";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(initial))
                        {
                            initial = initial.Substring(0, initial.Length - 1);
                        }
                    }
                }
                else if (command == "left")
                {
                    if (isInMatrix(matrix, row, col - 1))
                    {
                        if (matrix[row][col - 1] != "-")
                        {
                            initial = initial + matrix[row][col - 1];
                        }
                        positions[0, 1] = col - 1;
                        matrix[row][col - 1] = "P";
                        matrix[row][col] = "-";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(initial))
                        {
                            initial = initial.Substring(0, initial.Length - 1);
                        }
                    }
                }
                else if (command == "right")
                {
                    if (isInMatrix(matrix, row, col + 1))
                    {
                        if (matrix[row][col + 1] != "-")
                        {
                            initial = initial + matrix[row][col + 1];
                        }
                        positions[0, 1] = col + 1;
                        matrix[row][col + 1] = "P";
                        matrix[row][col] = "-";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(initial))
                        {
                            initial = initial.Substring(0, initial.Length - 1);
                        }
                    }
                }
            }

            PrintMaxtrix(matrix, initial);
        }

        private static void PrintMaxtrix(string[][] matrix, string initial)
        {
            Console.WriteLine(initial);
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }

        private static bool isInMatrix(string[][] matrix, int row, int col)
        {
            return
                row >= 0 &&
                row <= matrix.Length - 1 &&
                col >= 0 &&
                col <= matrix[row].Length - 1;
        }

        private static void FillMatrix(string[][] matrix, int size, int[,] positions)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i] = Console.ReadLine()
                    .Select(x => x.ToString())
                    .ToArray();
                if (matrix[i].Contains("P"))
                {
                    int index = Array.IndexOf(matrix[i], "P");
                    positions[0, 0] = i;
                    positions[0, 1] = index;
                }
            }
        }
    }
}
