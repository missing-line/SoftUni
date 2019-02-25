namespace Radioactive_Mutant_Vampire_Bunnies
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

            char[][] matrix = new char[size[0]][];
            int[] position = new int[2];

            GetMatrix(matrix, position, size);

            int row = position[0];
            int col = position[1];
            int bunny = (int)'B' - 1;
            bool isDead = false;
            string commands = Console.ReadLine();

            for (int i = 0; i < commands.Length; i++)
            {
                bunny++;
                if (commands[i] == 'U')
                {
                    if (row - 1 >= 0)
                    {
                        row--;
                        matrix[row + 1][col] = '.';
                        if (matrix[row][col] == '.')
                        {
                            matrix[row][col] = 'P';

                            Command(matrix, row, col, isDead, bunny);

                            if (isDead)
                            {
                                PrinMatrix(matrix);
                                Console.WriteLine($"dead: {row} {col}");
                                return;
                            }
                        }
                        else if (matrix[row][col] == (char)bunny)
                        {
                            Command(matrix, row, col, isDead, bunny);
                            PrinMatrix(matrix);
                            Console.WriteLine($"dead: {row} {col}");
                            return;
                        }
                    }
                    else
                    {
                        matrix[row][col] = '.';
                        Command(matrix, row, col, isDead, bunny);
                        PrinMatrix(matrix);
                        Console.WriteLine($"won: {row} {col}");
                        return;
                    }
                }
                else if (commands[i] == 'R')
                {
                    if (col + 1 < matrix[row].Length)
                    {
                        col++;
                        matrix[row][col - 1] = '.';
                        if (matrix[row][col] == '.')
                        {
                            matrix[row][col] = 'P';

                            Command(matrix, row, col, isDead, bunny);
                            if (isDead)
                            {
                                PrinMatrix(matrix);
                                Console.WriteLine($"dead: {row} {col}");
                                return;
                            }
                        }
                        else if (matrix[row][col] == (char)bunny)
                        {
                            Command(matrix, row, col, isDead, bunny);
                            PrinMatrix(matrix);
                            Console.WriteLine($"dead: {row} {col}");
                            return;
                        }
                    }
                    else
                    {
                        matrix[row][col] = '.';
                        Command(matrix, row, col, isDead, bunny);
                        PrinMatrix(matrix);
                        Console.WriteLine($"won: {row} {col}");
                        return;
                    }
                }
                else if (commands[i] == 'D')
                {
                    if (row + 1 < matrix.Length)
                    {
                        row++;
                        matrix[row - 1][col] = '.';
                        if (matrix[row][col] == '.')
                        {
                            matrix[row][col] = 'P';

                            Command(matrix, row, col, isDead, bunny);
                            if (isDead)
                            {
                                PrinMatrix(matrix);
                                Console.WriteLine($"dead: {row} {col}");
                                return;
                            }
                        }
                        else if (matrix[row][col] == (char)bunny)
                        {
                            Command(matrix, row, col, isDead, bunny);
                            PrinMatrix(matrix);
                            Console.WriteLine($"dead: {row} {col}");
                            return;
                        }
                    }
                    else
                    {
                        matrix[row][col] = '.';
                        Command(matrix, row, col, isDead, bunny);
                        PrinMatrix(matrix);
                        Console.WriteLine($"won: {row} {col}");
                        return;
                    }
                }
                else if (commands[i] == 'L')
                {
                    if (col - 1 >= 0)
                    {
                        col--;
                        matrix[row][col + 1] = '.';
                        if (matrix[row][col] == '.')
                        {
                            matrix[row][col] = 'P';

                            Command(matrix, row, col, isDead, bunny);
                            if (isDead)
                            {
                                PrinMatrix(matrix);
                                Console.WriteLine($"dead: {row} {col}");
                                return;
                            }
                        }
                        else if (matrix[row][col] == (char)bunny)
                        {
                            Command(matrix, row, col, isDead, bunny);
                            PrinMatrix(matrix);
                            Console.WriteLine($"dead: {row} {col}");
                            return;
                        }
                    }
                    else
                    {
                        matrix[row][col] = '.';
                        Command(matrix, row, col, isDead, bunny);
                        PrinMatrix(matrix);
                        Console.WriteLine($"won: {row} {col}");
                        return;
                    }
                }
            }
        }

        private static void PrinMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == '.')
                    {
                        Console.Write(matrix[i][j]);
                    }
                    else
                    {
                        Console.Write('B');
                    }
                }
                Console.WriteLine();
            }
        }

        public static void Command(char[][] matrix, int row, int col, bool isDead, int bunny)
        {
            for (int j = 0; j < matrix.Length; j++)
            {
                for (int k = 0; k < matrix[j].Length; k++)
                {
                    if (matrix[j][k] == (char)bunny)
                    {
                        if (k - 1 >= 0)
                        {
                            if (matrix[j][k - 1] == '.')
                            {
                                matrix[j][k - 1] = (char)(bunny + 1);
                            }
                            else if (matrix[j][k - 1] == 'P')
                            {
                                matrix[j][k - 1] = (char)(bunny + 1);                               
                                isDead = true;
                            }
                        }
                        if (k + 1 < matrix[j].Length)
                        {
                            if (matrix[j][k + 1] == '.')
                            {
                                matrix[j][k + 1] = (char)(bunny + 1);
                            }
                            else if (matrix[j][k + 1] == 'P')
                            {
                                matrix[j][k + 1] = (char)(bunny + 1);
                               
                                isDead = true;
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            if (matrix[j - 1][k] == '.')
                            {
                                matrix[j - 1][k] = (char)(bunny + 1);
                            }
                            else if (matrix[j - 1][k] == 'P')
                            {
                                matrix[j - 1][k] = (char)(bunny + 1);
                                
                                isDead = true;
                            }
                        }
                        if (j + 1 < matrix.Length)
                        {
                            if (matrix[j + 1][k] == '.')
                            {
                                matrix[j + 1][k] = (char)(bunny + 1);
                            }
                            else if (matrix[j + 1][k] == 'P')
                            {
                                matrix[j + 1][k] = (char)(bunny + 1);
                                
                                isDead = true;
                            }
                        }
                    }
                }
            }
        }

        public static void GetMatrix(char[][] matrix, int[] position, int[] size)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new char[size[1]];
                string col = Console.ReadLine();
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = col[j];
                    if (col[j] == 'P')
                    {
                        position[0] = i;
                        position[1] = j;
                    }
                }
            }
        }
    }
}
