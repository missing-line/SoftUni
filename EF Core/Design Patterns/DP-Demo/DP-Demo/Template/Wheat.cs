namespace DP_Demo.Template
{
    using System;
    public class Wheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking Wheat Bread (15 minutes).");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Ingredinets for Wheat Bread.");
        }
    }
}
