namespace Wild_Farm.Models.Animals.Factory
{
    using System;
    using Wild_Farm.Models.Contracts;
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] data)
        {
            string type = data[0];
            string name = data[1];
            double weight = double.Parse(data[2]);

            switch (type)
            {
                case "Owl":
                    IAnimal owl = new Owl(name, weight, double.Parse(data[3]));
                    return owl;
                case "Hen":
                    IAnimal hen = new Hen(name, weight, double.Parse(data[3]));
                    return hen;
                case "Cat":
                    IAnimal cat = new Cat(name, weight, data[3],data[4]);
                    return cat;
                case "Tiger":
                    IAnimal tiger = new Tiger(name, weight, data[3], data[4]);
                    return tiger;
                case "Dog":
                    IAnimal dog = new Dog(name, weight, data[3]);
                    return dog;
                case "Mouse":
                    IAnimal mouse = new Mouse(name, weight, data[3]);
                    return mouse;
                default:
                    throw new ArgumentException("Invalid type animal!");
            }
        }
    }
}
