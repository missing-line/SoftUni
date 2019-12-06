namespace DP_Demo.Prototype
{
    using System;
    public class Sandwich : SandwichProtoType
    {
        private string meat;
        private string bread;
        private string cheese;
        private string veggies;

        public Sandwich(string meat, string bread, string cheese, string veggies)
        {
            this.meat = meat;
            this.bread = bread;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        public override SandwichProtoType Clone()
        {
            Console.WriteLine($"Cloning sandwich with ingredients: {GetIngredientList()}");
            return MemberwiseClone() as SandwichProtoType;
        }

        private string GetIngredientList()
        {
            return $"{this.bread} {this.meat} {this.cheese} {this.veggies}";
        }
    }
}
