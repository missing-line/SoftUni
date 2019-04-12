namespace SoftUniRestaurant.Models.Foods.FoodFacoty
{
    using SoftUniRestaurant.Models.Foods.Contracts;
    using System;
    public  class FoodFactory
    {
        public IFood CreateFood(string type, string name, decimal price)
        {
            switch (type)
            {
                case "Dessert":
                    return new Dessert(name, price);
                case "MainCourse":
                    return new MainCourse(name, price);
                case "Salad":
                    return new Salad(name, price);
                case "Soup":
                    return new Soup(name, price);
                default:
                    throw new ArgumentException("Invalid food type!");
            }
        }
    }
}
