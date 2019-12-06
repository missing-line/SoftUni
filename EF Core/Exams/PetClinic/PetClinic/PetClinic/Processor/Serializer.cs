namespace PetClinic.Processor
{
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;
    using PetClinic.Data;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;
    using PetClinic.Processor.Dto.Export;
    using System.Xml;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Animals
                 .Where(x => x.Passport.OwnerPhoneNumber == phoneNumber)
                 .Select(x => new
                 {
                     OwnerName = x.Passport.OwnerName,
                     AnimalName = x.Name,
                     Age = x.Age,
                     SerialNumber = x.PassportSerialNumber,
                     RegisteredOn = x.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                 })
                 .ToArray();

            return JsonConvert.SerializeObject(animals, Formatting.Indented);
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {

           var producers = context.Procedures
               .Select(x => new ExportProducerDto
               {
                   Passport = x.Animal.PassportSerialNumber,
                   OwnerNumber = x.Animal.Passport.OwnerPhoneNumber,
                   DateTime = x.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                   AnimalAids = x.ProcedureAnimalAids
                   .Select(y => new ExportAnimalAidsDto 
                   { 

                       Name = y.AnimalAid.Name,
                       Price = y.AnimalAid.Price
                   })
                   .ToArray(),
                   TotalPrice = x.Cost
               })
               .OrderBy(x => DateTime.ParseExact(x.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture))
               .ThenBy(x => x.Passport)
               .ToArray();

            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ExportProducerDto[]), new XmlRootAttribute("Procedures"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xml.Serialize(new StringWriter(sb), producers, namespaces);
            return sb.ToString().TrimEnd();
        }
    }
}
