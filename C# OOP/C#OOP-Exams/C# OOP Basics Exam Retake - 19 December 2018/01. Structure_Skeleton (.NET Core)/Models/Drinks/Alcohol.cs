namespace SoftUniRestaurant.Models.Drinks
{
    public class Alcohol : Drink
    {
        private const decimal AlcoholPrice = 3.50m;

        public Alcohol(string name, int serviceSize, string brand) 
            : base(name, serviceSize, AlcoholPrice, brand)
        {
        }
            
    }
}
