namespace Bunker_Buster
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

            int allCellsCount = size[0] * size[1];

            int[,] matrix = new int[size[0], size[1]];

            GetMatrix(matrix);

            string input;

            while ((input = Console.ReadLine()) != "cease fire!")
            {

                int row = int.Parse(input[0].ToString());
                int col = int.Parse(input[2].ToString());
                double power = (int)input[4];
                double bomb = Math.Ceiling(power / 2);

                if (!ValidatingCell(matrix, row, col))
                {
                    continue;
                }
                matrix[row, col] -= (int)power;
                Bombing(matrix, row, col, bomb);
            }

            int cellsNegative = GetDeadCells(matrix);

            decimal dmg = (decimal)cellsNegative / (decimal)(allCellsCount);

            Console.WriteLine($"Destroyed bunkers: {cellsNegative}");
            Console.WriteLine($"Damage done: {(dmg * 100):f1} %");
        }

        private static int GetDeadCells(int[,] matrix)
        {
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i, k] <= 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private static void Bombing(int[,] matrix, int row, int col, double bomb)
        {
            if (ValidatingCell(matrix, row, col - 1))
            {
                matrix[row, col - 1] -= (int)bomb;
            }
            if (ValidatingCell(matrix, row, col + 1))
            {
                matrix[row, col + 1] -= (int)bomb;
            }
            if (ValidatingCell(matrix, row - 1, col - 1))
            {
                matrix[row - 1, col - 1] -= (int)bomb;
            }
            if (ValidatingCell(matrix, row - 1, col))
            {
                matrix[row - 1, col] -= (int)bomb;
            }
            if (ValidatingCell(matrix, row - 1, col + 1))
            {
                matrix[row - 1, col + 1] -= (int)bomb;
            }
            if (ValidatingCell(matrix, row + 1, col - 1))
            {
                matrix[row + 1, col - 1] -= (int)bomb;
            }
            if (ValidatingCell(matrix, row + 1, col))
            {
                matrix[row + 1, col] -= (int)bomb;
            }
            if (ValidatingCell(matrix, row + 1, col + 1))
            {
                matrix[row + 1, col + 1] -= (int)bomb;
            }
        }

        private static bool ValidatingCell(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void GetMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] cells = Console.ReadLine()
                .Split()
                .ToArray();
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i, k] = int.Parse(cells[k]);
                }
            }
        }
    }
}
