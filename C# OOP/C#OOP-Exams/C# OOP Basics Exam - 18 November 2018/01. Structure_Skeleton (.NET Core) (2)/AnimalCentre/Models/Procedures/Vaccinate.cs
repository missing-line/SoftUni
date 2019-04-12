namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;
    public class Vaccinate : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);

            animal.Energy -= 8;
            animal.IsVaccinated = true;

            base.procedureHistory.Add(animal);
        }
    }
}
