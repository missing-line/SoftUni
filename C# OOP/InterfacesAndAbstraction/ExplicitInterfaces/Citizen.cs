namespace ExplicitInterfaces
{
    using System;
    class Citizen : IPerson, IResident
    {
        public Citizen(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        public string GetName()
        {
            return  $"{this.Name}" + Environment.NewLine +
                    $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
