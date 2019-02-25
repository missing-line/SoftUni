namespace Average_Student_Grades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studens = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine()
                    .Split()
                    .ToArray();

                string name = arr[0];
                double grade = double.Parse(arr[1]);
                if (!studens.ContainsKey(name))
                {
                    studens.Add(name, new List<double>());
                }
                studens[name].Add(grade);
            }

            foreach (var student in studens)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var inner in student.Value)
                {
                    Console.Write($"{inner:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");  
            }
        }    
    }
}
