namespace Wild_Farm.Models.Animals
{
    using System;
    using Wild_Farm.Models.Contracts;
    public class Owl : Bird
    {
        private static double Increase = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }


        public override void Eating(IFood food)
        {
            string foodType = food.GetType().Name;
            if (foodType != "Meat")
            {
                throw new ArgumentException($"Own does not eat {foodType}!");
            }
            this.Weight += food.Quantity * Increase;

            this.FoodEaten += food.Quantity;
        }

        public override string Sound()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

