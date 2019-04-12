namespace Wild_Farm.Models.Animals
{
    using System;
    using Wild_Farm.Models.Contracts;
    public class Dog : Mammal
    {
        private static double Increase = 0.40;
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eating(IFood food)
        {
            string foodType = food.GetType().Name;
            if (foodType != "Meat")
            {
                throw new ArgumentException($"Dog does not eat {foodType}!");
            }
            this.Weight += food.Quantity * Increase;

            this.FoodEaten += food.Quantity;
        }

        public override string Sound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
