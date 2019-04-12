namespace AnimalCentre.Models.Procedures
{
    using System;
    using AnimalCentre.Models.Contracts;
    public class Fitness : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);

            animal.Happiness -= 3;
            animal.Energy += 10;

            base.procedureHistory.Add(animal);
        }
    }
}
