namespace PetClinic
{
    using AutoMapper;
    using PetClinic.Data;
    using PetClinic.Processor;
    using System;
    using System.IO;

    public class StartUp
    {
        private const string baseURl = @"C:\Users\swade\Desktop\Pet Clinic\PetClinic\PetClinic\Datasets\";
        public static void Main(string[] args)
        {
            using (var context = new PetClinicContext())
            {
                Mapper.Initialize(config => config.AddProfile<PetClinicProfile>());
                ResetDataBase(context);
                ImportEntities(context, baseURl);
                ExportEntities(context);
                Bonus(context);
            }
        }

        private static void Bonus(PetClinicContext context)
        {
            string bonusMessage = BonusTask.UpdateVetProfession(context, "+359284566778", "Primary Care");
            Printer(bonusMessage);
        }

        private static void ExportEntities(PetClinicContext context)
        {
            string exportAnimalsByOwnerPhoneNumber = Serializer.ExportAnimalsByOwnerPhoneNumber(context, "0887446123");
            Printer(exportAnimalsByOwnerPhoneNumber);

            string exportAllProcedures = Serializer.ExportAllProcedures(context);
            Printer(exportAllProcedures);
        }

        private static void ImportEntities(PetClinicContext context, string baseURl)
        {
            string animalAidsEntities = Deserializer.ImportAnimalAids(context, File.ReadAllText(baseURl + "animalAids.json"));
            Printer(animalAidsEntities);

            string animalsEntities = Deserializer.ImportAnimals(context, File.ReadAllText(baseURl + "animals.json"));
            Printer(animalsEntities);

            string vetsEntities = Deserializer.ImportVets(context, File.ReadAllText(baseURl + "vets.xml"));
            Printer(vetsEntities);

            string proceduresEntities = Deserializer.ImportProcedures(context, File.ReadAllText(baseURl + "procedures.xml"));
            Printer(proceduresEntities);
        }

        private static void Printer(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void ResetDataBase(PetClinicContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            Printer("ResetDataBase");
        }
    }
}
