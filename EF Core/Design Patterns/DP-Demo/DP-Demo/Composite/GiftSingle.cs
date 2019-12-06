using System;

namespace DP_Demo.Composite
{
    public class GiftSingle : GiftBase
    {
        public GiftSingle(string name, decimal price) 
            : base(name, price)  { }

        public override decimal CalculaTotalPrice()
        {
            Console.WriteLine($"{this.name} with price {this.price}");

            return this.price;
        }
    }
}
