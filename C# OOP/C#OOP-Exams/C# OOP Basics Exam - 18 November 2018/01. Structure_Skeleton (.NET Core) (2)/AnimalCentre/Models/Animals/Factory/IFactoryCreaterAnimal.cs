namespace AnimalCentre.Models.Animals.Factory
{
    using AnimalCentre.Models.Contracts;
    public interface IFactoryCreaterAnimal
    {
        IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime);
    }
}
