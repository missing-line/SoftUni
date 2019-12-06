namespace DP_Demo.Composite
{
    using DP_Demo.Composite.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Gift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;
        public Gift(string name, decimal price)
            : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
            => this.gifts.Add(gift);


        public override decimal CalculaTotalPrice()
            => this.gifts.Sum(s => s.CalculaTotalPrice());


        public void Remove(GiftBase gift)
            => this.gifts.Remove(gift);

    }
}
