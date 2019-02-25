namespace _4._Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public class Student
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public double Grade { get; set; }
        }
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] studen = Console.ReadLine().Split().ToArray();

                students.Add(new Student()
                {
                    FirstName = studen[0],
                    SecondName = studen[1],
                    Grade = double.Parse(studen[2])
                });
            }

            foreach (var student in students.OrderByDescending(x => x.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.SecondName}: {(student.Grade):f2}");
            }
        }
    }
}
