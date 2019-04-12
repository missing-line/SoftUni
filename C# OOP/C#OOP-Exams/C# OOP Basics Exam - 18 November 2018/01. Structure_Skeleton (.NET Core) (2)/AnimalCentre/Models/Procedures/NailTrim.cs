namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;
    public class NailTrim : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);

            animal.Happiness -= 7;
            base.procedureHistory.Add(animal);
        }
    }
}
