namespace JediGalaxy
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

            int row = size[0];
            int col = size[1];

            int[,] matrix = new int[row, col];

            GetMatrix(matrix);

            long ivoPoints = 0;

            string input;

            while ((input = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoSize = input
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                input = Console.ReadLine();

                int[] evilSize = input
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int rowIvo = ivoSize[0];
                int colIvo = ivoSize[1];

                int rowEvil = evilSize[0];
                int colEvil = evilSize[1];

                BreakignCellsByEvel(matrix, rowEvil, colEvil);
               ivoPoints =  IvoCollectingCells(matrix, rowIvo, colIvo, ivoPoints);
            }
            Console.WriteLine(ivoPoints);
        }

        private static long IvoCollectingCells(int[,] matrix, int row, int col, long points)
        {
             if (col < matrix.GetLength(1) && row >= 0)
            {
                while (col < matrix.GetLength(1) && row >= 0)
                {
                    if (isValid(matrix, row, col))
                    {
                        points += matrix[row, col];
                    }
                    row--;
                    col++;
                }
            }
            return points;
        }

        private static void BreakignCellsByEvel(int[,] matrix, int row, int col)
        {
            if (row >= 0 && col >= 0 )
            {
                while (row >= 0 && col >= 0)
                {
                    if (isValid(matrix, row, col))
                    {
                        matrix[row, col] = -1;
                    }
                    row--;
                    col--;
                }
            }
        }

        private static bool isValid(int[,] matrix, int row, int col)
        {
            return row >= 0 
                && row < matrix.GetLength(0) 
                && col >= 0 && col < matrix.GetLength(1) 
                && matrix[row,col] != -1;
        }

        private static void GetMatrix(int[,] matrix)
        {
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = count++;
                }
            }
        }
    }
}
