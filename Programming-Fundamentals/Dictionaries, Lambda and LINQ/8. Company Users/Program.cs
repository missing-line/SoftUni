namespace _8._Company_Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] command = Console.ReadLine()
                .Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, List<string>> company = new Dictionary<string, List<string>>();

            while (command[0] != "End")
            {
                string companyName = command[0].Trim();
                string nameemployeeId = command[1].Trim();

                if (!company.ContainsKey(companyName))
                {
                    company.Add(companyName, new List<string>());
                }
                if (!company[companyName].Contains(nameemployeeId))
                {
                    company[companyName].Add(nameemployeeId);
                }

                command = Console.ReadLine()
                .Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            foreach (var currComp in company.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{currComp.Key}");
                foreach (var inner in currComp.Value)
                {
                    Console.WriteLine($"-- {inner}");
                }
            }
        }
    }
}
