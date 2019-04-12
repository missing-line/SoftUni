namespace SoftUniRestaurant.Models.Foods.Contracts
{
    public class Dessert : Food
    {
        private const int InitialServingSize = 200;
        public Dessert(string name, decimal price) 
            : base(name, InitialServingSize, price)
        {          
        }       
    }
}
