namespace ShoppingSpree
{
    using System;
    public class Products
    {
        private string name;
        private int cost;

        public Products(string name, int cost)
        {
            this.Cost = cost;
            this.Name = name;
        }

        public int Cost
        {
            get { return this.cost; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.cost = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public override string ToString()
        {
            return $"{this.name}";
        }
    }
}
