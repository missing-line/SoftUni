namespace Wild_Farm.Models.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        string Sound();

        void Eating(IFood food);
    }
}
