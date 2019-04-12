namespace Sneaking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[][] matrix = new string[n][];

            int[] positions = new int[2];

            GetMatrixFindPositions(matrix, positions);


            string direction = Console.ReadLine();
            for (int i = 0; i < direction.Length; i++)
            {
                EnemiesMoving(matrix);
                if (!ChekingIsSamDie(matrix, positions))
                {
                    Console.WriteLine($"Sam died at {positions[0]}, {positions[1]}");
                    matrix[positions[0]][positions[1]] = "X";
                    break;
                }
                if (direction[i] == 'U')
                {
                    positions[0]--;
                    matrix[positions[0]][positions[1]] = "S";
                    matrix[positions[0] + 1][positions[1]] = ".";

                    int index = ChekcingWhereIsNikoladze(matrix, positions);
                    if (index > -1)
                    {
                        Console.WriteLine("Nikoladze killed!");
                        break;
                    }
                }
                else if (direction[i] == 'D')
                {
                    positions[0]++;
                    matrix[positions[0]][positions[1]] = "S";
                    matrix[positions[0] - 1][positions[1]] = ".";

                    int index = ChekcingWhereIsNikoladze(matrix, positions);
                    if (index > -1)
                    {
                        Console.WriteLine("Nikoladze killed!");
                        break;
                    }

                }
                else if (direction[i] == 'L')
                {
                    positions[1]--;
                    matrix[positions[0]][positions[1]] = "S";
                    matrix[positions[0]][positions[1] + 1] = ".";

                }
                else if (direction[i] == 'R')
                {
                    positions[1]++;
                    matrix[positions[0]][positions[1]] = "S";
                    matrix[positions[0]][positions[1] - 1] = ".";

                }
            }
            PrinMatrix(matrix);
        }

        private static void PrinMatrix(string[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }

        private static int ChekcingWhereIsNikoladze(string[][] matrix, int[] positions)
        {
            int index = -1;
            List<string> line = matrix[positions[0]].ToList();
            if (line.Contains("N"))
            {
                index = line.IndexOf("N");
                matrix[positions[0]][index] = "X";
            }
            return index;
        }

        public static bool ChekingIsSamDie(string[][] matrix, int[] positions)
        {
            bool isSamStillLife = true;
            List<string> line = matrix[positions[0]].ToList();
            int indexB = line.IndexOf("b");
            int indexD = line.IndexOf("d");
            if (indexB != -1)
            {
                if (positions[1] > indexB)
                {
                    isSamStillLife = false;
                }
            }
            if (indexD != -1)
            {
                if (positions[1] < indexD)
                {
                    isSamStillLife = false;
                }
            }
            return isSamStillLife;
        }

        public static void EnemiesMoving(string[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                List<string> row = matrix[i].ToList();
                int indexB = row.IndexOf("b");
                int indexD = row.IndexOf("d");
                if (indexB != -1)
                {
                    if (indexB == matrix[i].Length - 1)
                    {
                        matrix[i][indexB] = "d";
                    }
                    else
                    {
                        matrix[i][indexB] = ".";
                        matrix[i][++indexB] = "b";
                    }
                }
                if (indexD != -1)
                {
                    if (indexD == 0)
                    {
                        matrix[i][indexD] = "b";
                    }
                    else
                    {
                        matrix[i][indexD] = ".";
                        matrix[i][--indexD] = "d";
                    }

                }
            }
        }

        public static void GetMatrixFindPositions(string[][] matrix, int[] positions)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                string input = Console.ReadLine();
                matrix[i] = new string[input.Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = input[j].ToString();
                    if (matrix[i][j] == "S")
                    {
                        positions[0] = i;
                        positions[1] = j;
                    }
                }
            }
        }
    }
}

