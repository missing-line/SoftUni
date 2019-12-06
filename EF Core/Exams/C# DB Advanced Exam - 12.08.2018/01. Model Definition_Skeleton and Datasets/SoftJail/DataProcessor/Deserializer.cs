namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static DateTimeStyles CulturInfo { get; private set; }

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departments = JsonConvert.DeserializeObject<Department[]>(jsonString);

            var validatCollections = new List<Department>();

            var sb = new StringBuilder();

            foreach (var dep in departments)
            {
                var isValid = IsValid(dep) && dep.Cells.All(IsValid);

                if (isValid)
                {
                    validatCollections.Add(dep);
                    sb.AppendLine($"Imported {dep.Name} with {dep.Cells.Count} cells");
                    continue;
                }
                sb.AppendLine("Invalid Data");
            }

            context.Departments.AddRange(validatCollections);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var jsonExportDto = JsonConvert.DeserializeObject<PrisonerDTO[]>(jsonString);

            var validEntities = new List<Prisoner>();

            var sb = new StringBuilder();

            foreach (var dto in jsonExportDto)
            {
                var isValid = IsValid(dto) && dto.FullName != null && dto.Mails.All(IsValid);

                if (isValid)
                {
                    validEntities.Add(new Prisoner()
                    {
                        FullName = dto.FullName,
                        Nickname = dto.NickName,
                        Age = dto.Age,
                        IncarcerationDate = DateTime.ParseExact(dto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ReleaseDate = dto.ReleaseDate == null ? new DateTime?() : DateTime.ParseExact(dto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Bail = dto.Bail,
                        CellId = dto.CellId,
                        Mails = dto.Mails.Select(x => new Mail
                        {
                            Description = x.Description,
                            Sender = x.Sender,
                            Address = x.Address
                        })
                        .ToList()
                    });
                    sb.AppendLine($"Imported {dto.FullName} {dto.Age} years old");
                    continue;
                }
                sb.AppendLine("Invalid Data");
            }

            context.Prisoners.AddRange(validEntities);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var officers = new List<Officer>();

            var xml = new XmlSerializer(typeof(OfficerDTO[]), new XmlRootAttribute("Officers"));

            var dtos = (OfficerDTO[])xml
                .Deserialize(new StringReader(xmlString));

            foreach (var dto in dtos)
            {
                var position = Enum.TryParse<Position>(dto.Position, out Position resultPosition);
                var weapon = Enum.TryParse<Weapon>(dto.Weapon, out Weapon resultWeapon);

                if (!IsValid(dto) ||
                    !position ||
                    !weapon
                    )
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer
                {
                    FullName = dto.Name,
                    Salary = dto.Money,
                    Position = Enum.Parse<Position>(dto.Position),
                    Weapon = Enum.Parse<Weapon>(dto.Weapon),
                    DepartmentId = dto.DepartmentId,
                    OfficerPrisoners = dto.Prisoners
                    .Select(x => new OfficerPrisoner { PrisonerId = x.Id })
                    .ToList()
                };

                officers.Add(officer);

                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count()} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}