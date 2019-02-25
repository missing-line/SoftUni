namespace _06._Courses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] command = Console.ReadLine()
                .Split(":".ToCharArray(), StringSplitOptions.None)
                .ToArray();

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (command[0] != "end")
            {
                string course = command[0].Trim();
                string name = command[1].Trim();

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }

                courses[course].Add(name);
                command = Console.ReadLine()
                .Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            foreach (var students in courses.OrderByDescending(x => x.Value.Count()))
            {
                Console.WriteLine($"{students.Key}: {students.Value.Count()}");
                foreach (var inner in students.Value.OrderBy(l => l))
                {
                    Console.WriteLine($"-- {inner}");
                }
            }
        }
    }
}
