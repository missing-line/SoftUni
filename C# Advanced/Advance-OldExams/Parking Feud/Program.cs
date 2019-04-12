namespace Parking_Feud
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string[][] matrix = new string[size[0] * 2 - 1][];

            GetMatrix(matrix, size[1]);

            int enterRow = int.Parse(Console.ReadLine());

            int samSteps = 0;
            string samSpot = "";

            while (true)
            {
                List<string> input = Console.ReadLine()
                    .Split()
                    .ToList();
                input.Insert(0, "0");

                string sam = input[enterRow];

                input[enterRow] = "0";
                int samCurrSteps = Moving(matrix, enterRow, sam);

                if (input.All(x => x != sam))
                {
                    samSteps += samCurrSteps;
                    samSpot = sam;
                    break;
                }
                else
                {
                    int indexAnotherCar = input.IndexOf(sam);
                    string sportEnd = input[indexAnotherCar];

                    int anotherCar = Moving(matrix, indexAnotherCar, sportEnd);
                    if (anotherCar > samCurrSteps)
                    {
                        samSteps += samCurrSteps;
                        samSpot = sam;
                        break;
                    }
                    else
                    {
                        samSteps += samCurrSteps * 2;
                    }
                }
            }
            Console.WriteLine($"Parked successfully at {samSpot}.");
            Console.WriteLine($"Total Distance Passed: {samSteps}");
        }

        private static int Moving(string[][] matrix, int enterRow, string spot)
        {
            int steps = 0;

            int enter = enterRow * 2;
            enter--;

            int spotIndex = GetEndSpot(matrix, spot);

            if (enter < spotIndex)
            {
                int distance = (spotIndex - 1) - enter;

                for (int i = 0; i < distance / 2; i++)
                {
                    steps += matrix[0].Length - 1;
                    steps += 2;
                }

                if ((distance / 2) % 2 == 0)
                {
                    for (int i = 1; i < matrix[spotIndex - 1].Length - 1; i++)
                    {
                        steps++;
                        if (matrix[spotIndex][i] == spot)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = matrix[spotIndex - 1].Length - 2; i >= 1; i--)
                    {
                        steps++;
                        if (matrix[spotIndex][i] == spot)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                int distance = enter - (spotIndex + 1);
                for (int i = 0; i < distance / 2; i++)
                {
                    steps += matrix[0].Length - 1;
                    steps += 2;
                }

                if ((distance / 2) % 2 == 0)
                {
                    for (int i = 1; i < matrix[spotIndex + 1].Length - 1; i++)
                    {
                        steps++;
                        if (matrix[spotIndex][i] == spot)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = matrix[spotIndex + 1].Length - 2; i >= 1; i--)
                    {
                        steps++;
                        if (matrix[spotIndex][i] == spot)
                        {
                            break;
                        }
                    }
                }
            }
            return steps;
        }

        private static int GetEndSpot(string[][] matrix, string sam)
        {
            int end = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == sam)
                    {
                        end = i;
                        break;
                    }
                }
            }
            return end;
        }

        private static void GetMatrix(string[][] matrix, int size)
        {
            int count = 0;
            for (int i = 1; i < matrix.Length; i++)
            {
                matrix[i - 1] = new string[size + 2];

                if (i % 2 != 0)
                {
                    count++;
                    int letter = 65;
                    for (int j = 1; j < matrix[i - 1].Length - 1; j++)
                    {
                        string spot = $"{(char)letter}{count}";
                        letter++;
                        matrix[i - 1][j] = spot;
                    }
                }
            }
            matrix[matrix.Length - 1] = new string[size + 2];
            int ch = 65;
            count++;
            for (int j = 1; j < matrix[matrix.Length - 1].Length - 1; j++)
            {
                string spot = $"{(char)ch}{count}";
                ch++;
                matrix[matrix.Length - 1][j] = spot;
            }
        }
    }
}
