namespace PetClinic.Processor
{
    using AutoMapper;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.Models;
    using PetClinic.Processor.Dto.Import;
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
        private const string ErrorMessage = "Error: Invalid data.";
        private const string SuccessMessage = "Record {0} successfully imported.";
        private const string SuccessMessageImportAnimal = "Record {0} Passport №: {1} successfully imported.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var animalAids = new List<AnimalAid>();

            var dtos = JsonConvert
                .DeserializeObject<ImportAnimalAidDto[]>(jsonString);


            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || animalAids.Any(a => a.Name == dto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var animalAid = Mapper.Map<AnimalAid>(dto);
                animalAids.Add(animalAid);

                sb.AppendLine(string.Format(SuccessMessage,
                    animalAid.Name));
            }

            context.AnimalAids.AddRange(animalAids);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var animals = new List<Animal>();

            var dtos = JsonConvert
                .DeserializeObject<ImportAnimalDto[]>(jsonString);

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) ||
                    !IsValid(dto.Passport) ||
                    animals.Any(a => a.PassportSerialNumber == dto.Passport.SerialNumber))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var passport = new Passport
                {
                    SerialNumber = dto.Passport.SerialNumber,
                    OwnerName = dto.Passport.OwnerName,
                    OwnerPhoneNumber = dto.Passport.OwnerPhoneNumber,
                    RegistrationDate = DateTime.ParseExact(dto.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                };



                animals.Add(new Animal
                {
                    Name = dto.Name,
                    Age = dto.Age,
                    Type = dto.Type,
                    Passport = passport
                });
                sb.AppendLine(string.Format(SuccessMessageImportAnimal, dto.Name, dto.Passport.SerialNumber));
            }


            context.Animals.AddRange(animals);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var vets = new List<Vet>();

            var xml = new XmlSerializer(typeof(ImportVetDto[]), new XmlRootAttribute("Vets"));

            var dtos = (ImportVetDto[])xml
                .Deserialize(new StringReader(xmlString));

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || vets.Any(v => v.PhoneNumber == dto.PhoneNumber))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                vets.Add(Mapper.Map<Vet>(dto));

                sb.AppendLine(string.Format(
                    SuccessMessage,
                    dto.Name));
            }

            context.Vets.AddRange(vets);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var procedures = new List<Procedure>();
            var procedureAnimalAids = new List<ProcedureAnimalAid>();

            var xml = new XmlSerializer(typeof(ImportProducerDto[]), new XmlRootAttribute("Procedures"));

            var dtos = (ImportProducerDto[])xml
                .Deserialize(new StringReader(xmlString));

            foreach (var dto in dtos)
            {
                var vet = context.Vets.SingleOrDefault(v => v.Name == dto.Vet);
                var animal = context.Animals.SingleOrDefault(v => v.PassportSerialNumber == dto.Animal);

                if (!IsValid(dto) ||
                    !dto.AnimalAids.All(IsValid) ||
                    vet == null ||
                    animal == null ||
                    !IsExistOrUnique(context, dto.AnimalAids))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }



                var procedure = new Procedure
                {
                    Animal = animal,
                    Vet = vet,
                    DateTime = DateTime.ParseExact(dto.DateTime, @"dd-MM-yyyy", CultureInfo.InvariantCulture)
                };


                var currentProcedureAnimalAid = new List<ProcedureAnimalAid>();
                foreach (var aid in dto.AnimalAids)
                {
                    var pa = procedureAnimalAids
                        .SingleOrDefault(x => x.AnimalAid.Name == aid.Name && x.ProcedureId == procedure.Id);
                    if (pa == null)
                    {
                        pa = new ProcedureAnimalAid
                        {
                            Procedure = procedure,
                            AnimalAid = context.AnimalAids.SingleOrDefault(x => x.Name == aid.Name)
                        };
                        procedureAnimalAids.Add(pa);
                    }
                    currentProcedureAnimalAid.Add(pa);
                }

                procedure.ProcedureAnimalAids = currentProcedureAnimalAid;
                procedures.Add(procedure);

                sb.AppendLine("Record successfully imported.");
            }

            context.Procedures.AddRange(procedures);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsExistOrUnique(PetClinicContext context, ICollection<AnimalAidDto> dtos)
        {
            foreach (var aid in dtos)
            {
                var aidEntity = context
                    .AnimalAids
                    .SingleOrDefault(x => x.Name == aid.Name);

                if (aidEntity == null)
                {
                    return false;
                }
            }

            var count = dtos.Distinct().ToList().Count();
            if (count != dtos.Count)
            {
                return false;
            }

            return true;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
