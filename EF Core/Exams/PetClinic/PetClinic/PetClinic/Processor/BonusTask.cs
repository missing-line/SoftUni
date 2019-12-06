namespace PetClinic.Processor
{
    using PetClinic.Data;
    using System.Linq;

    public class BonusTask
    {
        public static string UpdateVetProfession(PetClinicContext context, string phoneNumber, string profession)
        {
            var vet = context.Vets
               .SingleOrDefault(x => x.PhoneNumber == phoneNumber);

            if (vet == null)
            {
                return $"Vet with phone number {phoneNumber} not found!";
            }
            
            string oldProfession = vet.Profession;

            vet.Profession = profession;

            context.SaveChanges();

            return $"Edmond Halley's profession updated from {oldProfession} to {profession}.";
        }
    }
}
