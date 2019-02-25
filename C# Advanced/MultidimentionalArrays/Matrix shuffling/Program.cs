namespace Matrix_shuffling
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string[][] matrix = new string[size[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split().ToArray();
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {

                if (IsValid(input))
                {
                    string[] arr = input
                        .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    int row = int.Parse(arr[1]);
                    int col = int.Parse(arr[2]);
                    int row1 = int.Parse(arr[3]);
                    int col1 = int.Parse(arr[4]);

                    if (row >= 0 && row < matrix.Length &&
                        row1 >= 0 && row1 < matrix.Length &&
                        col >= 0 && col < matrix[row].Length &&
                        col1 >= 0 && col1 < matrix[row1].Length)
                    {
                        string first = matrix[row][col];
                        string second = matrix[row1][col1];
                        matrix[row][col] = second;
                        matrix[row1][col1] = first;
                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static bool IsValid(string input)
        {
            bool isValid = false;

            string pattern = @"^swap \d+ \d+ \d+ \d+$";
            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                isValid = true;
            }
            return isValid;
        }

        public static void PrintMatrix(string[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }
    }
}
