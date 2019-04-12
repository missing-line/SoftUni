namespace Wild_Farm.Models.Animals
{
    using System;
    using Wild_Farm.Models.Contracts;
    public class Cat : Feline
    {
        private static double Increase = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }
        public override void Eating(IFood food)
        {
            string foodType = food.GetType().Name;
            if (!(foodType == "Meat" || foodType == "Vegetable"))
            {
                throw new ArgumentException($"Cat does not eat {foodType}!");
            }
            this.Weight += food.Quantity * Increase;

            this.FoodEaten += food.Quantity;
        }
        public override string Sound()
        {
            return "Meow";
        }

        public override string ToString()
        {
            return base.ToString();
        }

        
    }
}
