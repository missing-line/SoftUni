namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;
    using TeisterMask.DataProcessor.ExportDto;
    using System.Linq;
    using System.Globalization;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;

    using Task = Data.Models.Task;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var xml = new XmlSerializer(typeof(ImportProjectTask[]), new XmlRootAttribute("Projects"));

            var dtos = (ImportProjectTask[])xml
                .Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var projects = new List<Project>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projectOpen = DateTime.ParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                var validTasks = new List<Task>();
                foreach (var t in dto.Tasks)
                {
                    if (!IsValid(t))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new Task()
                    {
                        Name = t.Name,
                        OpenDate = DateTime.ParseExact(t.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        DueDate = DateTime.ParseExact(t.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ExecutionType = (ExecutionType)t.ExecutionType,
                        LabelType = (LabelType)t.LabelType
                    };

                    if (task.OpenDate < projectOpen)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (dto.DueDate != "" && dto.DueDate != null)
                    {
                        var projectDue = DateTime.ParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        if (task.DueDate > projectDue)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }

                    validTasks.Add(task);
                }

                var project = new Project()
                {
                    Name = dto.Name,
                    OpenDate = projectOpen,
                    DueDate = null,
                    Tasks = validTasks
                };

                if (dto.DueDate != "" && dto.DueDate != null)
                {
                    project.DueDate = DateTime.ParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                projects.Add(project);

                sb.AppendLine(string.Format
                    (
                        SuccessfullyImportedProject,
                        project.Name, project.Tasks.Count()
                    ));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var employees = new List<Employee>();

            var dtos = JsonConvert
                .DeserializeObject<ImportEmployee[]>(jsonString);


            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var emp = new Employee()
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    Phone = dto.Phone,
                };


                var tasks = dto.Tasks.Distinct().ToList();
               
                foreach (var taskId in tasks)
                {
                    var task = context.Tasks.Find(taskId);
                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    emp.EmployeesTasks.Add(new EmployeeTask {Task = task});
                }
              
                context.Employees.Add(emp);

                sb.AppendLine(string.Format
                    (
                        SuccessfullyImportedEmployee,
                        dto.Username, emp.EmployeesTasks.Count
                    ));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}