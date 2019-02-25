namespace Student_Academy
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> grade = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double currGrade = double.Parse(Console.ReadLine());
                if (!grade.ContainsKey(name))
                {
                    grade.Add(name, new List<double>());
                }
                grade[name].Add(currGrade);
            }

            foreach (var item in grade.OrderByDescending(x => x.Value.Average()).Where(x => x.Value.Average() >= 4.50))
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
            }
        }
    }
}
