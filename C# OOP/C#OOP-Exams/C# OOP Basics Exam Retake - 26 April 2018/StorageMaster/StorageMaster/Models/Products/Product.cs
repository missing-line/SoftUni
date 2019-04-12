namespace StorageMaster.Models
{
    using StorageMaster.Models.Intefaces;
    using System;

    public abstract class Product : IProduct
    {
        private double price;
        private double weight;
        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get { return this.price; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                this.price = value ;
            }
        }

        public double Weight { get; private set; }
        public Product Where { get; internal set; }
    }
}
