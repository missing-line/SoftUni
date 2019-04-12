namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    public class Person
    {
        private string name;
        private int money;
        private List<Products> bag;

        public Person(string name, int money, List<Products> bag)
        {
            this.Money = money;
            this.Name = name;
            this.Bag = new List<Products>();
        }

        public List<Products> Bag
        {
            get { return this.bag; }
            set
            {
                this.bag = value;
            }
        }


        public int Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public override string ToString()
        {
            return $"{this.name} - {string.Join(", ", this.bag)}";
        }

    }
}
