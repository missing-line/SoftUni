namespace _10.SoftUni_Exam_Results
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine();

            Dictionary<string, int> grade = new Dictionary<string, int>();
            Dictionary<string, int> courses = new Dictionary<string, int>();

            while (line != "exam finished")
            {
                if (!line.Contains("banned"))
                {
                    string[] student = line
                        .Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    string name = student[0];
                    string course = student[1];
                    int score = int.Parse(student[2]);

                    if (!grade.ContainsKey(name))
                    {
                        grade.Add(name, score);
                    }
                    else if (grade.ContainsKey(name) && grade[name] < score)
                    {
                        grade[name] = score;
                    }
                    if (!courses.ContainsKey(course))
                    {
                        courses.Add(course, 1);
                    }
                    else
                    {
                        courses[course]++;
                    }
                }
                else
                {
                    string[] student = line
                        .Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    string name = student[0];

                    if (grade.ContainsKey(name))
                    {
                        grade.Remove(name);
                    }
                }
                line = Console.ReadLine();
            }

            Console.WriteLine("Results:");
            foreach (var student in grade.OrderByDescending(x => x.Value).ThenBy(l => l.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var student in courses.OrderByDescending(x => x.Value).ThenBy(l => l.Key))
            {
                Console.WriteLine($"{student.Key} - {student.Value}");
            }
        }
    }
}
