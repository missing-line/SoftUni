namespace _01._Company_Roster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public class Profession
        {
            public string Name { set; get; }
            public double Salary { set; get; }
            public string Department { set; get; }
        }
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Profession> proff = new List<Profession>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split().ToArray();
                proff.Add(new Profession()
                {
                    Name = line[0],
                    Salary = double.Parse(line[1]),
                    Department = line[2],
                });
            }

            Dictionary<string, List<double>> bestSalary = new Dictionary<string, List<double>>();

            foreach (var bestSalarys in proff)
            {
                if (!bestSalary.ContainsKey(bestSalarys.Department))
                {
                    bestSalary.Add(bestSalarys.Department, new List<double>() { bestSalarys.Salary });
                }
                else if (bestSalary.ContainsKey(bestSalarys.Department))
                {
                    bestSalary[bestSalarys.Department].Add(bestSalarys.Salary);
                }
            }

            foreach (var bestS in bestSalary.OrderByDescending(x => x.Value.Average()))
            {
                Console.WriteLine($"Highest Average Salary: {bestS.Key}");
                foreach (var item in proff.OrderByDescending(x => x.Salary))
                {
                    if (item.Department == bestS.Key)
                    {
                        Console.WriteLine($"{item.Name} {(item.Salary):f2}");
                    }
                }
                return;
            }

        }
    }
}