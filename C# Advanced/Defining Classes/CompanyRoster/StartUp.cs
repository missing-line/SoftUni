namespace CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employeers = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string[] employee = Console.ReadLine()
                    .Split()
                    .ToArray();

                string name = employee[0];
                decimal salary = decimal.Parse(employee[1]);
                string position = employee[2];
                string department = employee[3];
                string email;
                int age;
                Employee emp = new Employee(name, salary, position, department);
                if (employee.Length == 5)
                {
                    if (employee[4].Contains("@"))
                    {
                        email = employee[4];
                        emp.Email = email;
                    }
                    else
                    {
                        age = int.Parse(employee[4]);
                        emp.Age = age;
                    }
                }
                else if (employee.Length == 6)
                {
                    email = employee[4];
                    age = int.Parse(employee[5]);
                    emp.Email = email;
                    emp.Age = age;
                }
                employeers.Add(emp);
            }


            var bestSalatyDepartment = employeers
                .GroupBy(x => x.Department)
                .ToDictionary(x => x.Key, y => y.Select(s => s))
                .OrderByDescending(p => p.Value.Average(u => u.Salary))
                .FirstOrDefault();

            string key = bestSalatyDepartment.Key;

            Console.WriteLine($"Highest Average Salary: {key}");
            foreach (var employeer in bestSalatyDepartment.Value.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employeer.Name} {employeer.Salary:f2} {employeer.Email} {employeer.Age}");
            }
        }

    }
}
