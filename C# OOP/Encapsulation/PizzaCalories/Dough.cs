namespace PizzaCalories
{
    using System;
    using System.Linq;
    public class Dough
    {
        private const int BaseCaloriesPerGram = 2;

        private static object[] allowedFlourTypes =
        {
            new { Type = "white", CaloriesModifier = 1.5 },
            new { Type = "wholegrain", CaloriesModifier = 1.0 }
        };

        private static object[] allowedBakingTechnique =
        {
            new {BakingTechnique = "crispy", CaloriesModifier = 0.9},
            new {BakingTechnique = "chewy" ,CaloriesModifier = 1.1},
            new {BakingTechnique = "homemade",CaloriesModifier = 1.0 },
        };

        private string type;
        private string bakingTechnique;
        private int weight;

        public Dough(string type, string bakingTechnique, int weight)
        {
            this.Type = type;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            set
            {
                if (!allowedBakingTechnique.Any(bt => (string)bt.GetType().GetProperty("BakingTechnique").GetValue(bt,null) == value.ToLower())
                    )
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        public int Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public string Type
        {
            get { return this.type; }
            set
            {
                if (!allowedFlourTypes.Any(
                    ft => (string)ft.GetType().GetProperty("Type").GetValue(ft, null) == value.ToLower())
                    )
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.type = value;
            }
        }

        public double Calories()
        {
            var ftObject = allowedFlourTypes.First(ft => (string)ft.GetType().GetProperty("Type").GetValue(ft, null) == this.Type.ToLower());
            var ftModifier = (double)ftObject.GetType().GetProperty("CaloriesModifier").GetValue(ftObject, null);


            var btObject = allowedBakingTechnique.First(bt => (string)bt.GetType().GetProperty("BakingTechnique").GetValue(bt, null) == this.BakingTechnique.ToLower());
            var btModifier = (double)btObject.GetType().GetProperty("CaloriesModifier").GetValue(btObject, null);

            return BaseCaloriesPerGram * ftModifier * btModifier * this.Weight;
        }
    }
}
