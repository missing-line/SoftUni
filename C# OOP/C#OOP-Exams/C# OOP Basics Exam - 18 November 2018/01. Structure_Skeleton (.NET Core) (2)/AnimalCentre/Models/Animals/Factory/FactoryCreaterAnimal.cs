namespace AnimalCentre.Models.Animals.Factory
{
    using System;
    using AnimalCentre.Models.Contracts;
    public class FactoryCreaterAnimal : IFactoryCreaterAnimal
    {
        public IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            switch (type)
            {
                case "Cat":
                    IAnimal cat = new Cat(name,energy,happiness,procedureTime);
                    return cat;
                case "Dog":
                    IAnimal dog = new Dog(name, energy, happiness, procedureTime);
                    return dog;
                case "Lion":
                    IAnimal lion = new Lion(name, energy, happiness, procedureTime);
                    return lion;
                case "Pig":
                    IAnimal pig = new Pig(name, energy, happiness, procedureTime);
                    return pig;
                default:
                    throw new ArgumentException("Invalid type");
            }
        }
    }
}
