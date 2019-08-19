using System;
using System.Linq;

namespace Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine()
                 .Split()
                 .ToList();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] curr = command
                    .Split()
                    .ToArray();

                if (curr[0] == "Insert")
                {
                    int index = int.Parse(curr[1]);
                    string element = curr[2];
                    if (index + 1 < line.Count && index + 1 >= 0)
                    {
                        line.Insert(index + 1, element);
                    }
                }
                else if (curr[0] == "Hide")
                {
                    string element = curr[1];
                    if (line.Contains(element))
                    {
                        int index = line.IndexOf(element);
                        line.RemoveAt(index);
                    }
                }
                else if (curr[0] == "Change")
                {
                    string element = curr[1];
                    string change = curr[2];
                    if (line.Contains(element))
                    {
                        int index = line.IndexOf(element);
                        line[index] = change;
                    }
                }
                else if (curr[0] == "Switch")
                {
                    string first = curr[1];
                    string second = curr[2];
                    if (line.Contains(first) && line.Contains(second))
                    {
                        int firstIndex = line.IndexOf(first);
                        int secondIndex = line.IndexOf(second);

                        line[firstIndex] = second;
                        line[secondIndex] = first;
                    }
                }
                else if (curr[0] == "Reverse")
                {
                    line.Reverse();
                }
            }

            Console.WriteLine(string.Join(" ",line));
        }
    }
}
