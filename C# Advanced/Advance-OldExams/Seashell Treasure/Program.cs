using System;
using System.Collections.Generic;
using System.Linq;

namespace Seashell_Treasure
{
    class Program
    {
        private static string[][] matrix;
        private static List<string> collected = new List<string>();
        private static List<string> stollen = new List<string>();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            FillMaxtrix(n);


            string inputCommand;

            while ((inputCommand = Console.ReadLine()) != "Sunset")
            {
                var tokens = inputCommand
                    .Split(' ')
                    .ToArray();

                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                switch (command)
                {
                    case "Collect":
                        Collect(row, col);
                        break;
                    case "Steal":
                        Steal(row, col, tokens[3]);
                        break;
                    default:
                        break;
                }
            }

            Print();
        }

        private static void Print()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
            if (collected.Count > 0)
            {
                Console.WriteLine($"Collected seashells: {collected.Count} -> {string.Join(", ", collected)}");

            }
            else
            {
                Console.WriteLine($"Collected seashells: 0");
            }
            
            Console.WriteLine($"Stolen seashells: {stollen.Count}");
        }

        private static void Steal(int row, int col, string position)
        {
            if (IsValid(row, col))
            {
                GetTrasure(row, col);

                if (position == "up")
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        if (IsValid(row - i, col))
                        {
                            GetTrasure(row - i, col);
                        }                       
                    }
                }
                else if (position == "down")
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        if (IsValid(row + i, col))
                        {
                            GetTrasure(row + i, col);
                        }
                    }
                }
                else if (position == "right")
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        if (IsValid(row, col + i))
                        {
                            GetTrasure(row, col + i);
                        }
                    }
                }
                else if (position == "left")
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        if (IsValid(row, col - i))
                        {
                            GetTrasure(row, col - i);
                        }
                    }
                }
            }
        }

        private static void GetTrasure(int row, int col)
        {
            if (matrix[row][col] != "-")
            {
                stollen.Add(matrix[row][col]);
                matrix[row][col] = "-";
            }
        }

        private static void Collect(int row, int col)
        {
            if (IsValid(row, col))
            {
                if (matrix[row][col] != "-")
                {
                    collected.Add(matrix[row][col]);
                    matrix[row][col] = "-";
                }
            }
        }

        private static void FillMaxtrix(int n)
        {
            matrix = new string[n][];

            for (int i = 0; i < matrix.Length; i++)
            {

                matrix[i] = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
            }
        }

        private static bool IsValid(int row, int col)
        {
            return
                row >= 0 &&
                row < matrix.Length &&
                col >= 0 &&
                col < matrix[row].Length;
        }
    }
}
