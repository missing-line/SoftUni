namespace Wild_Farm.Models.Food.Factory
{
    using Wild_Farm.Models.Contracts;
    public interface IFoodFactory
    {
        IFood CreateFood(string[] data);
    }
}
