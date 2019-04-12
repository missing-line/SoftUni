namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;
    public class DentalCare : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);

            animal.Happiness += 12;
            animal.Energy += 10;

            base.procedureHistory.Add(animal);
        }
    }
}
