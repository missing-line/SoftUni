namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(x => new
                {
                    x.Id,
                    Name = x.FullName,
                    x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers
                    .Select(o => new
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name

                    })
                    .OrderBy(f => f.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = Math.Round(x.PrisonerOfficers.Sum(y => y.Officer.Salary), 2)
                })
                .OrderBy(f => f.Name)
                .ThenBy(id => id.Id)
                .ToList();

            return JsonConvert.SerializeObject(prisoners, Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames
                .Split(",")
                .ToArray();

            var prisoners = context.Prisoners
                .Where(x => prisonersNames.Contains(x.FullName))
                .Select(x => new ExportPrisonerDTO
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = x.Mails.Select(m => new EncryptedMessagesDto
                    {
                        Description = Reverse(m.Description)
                    })
                    .ToArray()
                })
                .OrderBy(n => n.Name)
                .ThenBy(id => id.Id)
                .ToArray();


            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ExportPrisonerDTO[]), new XmlRootAttribute("Prisoners"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xml.Serialize(new StringWriter(sb), prisoners, namespaces);

            return sb.ToString().TrimEnd();
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}