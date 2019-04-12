namespace SoftUniRestaurant.Models.Drinks
{
    public class FuzzyDrink : Drink
    {
        private const decimal FuzzyDrinkPrice = 2.50m;
        public FuzzyDrink(string name, int serviceSize, string brand)
            : base(name, serviceSize, FuzzyDrinkPrice, brand)
        {
        }
    }
}
