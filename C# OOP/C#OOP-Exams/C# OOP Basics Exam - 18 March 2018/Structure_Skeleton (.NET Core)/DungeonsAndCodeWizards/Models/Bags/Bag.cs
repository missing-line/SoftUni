namespace DungeonsAndCodeWizards.Models.Bags
{
    using DungeonsAndCodeWizards.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Bag : IBag
    {
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; }


        public double Load => this.items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items
            => this.items;

        public void AddItem(Item item)
        {
            if (item.Weight + this.Load > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            Item item = this.items.FirstOrDefault(x=>x.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.items.Remove(item);

            return item;
        }
    }
}
