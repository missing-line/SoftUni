namespace SoftUniRestaurant.Models.Drinks.Factory
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using System;
    public  class DrinkFactory
    {
        public IDrink CreateDrink(string type, string name, int servingSize, string brand)
        {
            switch (type)
            {
                case "Alcohol":
                    return new Alcohol(name, servingSize, brand);
                case "FuzzyDrink":
                    return new FuzzyDrink(name, servingSize, brand);
                case "Juice":
                    return new Juice(name, servingSize, brand);
                case "Water":
                    return new Water(name, servingSize, brand);
                default:
                    throw new ArgumentException("Invalid type!");
            }
        }
    }
}
