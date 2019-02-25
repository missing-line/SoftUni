namespace _02.ExcelFunctions
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

            for (int i = 0; i < matrix.Length; i++)
            {
                string[] array = Console.ReadLine()
                    .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                matrix[i] = array;
            }


            string[] arrayOfCommand = Console.ReadLine()
                    .Split()
                    .ToArray();

            string secondFilterValue = arrayOfCommand[1];
            List<string> firstRow = matrix[0].ToList();
            int index = firstRow.IndexOf(secondFilterValue);

            if (arrayOfCommand[0] == "sort")
            {
                List<string> sorted = new List<string>();
                if (index != -1)
                {
                    for (int i = 1; i < matrix.Length; i++)
                    {
                        sorted.Add(matrix[i][index]);
                    }
                    sorted.Sort();
                    Console.WriteLine(string.Join(" | ", matrix[0]));
                    for (int i = 0; i < sorted.Count; i++)
                    {
                        foreach (var row in matrix)
                        {
                            if (row[index] == sorted[i])
                            {
                                Console.WriteLine(string.Join(" | ", row));
                                break;
                            }
                        }
                    }
                }
            }
            else if (arrayOfCommand[0] == "hide")
            {
                if (index != -1)
                {
                    for (int i = 0; i < matrix.Length; i++)
                    {
                        List<string> currRow = matrix[i].ToList();
                        currRow.RemoveAt(index);
                        Console.WriteLine(string.Join(" | ", currRow));
                    }
                }
            }
            else if (arrayOfCommand[0] == "filter")
            {
                if (index != -1)
                {
                    string value = arrayOfCommand[2];
                    Console.WriteLine(string.Join(" | ", matrix[0]));
                    for (int i = 1; i < matrix.Length; i++)
                    {
                        var currRow = matrix[i];
                        if (currRow[index] == value)
                        {
                            Console.WriteLine(string.Join(" | ", currRow));
                        }
                    }
                }
            }
        }
    }
}
