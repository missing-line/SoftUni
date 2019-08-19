using System;
using System.Collections.Generic;
using System.Linq;

namespace Command_Interpreter2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split("\t\n\r ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "end")
            {
                if (command[0] == "reverse")
                {
                    int start = int.Parse(command[2]);
                    int end = int.Parse(command[4]);
                    if (start >= 0 &&
                        start < line.Count &&
                        end >= 0 &&
                        start + end <= line.Count
                        )
                    {
                        List<string> curr = line.Skip(start).Take(end).ToList();
                        curr.Reverse();
                        line.RemoveRange(start, end);
                        line.InsertRange(start, curr);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (command[0] == "sort")
                {
                    int start = int.Parse(command[2]);
                    int end = int.Parse(command[4]);
                    if (start >= 0 &&
                        start < line.Count &&
                        end >= 0 &&
                        start + end <= line.Count
                        )
                    {
                        line.Sort(start, end, StringComparer.InvariantCulture);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (command[0] == "rollLeft")
                {
                    int roll = int.Parse(command[1]);
                    if (roll >= 0)
                    {
                        int jump = roll % line.Count;
                        for (int i = 0; i < jump; i++)
                        {
                            string firstElement = line[0];
                            for (int i1 = 0; i1 < line.Count - 1; i1++)
                            {
                                line[i1] = line[i1 + 1];
                            }
                            line[line.Count - 1] = firstElement;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (command[0] == "rollRight")
                {
                    int roll = int.Parse(command[1]);
                    if (roll >= 0)
                    {
                        int jump = roll % line.Count;
                        for (int i = 0; i < jump; i++)
                        {
                            string lastElement = line[line.Count - 1];
                            for (int i1 = line.Count - 1; i1 > 0; i1--)
                            {
                                line[i1] = line[i1 - 1];
                            }
                            line[0] = lastElement;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }

                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine($"[{string.Join(", ", line)}]");
        }
    }
}
