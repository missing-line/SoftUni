namespace WorkForce
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var jobs = new JobsList();
            var employees = new List<Employee>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split()
                    .ToArray();

                string command = tokens[0];

                switch (command)
                {
                    case "Job":

                        string jobName = tokens[1];
                        int hours = int.Parse(tokens[2]);
                        Employee employee = employees.FirstOrDefault(x=>x.Name == tokens[3]);
                        var job = new Job(jobName,hours, employee);                     

                        job.JobDone += jobs.Done;
                        jobs.Add(job);
                        
                        break;
                    case "StandardEmployee":
                        var standart = new StandardEmployee(tokens[1]);
                        employees.Add(standart);
                        break;
                    case "PartTimeEmployee":
                        var part = new PartTimeEmployee(tokens[1]);
                        employees.Add(part);
                        break;
                    case "Pass":
                        foreach (var currJob in jobs.ToList())
                        {
                            currJob.Update();
                        }               
                        break;
                    case "Status":
                        foreach (Job currJob in jobs)
                        {
                            Console.WriteLine(currJob);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
