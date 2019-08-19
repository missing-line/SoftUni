using System;
using System.Collections.Generic;
using System.Linq;

namespace Command_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            // 85 / 100 
            List<string> line = Console.ReadLine()
                .Split(" \t\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string[] command = Console.ReadLine().Split().ToArray();
            while (command[0] != "end")
            {
                if (command[0] == "reverse")
                {
                    int start = Int32.Parse(command[2]);
                    int end = Int32.Parse(command[4]);
                    if (start >= 0 && 
                        start < line.Count &&
                        start + end <= line.Count &&
                        end >= 0)
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
                else if (command[0] == "sort")// if..!!
                {
                    int sortStartIndex = int.Parse(command[2]);
                    int sortCount = int.Parse(command[4]);

                    if (sortStartIndex >= 0 &&
                        sortStartIndex < line.Count &&
                        sortCount >= 0 &&
                        sortStartIndex + sortCount <= line.Count)
                    {
                        line.Sort(sortStartIndex, sortCount, StringComparer.InvariantCulture);// sort in direct..!!
                        line.Sort(sortCount, sortCount, StringComparer.InvariantCulture);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input parameters.");
                    }
                }
                else if (command[0] == "rollLeft")
                {
                    if (int.Parse(command[1]) >= 0 )
                    {
                        line = Left(line, int.Parse(command[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (command[0] == "rollRight")
                {
                    if (int.Parse(command[1]) >= 0 )
                    {
                        line = Right(line, int.Parse(command[1]));
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
        static List<string> Left(List<string> myList, int rollLeftCount)
        {
            int jumps = rollLeftCount % myList.Count;
            for (int j = 0; j < jumps; j++)
            {
                string firstElement = myList[0];
                for (int i = 0; i < myList.Count - 1; i++)
                {
                    myList[i] = myList[i + 1];
                }
                myList[myList.Count - 1] = firstElement;
            }
            return myList;
        }
        static List<string> Right(List<string> myList, int rollRightCount)
        {
            int jumps = rollRightCount % myList.Count;
            for (int j = 0; j < jumps; j++)
            {
                string lastElement = myList[myList.Count - 1];
                for (int i = myList.Count - 1; i > 0; i--)
                {
                    myList[i] = myList[i - 1];
                }
                myList[0] = lastElement;
            }
            return myList;
        }
    }
}
