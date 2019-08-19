using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Course_Planning2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> courses = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] command = Console.ReadLine()
                .Split(":".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            while (string.Join(" ",command) != "course start")
            {
                if (command[0] == "Add")
                {
                    if (!courses.Contains(command[1]))
                    {
                        courses.Add(command[1]);
                    }
                }
                else if (command[0] == "Insert")
                {
                    if (!courses.Contains(command[1]) &&
                        int.Parse(command[2]) >= 0 &&
                        int.Parse(command[2]) < courses.Count) //
                    {
                        courses.Insert(int.Parse(command[2]),command[1]);
                    }
                }
                else if (command[0] == "Remove")
                {
                    string curr = $"{command[1]}-Exercise";
                    if (courses.Contains(command[1]))
                    {
                        courses.Remove(command[1]);
                        if (courses.Contains(curr))
                        {
                            courses.Remove(curr);
                        }
                    }
                }
                else if (command[0] == "Exercise")
                {
                    string curr = $"{command[1]}-Exercise";
                    if (courses.Contains(command[1]) &&
                        !courses.Contains(curr))
                    {
                        int index = courses.IndexOf(command[1]);
                        courses.Insert(index + 1,curr); // 
                    }
                    else if(!courses.Contains(command[1]))
                    {
                        courses.Add(command[1]);
                        courses.Add(curr);
                    }
                }
                else if (command[0] == "Swap")
                {
                    if (courses.Contains(command[1]) &&
                        courses.Contains(command[2]))
                    {
                        int index1 = courses.IndexOf(command[1]);
                        int index2 = courses.IndexOf(command[2]);
                        courses[index1] = command[2];
                        courses[index2] = command[1];
                        if (courses.Contains($"{command[2]}-Exercise"))
                        {
                            string insert = $"{command[2]}-Exercise";
                            courses.Remove($"{command[2]}-Exercise");
                            courses.Insert(index1 + 1, insert);
                        }                       
                    }
                }
                command = Console.ReadLine()
                .Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{courses[i]}");
            }
        }
    }
}
