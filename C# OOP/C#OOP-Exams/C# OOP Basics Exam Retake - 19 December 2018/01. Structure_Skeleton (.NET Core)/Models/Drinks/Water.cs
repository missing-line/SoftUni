namespace SoftUniRestaurant.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal WaterPrice = 1.50m;
        public Water(string name, int serviceSize, string brand)
            : base(name, serviceSize, WaterPrice, brand)
        {
        }
    }
}
