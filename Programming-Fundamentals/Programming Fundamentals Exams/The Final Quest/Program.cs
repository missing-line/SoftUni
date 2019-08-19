using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine()
                .Split(' ')
                .ToList();

            string input;

            while ((input = Console.ReadLine()) != "Stop")
            {
                List<string> tokens = input
                    .Split(' ')
                    .ToList();

                string commnad = tokens[0];
                switch (commnad)
                {
                    case "Delete":
                        DeleteCommand(line, int.Parse(tokens[1]));
                        break;
                    case "Swap":
                        SwapCommand(line, tokens[1], tokens[2]);
                        break;
                    case "Put":
                        PutCommand(line, tokens[1], int.Parse(tokens[2]));
                        break;
                    case "Sort":
                        SortCommand(line);
                        break;
                    case "Replace":
                        ReplaceCommand(line, tokens[1], tokens[2]);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", line));
        }

        private static void ReplaceCommand(List<string> line, string first, string second)
        {
            int indexSecond = line.IndexOf(second);
            if (indexSecond != -1)
                line[indexSecond] = first;
        }

        private static void SortCommand(List<string> line)
        {
            line.Sort((a, b) => -1 * a.CompareTo(b));
        }

        private static void PutCommand(List<string> line, string word, int index)
        {
            if (index - 1 >= 0 && index - 1 <= line.Count)
                line.Insert(index - 1, word);
        }

        private static void SwapCommand(List<string> line, string first, string second)
        {
            int indexFirst = line.IndexOf(first);
            int indexSecond = line.IndexOf(second);

            if (indexFirst != -1 && indexSecond != -1)
            {
                line[indexFirst] = second;
                line[indexSecond] = first;
            }
        }

        private static void DeleteCommand(List<string> line, int index)
        {
            if (index + 1 >= 0 && index + 1 < line.Count)
                line.RemoveAt(index + 1);
        }
    }
}
