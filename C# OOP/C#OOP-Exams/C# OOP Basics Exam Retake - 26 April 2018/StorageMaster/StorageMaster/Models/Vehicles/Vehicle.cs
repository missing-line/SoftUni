namespace StorageMaster.Models.Vehicles
{
    using StorageMaster.Models.Intefaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Vehicle : IVehicle
    {
        private int capacity;
        private List<Product> trunk;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;           
            this.trunk = new List<Product>();                  
        }

        public int Capacity { get; }

        public IReadOnlyCollection<Product> Trunk => this.trunk.AsReadOnly(); //

        public bool IsFull => this.trunk.Sum(x => x.Weight) >= this.Capacity;


        public bool IsEmpty => this.Trunk.Count == 0;          

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left");
            }

            Product protuct = this.trunk[this.trunk.Count - 1];

            this.trunk.RemoveAt(this.trunk.Count - 1);

            return protuct;
        }
    }
}
