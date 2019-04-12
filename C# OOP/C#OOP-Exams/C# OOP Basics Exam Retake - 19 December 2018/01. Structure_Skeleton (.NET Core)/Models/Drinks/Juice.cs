namespace SoftUniRestaurant.Models.Drinks
{

    public class Juice : Drink
    {
        private const decimal JuicePrice = 1.80m;
        public Juice(string name, int serviceSize, string brand)
            : base(name, serviceSize, JuicePrice, brand)
        {
        }
    }
}
