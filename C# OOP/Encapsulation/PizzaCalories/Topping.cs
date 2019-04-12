namespace PizzaCalories
{
    using System;
    using System.Linq;
    public class Topping
    {
        private const int BaseCalories = 2;

        private static object[] allowedTypes =
        {
            new {Type = "meat",CaloriesModifier = 1.2 },
            new {Type = "veggies",CaloriesModifier = 0.8 },
            new {Type = "cheese",CaloriesModifier = 1.1 },
            new {Type = "sauce",CaloriesModifier = 0.9 },
        };

        private string type;
        private int weight;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public int Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public string Type
        {
            get { return this.type; }
            set
            {
                if (!allowedTypes.Any(x => (string)x.GetType().GetProperty("Type").GetValue(x, null) == value.ToLower())
                    )
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public double Calories()
        {
            var typeObeject = allowedTypes.First(x => (string)x.GetType().GetProperty("Type").GetValue(x, null) == this.Type.ToLower());
            var typeModifier = (double)typeObeject.GetType().GetProperty("CaloriesModifier").GetValue(typeObeject, null);

            return typeModifier * BaseCalories * this.Weight;
        }
    }
}
