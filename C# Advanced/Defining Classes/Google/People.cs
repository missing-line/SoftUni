namespace Google
{
    using System.Collections.Generic;
    public class People
    {
        private string name;
        private Company company;
        private Car car;
        private List<Parents> parents;
        private List<Children> childrens;
        private List<Pokemon> pokemons;

        public People(string name)
        {
            this.Name = name;
            this.Company = company;
            this.Car = car;
            this.Parents = new List<Parents>();
            this.Childrens = new List<Children>();
            this.Pokemons = new List<Pokemon>();
        }

        public Company Company
        {
            get { return company; }
            set { company = value; }
        }
       
        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }


        public List<Children> Childrens
        {
            get { return childrens; }
            set { childrens = value; }
        }


        public List<Parents> Parents
        {
            get { return parents; }
            set { parents = value; }
        }


        public Car Car
        {
            get { return car; }
            set { car = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
       
    }
}
