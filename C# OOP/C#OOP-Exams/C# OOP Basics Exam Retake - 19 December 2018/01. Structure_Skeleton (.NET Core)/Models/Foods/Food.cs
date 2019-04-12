﻿namespace SoftUniRestaurant.Models.Foods.Contracts
{
    using System;
    public abstract class Food : IFood
    {
        private string name;
        private decimal price;
        private int servingSize;

        protected Food(string name, int servingSize, decimal price)
        {
            this.Name = name;         
            this.Price = price;
            this.ServingSize = servingSize;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Name cannot be null or white space!");
                }

                this.name = value;
            }
        }
        public  int ServingSize 
        {
            get {return this.servingSize; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Serving size cannot be less or equal to zero");
                }
                this.servingSize = value;
            }
        }
        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.ServingSize}g - {this.Price:f2}";
        }
    }
}
