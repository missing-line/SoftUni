namespace Wild_Farm.Models.Animals
{
    using System;
    using Wild_Farm.Models.Contracts;
    public class Mouse : Mammal
    {
        private static double Increase = 0.10;
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eating(IFood food)
        {
            string foodType = food.GetType().Name;
            if (!(foodType == "Fruit" || foodType == "Vegetable"))
            {
                throw new ArgumentException($"Mouse does not eat {foodType}!");
            }
            this.Weight += food.Quantity * Increase;

            this.FoodEaten += food.Quantity;
        }

        public override string Sound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString();
        }
             
    }
}
