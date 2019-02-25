namespace Tron_Racers
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];

            string firstPlayer = "f";
            string secondPlayer = "s";

            int[] positionFirst = new int[2];
            int[] positionSecond = new int[2];


            GetMatrix(matrix, positionFirst, positionSecond);

            while (true)
            {
                string[] commands = Console.ReadLine().Split().ToArray();

                string first = commands[0];

                if (Moving(matrix, first, positionFirst, firstPlayer, secondPlayer))
                {
                    Print(matrix);
                    break;
                }

                string second = commands[1];

                if (Moving(matrix,second, positionSecond, secondPlayer, firstPlayer))
                {
                    Print(matrix);
                    break;
                }
            }      
        }

        private static void Print(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]}");
                }
                Console.WriteLine();
            }
        }

        private static bool Moving(string[,] matrix, string first, int[] positions, string player, string secondPlayer)
        {
            int row = positions[0];
            int col = positions[1];
            bool winner = false;
            if (first == "down")
            {
                if (row + 1 < matrix.GetLength(0))
                {
                    if (matrix[row + 1, col] == "*")
                    {
                        matrix[row + 1, col] = player;
                        positions[0] = row + 1;
                    }
                    else if (matrix[row + 1, col] == secondPlayer)
                    {
                        matrix[row + 1, col] = "x";
                        winner = true;
                    }
                }
                else
                {
                    if (matrix[0, col] == "*")
                    {
                        matrix[0, col] = player;
                        positions[0] = 0;
                    }
                    else if (matrix[0, col] == secondPlayer)
                    {
                        winner = true;
                        matrix[0, col] = "x";
                    }
                }
            }
            else if (first == "left")
            {
                if (col - 1 >= 0)
                {
                    if (matrix[row, col - 1] == "*")
                    {
                        matrix[row, col - 1] = player;
                        positions[1] = col - 1;
                    }
                    else if (matrix[row, col - 1] == secondPlayer)
                    {
                        matrix[row, col - 1] = "x";
                        winner = true;
                    }
                }
                else
                {
                    if (matrix[row, matrix.GetLength(1) - 1] == "*")
                    {
                        matrix[row, matrix.GetLength(1) - 1] = player;
                        positions[1] = matrix.GetLength(1) - 1;
                    }
                    else if (matrix[row, matrix.GetLength(1) - 1] == secondPlayer)
                    {
                        matrix[row, matrix.GetLength(1) - 1] = "x";
                        winner = true;
                    }
                }
            }
            else if (first == "right")
            {
                if (col + 1 <= matrix.GetLength(1) - 1)
                {
                    if (matrix[row, col + 1] == "*")
                    {
                        matrix[row, col + 1] = player;
                        positions[1] = col + 1;
                    }
                    else if (matrix[row, col + 1] == secondPlayer)
                    {
                        winner = true;
                        matrix[row, col + 1] = "x";
                    }
                }
                else
                {
                    if (matrix[row, 0] == "*")
                    {
                        matrix[row, 0] = player;
                        positions[1] = 0;
                    }
                    else if (matrix[row, 0] == secondPlayer)
                    {
                        winner = true;
                        matrix[row, 0] = "x";
                    }
                }
            }
            else if (first == "up")
            {
                if (row - 1 >= 0)
                {
                    if (matrix[row - 1,col] == "*")
                    {
                        matrix[row - 1, col] = player;
                        positions[0] = row - 1;
                    }
                    else if (matrix[row - 1, col] == secondPlayer)
                    {
                        winner = true;
                        matrix[row - 1, col] = "x";
                    }
                }
                else
                {
                    if (matrix[matrix.GetLength(0) - 1,col] == "*")
                    {
                        matrix[matrix.GetLength(0) - 1, col] = player;
                        positions[0] = matrix.GetLength(0) - 1;
                    }
                    else if (matrix[matrix.GetLength(0) - 1, col] == secondPlayer)
                    {
                        winner = true;
                        matrix[matrix.GetLength(0) - 1, col] = "x";
                    }
                }
            }
            return winner;
        }

        private static void GetMatrix(string[,] matrix, int[] positionFirst, int[] positionSecond)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j].ToString();
                    if (line[j].ToString() == "f")
                    {
                        positionFirst[0] = i;
                        positionFirst[1] = j;
                    }
                    if (line[j].ToString() == "s")
                    {
                        positionSecond[0] = i;
                        positionSecond[1] = j;
                    }
                }
            }
        }
    }
}
