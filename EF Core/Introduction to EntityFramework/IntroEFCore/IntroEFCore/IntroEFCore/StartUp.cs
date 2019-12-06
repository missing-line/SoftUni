namespace SoftUni
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private static SoftUniContext context = new SoftUniContext();
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            using (context)
            {
                Print(DeleteProjectById(context));
            }
        }

        private static void Print(string text)
        {
            Console.WriteLine(text);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.MiddleName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(id => id.EmployeeId)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName);


            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
               .Employees
               .Where(x => x.Department.Name == "Research and Development")
               .Select(e => new
               {
                   e.FirstName,
                   e.LastName,
                   DepartmentName = e.Department.Name,
                   e.Salary
               })
               .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName)
               .ToList();


            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            //context.Addresses.Add(address);

            var name = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            name.Address = address;

            context.SaveChanges();

            var employees = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new
                {
                    e.Address.AddressText
                })
                .Take(10)
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine(emp.AddressText); ;
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(s => s.Project.StartDate.Year >= 2001 &&
                                                    s.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EmpFullName = x.FirstName + " " + x.LastName,
                    ManagerFullName = x.Manager.FirstName + " " + x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate,
                    })
                })
                .Take(10)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmpFullName} - Manager: {employee.ManagerFullName}");

                foreach (var inner in employee.Projects)
                {
                    sb.AppendLine($"--{inner.ProjectName} - {inner.StartDate} - {(inner.EndDate == null ? "not finished" : inner.EndDate.ToString())}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Addresses
                .GroupBy(a => new
                {
                    a.AddressId,
                    a.AddressText,
                    a.Town.Name
                }, (key, value) => new
                {
                    AddressText = key.AddressText,
                    TownName = key.Name,
                    Count = value.Sum(e => e.Employees.Count)
                })
                .OrderByDescending(e => e.Count).ThenBy(e => e.TownName).ThenBy(t => t.AddressText)
                .Take(10)
                .ToList();

            foreach (var o in employees)
            {
                sb.AppendLine($"{o.AddressText}, {o.TownName} - {o.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var e = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = x.EmployeesProjects
                    .Select(p => p.Project.Name)
                    .OrderBy(l => l)
                    .ToList()
                })
                .FirstOrDefault();

            return $"{e.FirstName} {e.LastName} - {e.JobTitle}{Environment.NewLine}{string.Join(Environment.NewLine, e.Projects)}";
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var selectCollections = context.Departments
                .Include(d => d.Employees)
                .Include(d => d.Manager)
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToList();

            foreach (var row in selectCollections)
            {
                sb.AppendLine($"{row.Name} - {row.Manager.FirstName}");

                foreach (var employee in row.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var collection = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new { p.Name, p.Description, p.StartDate })
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var line in collection)
            {
                sb.AppendLine($"{line.Name}");
                sb.AppendLine($"{line.Description}");
                sb.AppendLine($"{line.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var collection = context.Employees
                .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }.Contains(e.Department.Name))
                .ToList();

            foreach (var employee in collection)
            {
                employee.Salary += employee.Salary * 0.12m;
            }

            context.SaveChanges();


            foreach (var employee in collection.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var collection = context.Employees
                .Where(x => x.FirstName.Substring(0, 2) == "Sa")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();


            foreach (var emp in collection.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var project = context.Projects
                .FirstOrDefault(p => p.ProjectId == 2);

            var referenced = context.EmployeesProjects
                .FirstOrDefault(ep => ep.ProjectId == 2);

            context.EmployeesProjects
                .Remove(referenced);

            context.Projects
                .Remove(project);

            context.SaveChanges();

            context.Projects
                .Select(p => new { p.Name })
                .Take(10)
                .ToList().ForEach(x => sb.AppendLine($"{x.Name}"));

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {

            context.Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToList()
                .ForEach(x => x.AddressId = null);

            var count = context.Addresses
                .Where(x => x.Town.Name == "Seattle")
                .ToList()
                .Count();

            context.Addresses
                .Where(x => x.Town.Name == "Seattle")
                .ToList()
                .ForEach(x => context.Addresses.Remove(x));

            context.Towns
                .Remove(context.Towns.SingleOrDefault(x => x.Name == "Seattle"));

            context.SaveChanges();

            return $"{count} addresses in Seattle were deleted";
        }
    }
}

