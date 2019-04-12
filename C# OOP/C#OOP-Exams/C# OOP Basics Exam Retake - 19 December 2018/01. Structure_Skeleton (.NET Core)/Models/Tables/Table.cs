namespace SoftUniRestaurant.Models.Tables
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Table : ITable
    {
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;
     
        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.IsReserved = false;
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();

        }

        public int TableNumber { get; private set; }
        public virtual int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                this.numberOfPeople = value;
            }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                this.capacity = value;
            }
        }
        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }


        public decimal Price => this.PricePerPerson * this.NumberOfPeople;

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }
        public decimal GetBill()
        {
            return this.drinkOrders.Sum(d => d.Price) + this.foodOrders.Sum(f => f.Price) + this.Price;
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");
            if (this.foodOrders.Count == 0)
            {
                sb.AppendLine("Food orders: None");
            }
            else
            {

                sb.AppendLine($"Food orders: {this.foodOrders.Count}");
                sb.AppendLine($"{string.Join(Environment.NewLine, this.foodOrders)}");
            }
            if (this.drinkOrders.Count == 0)
            {
                sb.AppendLine($"Drink orders: None");
            }
            else
            {

                sb.AppendLine($"Drink orders: {this.drinkOrders.Count}");
                sb.AppendLine($"{string.Join(Environment.NewLine, this.drinkOrders)}");
            }
            return sb.ToString().TrimEnd();

        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();

        }
    }
}
