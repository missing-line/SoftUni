namespace Dangerous_Floor
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] matrix = new string[8, 8];

            FillMatrix(matrix);

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] arr = input.Split('-').ToArray();

                string positons = arr[0];
                string moving = arr[1];

                string figure = positons[0].ToString();
                int row = int.Parse(positons[1].ToString());
                int col = int.Parse(positons[2].ToString());

                int rowMove = int.Parse(moving[0].ToString());
                int colMove = int.Parse(moving[1].ToString());

                if (!ChekingFigurePositons(matrix, figure, row, col))
                {
                    Console.WriteLine("There is no such a piece!");
                }
                else
                {
                    ChekingMovingPosition(matrix, figure, row, col, rowMove, colMove);
                }
            }
        }

        private static void ChekingMovingPosition(string[,] matrix, string figure, int row, int col, int rowMove, int colMove)
        {
            if (figure == "K")
            {
                if (!(Math.Max(Math.Abs(row - rowMove), Math.Abs(col - colMove)) == 1))
                {
                    Console.WriteLine("Invalid move!");
                }
                else
                {
                    if (rowMove >= 0 && rowMove < matrix.GetLength(0) && colMove >= 0 && colMove < matrix.GetLength(1))
                    {
                        matrix[row, col] = "x";
                        matrix[rowMove, colMove] = "K";
                    }
                    else
                    {
                        Console.WriteLine("Move go out of board!");
                    }
                }
            }
            else if (figure == "Q")
            {
                if ((row != rowMove && col != colMove) && Math.Abs(row - rowMove) != Math.Abs(col - colMove))
                {
                    Console.WriteLine("Invalid move!");
                }
                else
                {
                    if (rowMove >= 0 && rowMove < matrix.GetLength(0) && colMove >= 0 && colMove < matrix.GetLength(1))
                    {
                        matrix[row, col] = "x";
                        matrix[rowMove, colMove] = figure;
                    }
                    else
                    {
                        Console.WriteLine("Move go out of board!");
                    }
                }
            }
            else if (figure == "R")
            {
                if (row != rowMove && col != colMove)
                {
                    Console.WriteLine("Invalid move!");
                }
                else
                {
                    if (rowMove >= 0 && rowMove < matrix.GetLength(0) && colMove >= 0 && colMove < matrix.GetLength(1))
                    {
                        matrix[row, col] = "x";
                        matrix[rowMove, colMove] = figure;
                    }
                    else
                    {
                        Console.WriteLine("Move go out of board!");
                    }
                }
            }
            else if (figure == "B")
            {
                if (Math.Abs(row - rowMove) != Math.Abs(col - colMove))
                {
                    Console.WriteLine("Invalid move!");
                }
                else
                {
                    if (rowMove >= 0 && rowMove < matrix.GetLength(0) && colMove >= 0 && colMove < matrix.GetLength(1))
                    {
                        matrix[row, col] = "x";
                        matrix[rowMove, colMove] = figure;
                    }
                    else
                    {
                        Console.WriteLine("Move go out of board!");
                    }
                }
            }
            else if (figure == "P")
            {
                if (col != colMove || row - 1 != rowMove)
                {
                    Console.WriteLine("Invalid move!");
                }
                else
                {
                    if (rowMove >= 0 && rowMove < matrix.GetLength(0) && colMove >= 0 && colMove < matrix.GetLength(1))
                    {
                        matrix[row, col] = "x";
                        matrix[rowMove, colMove] = figure;
                    }
                    else
                    {
                        Console.WriteLine("Move go out of board!");
                    }
                }
            }
        }

        private static bool ChekingFigurePositons(string[,] matrix, string figure, int row, int col)
        {
            return matrix[row, col] == figure && row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void FillMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] arr = Console.ReadLine()
                    .Split(',')
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = arr[j];
                }
            }
        }
    }
}
