namespace DP_Demo.Template
{
    using System;
    public class TwelveGrain : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking 12 Gain Bread (25 minutes).");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Ingredinets for 12 Gain Bread.");
        }
    }
}
