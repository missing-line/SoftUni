namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> topping;

        public Pizza(string name)
        {
            this.Name = name;
            this.Dough = dough;
            this.Toppings = new List<Topping>();
        }

        public List<Topping> Toppings
        {
            get { return this.topping; }
            set
            {
                this.topping = value;
            }
        }

        public Dough Dough
        {
            get { return this.dough; }
            set { this.dough = value; }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.topping.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.topping.Add(topping);
        }

        public double Calories()
        {
            double sum = 0;
            sum += this.dough.Calories();
            this.topping.ForEach(t => sum += t.Calories());

            return sum;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Calories():f2} Calories.";
        }   
    }
}
