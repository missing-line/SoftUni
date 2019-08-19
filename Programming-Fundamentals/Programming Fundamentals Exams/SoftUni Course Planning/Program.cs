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
            List<string> clean = new List<string>();
            for (int i = 0; i < line.Count; i++)
            {
                clean.Add(line[i].Trim());
            }
            while (command[0] != "course start")
            {
                if (command[0] == "Add")
                {
                    if (!clean.Contains(command[1]))
                    {
                        clean.Add(command[1]);
                    }
                }
                else if (command[0] == "Insert")
                {
                    int insert = int.Parse(command[2]);
                    if (insert <= clean.Count && !clean.Contains(command[1]))
                    {
                        clean.Insert(insert, command[1]);
                    }
                }
                else if (command[0] == "Remove")
                {
                    
                    if (clean.Contains(command[1]) == true)
                    {
                        clean.Remove(command[1]);
                        if (clean.Contains(command[1] + "-" + "Exercise"))
                        {
                            clean.Remove(command[1] + "-" + "Exercise");
                        }
                    }
                }
                else if (command[0] == "Swap")
                {
                    
                    if (clean.Contains(command[1]) && clean.Contains(command[2]))
                    {

                        clean = Swap(clean, command[1], command[2]);
                        if (clean.Contains(command[1] + "-" + "Exercise") ||
                            clean.Contains(command[2] + "-" + "Exercise"))
                        {
                            string curr = "";
                            string com = "";
                            if (clean.Contains(command[1] + "-" + "Exercise"))
                            {
                                curr = command[1] + "-" + "Exercise";
                                com = command[1];
                            }
                            if (clean.Contains(command[2] + "-" + "Exercise"))
                            {
                                curr = command[2] + "-" + "Exercise";
                                com = command[2];
                            }
                            clean = SwapEx(clean,curr,com);
                        }
                    }
                }
                else if (command[0] == "Exercise")
                {
                    if (!clean.Contains(command[1]))
                    {
                        clean.Add(command[1]);
                        clean.Add(command[1] + "-" + command[0]);
                    }
                    else if (clean.Contains(command[1]))
                    {
                        string curr = "";
                        curr = command[1] + "-" + command[0];
                        clean = AddEx(clean,curr,command[1]);
                    }
                }
                command = Console.ReadLine()
             .Split(":".ToCharArray())
             .ToList();
            }
            for (int i = 0; i < clean.Count; i++)
            {
                
                Console.WriteLine($"{i + 1}.{clean[i]}");
            }
        }
        static List<string> AddEx(List<string> clean,string curr, string com)
        {
            for (int i = 0; i < clean.Count; i++)
            {
                if (clean[i] == com)
                {
                    clean.Remove(curr);
                    clean.Insert(i+1,curr);
                    break;
                }
            }
            return clean;
        }
        static List<string> SwapEx(List<string> clean, string swap, string commmand)
        {           
            for (int i = 0; i < clean.Count; i++)
            {
                if (clean[i] == commmand)
                {
                    clean.Remove(swap);
                    clean.Insert(i + 1,swap);
                    break;
                }
            }
            return clean;
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
            line.Remove(command2);
            line.Insert(fist,command2);
            line.Remove(command1);
            line.Insert(second,command1);        
            return line;
        }

    }
}

