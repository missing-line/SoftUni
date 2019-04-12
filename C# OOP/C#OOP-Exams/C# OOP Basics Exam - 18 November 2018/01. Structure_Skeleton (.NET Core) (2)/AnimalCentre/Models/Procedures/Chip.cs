namespace AnimalCentre.Models.Procedures
{
    using System;
    using AnimalCentre.Models.Contracts;
    public class Chip : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);

            if (animal.IsChipped)
            {
                throw new ArgumentException($"ArgumentException: {animal.Name} is already chipped");
            }

            animal.Happiness -= 5;
            animal.IsChipped = true;

            base.procedureHistory.Add(animal);
        }
    }
}
