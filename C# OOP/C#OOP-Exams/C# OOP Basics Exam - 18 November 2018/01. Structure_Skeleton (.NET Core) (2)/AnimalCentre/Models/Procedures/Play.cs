namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;
    public class Play : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);

            animal.Happiness += 12;
            animal.Energy -= 6;

            base.procedureHistory.Add(animal);
        }
    }
}
