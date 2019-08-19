using System;
using System.Collections.Generic;
using System.Linq;

namespace Easter_Gifts
{
    class Program
    {
        private static List<string> line;
        static void Main(string[] args)
        {
            line = Console.ReadLine()
                 .Split(' ')
                 .ToList();

            //OutOfStock Required  JustInCase  

            string input = Console.ReadLine();

            while (input != "No Money")
            {
                var tokens = input
                    .Split(' ')
                    .ToList();

                string command = tokens[0];

                switch (command)
                {
                    case "OutOfStock":
                        OutOfStock(tokens[1]);
                        break;
                    case "Required":
                        Required(tokens[1], int.Parse(tokens[2]));
                        break;
                    case "JustInCase":
                        JustInCase(tokens[1]);
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }

            Print();
        }

        private static void Print()
        {
            var separated = line
                .Where(x => x != "None")
                .ToList();
            Console.WriteLine(string.Join(" ", separated));
        }

        private static void JustInCase(string gift)
        {
            line[line.Count - 1] = gift;
        }

        private static void Required(string gift, int index)
        {
            if (index >= 0 && index < line.Count)
            {
                line[index] = gift;
            }
        }

        private static void OutOfStock(string gift)
        {
            if (line.Contains(gift))
            {
                string currLine = string.Join(' ', line);

                currLine = currLine.Replace(gift, "None");

                line = currLine
                    .Split(' ')
                    .ToList();
            }
        }
    }
}
