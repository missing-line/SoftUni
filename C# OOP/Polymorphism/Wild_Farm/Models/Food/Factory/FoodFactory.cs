namespace Wild_Farm.Models.Food.Factory
{
    using System;
    using Wild_Farm.Models.Contracts;
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string[] data)
        {
            string type = data[0];
            int quantity = int.Parse(data[1]);

            switch (type)
            {
                case "Meat":
                     IFood meat = new Meat(quantity);
                    return meat;
                case "Vegetable":
                    IFood vegetable = new Vegetable(quantity);
                    return vegetable;
                case "Fruit":
                    IFood fruit = new Fruit(quantity);
                    return fruit;
                case "Seeds":
                    IFood seed = new Seeds(quantity);
                    return seed;
                default:
                    throw new ArgumentException($"Invalid type!");
            }
        }
    }
}
