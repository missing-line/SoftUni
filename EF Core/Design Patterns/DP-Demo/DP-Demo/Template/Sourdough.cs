namespace DP_Demo.Template
{
    using System;
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking Sourdough Bread (150 minutes).");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Ingredinets for Sourdough Bread.");
        }
    }
}
