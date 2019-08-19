using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split(",".ToCharArray())
                .ToList();
            List<string> command = Console.ReadLine()
                .Split(":".ToCharArray())
                .ToList();
            while (command[0] != "course start")
            {
                if (command[0] == "Add")
                {
                    if (!line.Contains(command[1]))
                    {
                        line.Add(command[1]);
                    }
                }
                else if (command[0] == "Insert")
                {
                    int insert = int.Parse(command[2]);
                    if (insert <= line.Count && !line.Contains(command[1]))
                    {
                        line.Insert(insert, command[1]);
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (line.Contains(command[1]) == true)
                    {                       
                        line.Remove(command[1]);
                    }
                }
                else if (command[0] == "Swap")
                {
                    if (line.Contains(command[1]) && line.Contains(command[2]))
                    {
                        line = Swap(line, command[1], command[2]);
                    }
                }

                command = Console.ReadLine()
             .Split(":".ToCharArray())
             .ToList();
            }
            Console.WriteLine(string.Join(" ", line));
        }
        static List<string> Swap(List<string> line, string command1, string command2)
        {
            int fist = 0;
            int second = 0;
            for (int i = 0; i < line.Count; i++)
            {
                if (line[i] == command1)
                {
                    fist = i;
                }
                if (line[i] == command2)
                {
                    second = i;
                }
            }
            line.Remove(command1);
            line.Remove(command2);
            line.Insert(fist, command2);
            line.Insert(second, command1);
            return line;
        }

    }
}
