namespace Wild_Farm.Models.Animals.Factory
{
    using Wild_Farm.Models.Contracts;
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string[] data);
    }
}
