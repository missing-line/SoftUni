namespace Wild_Farm.Models.Animals
{
    using System;
    using Wild_Farm.Models.Contracts;
    class Tiger : Feline
    {
        private static double Increase = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eating(IFood food)
        {
            string foodType = food.GetType().Name;
            if (foodType != "Meat")
            {
                throw new ArgumentException($"Tiger does not eat {foodType}!");
            }
            this.Weight += food.Quantity * Increase;

            this.FoodEaten += food.Quantity;
        }

        public override string Sound()
        {
            return "ROAR!!!";
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
