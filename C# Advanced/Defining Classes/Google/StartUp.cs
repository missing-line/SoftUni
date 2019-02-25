namespace Google
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<People> peoples = new List<People>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] arr = input.Split().ToArray();

                string name = arr[0];
                if (peoples.All(x => x.Name != name))
                {
                    peoples.Add(new People(name));
                }

                if (arr[1] == "company")
                {
                    string nameCompany = arr[2];
                    string departmnet = arr[3];
                    double salary = double.Parse(arr[4]);
                    Company company = new Company(nameCompany, departmnet, salary);
                    People person = peoples.FirstOrDefault(x => x.Name == name);
                    person.Company = company;
                }
                else if (arr[1] == "car")
                {
                    string model = arr[2];
                    double speed = double.Parse(arr[3]);
                    Car car = new Car(model, speed);
                    People person = peoples.FirstOrDefault(x => x.Name == name);
                    person.Car = car;
                }
                else if (arr[1] == "children")
                {
                    string nameChildren = arr[2];
                    string birthDay = arr[3];
                    Children children = new Children(nameChildren, birthDay);
                    People person = peoples.FirstOrDefault(x => x.Name == name);
                    person.Childrens.Add(children);
                }
                else if (arr[1] == "parents")
                {
                    string nameParent = arr[2];
                    string birthDay = arr[3];
                    Parents parent = new Parents(nameParent, birthDay);
                    People person = peoples.FirstOrDefault(x => x.Name == name);
                    person.Parents.Add(parent);

                }
                else if (arr[1] == "pokemon")
                {
                    string namePokemon = arr[2];
                    string type = arr[3];
                    Pokemon pokemon = new Pokemon(namePokemon, type);
                    People person = peoples.FirstOrDefault(x => x.Name == name);                    
                    person.Pokemons.Add(pokemon);
                }
            }
            string findPerson = Console.ReadLine();

            People pers = peoples.First(x => x.Name == findPerson);
            Console.WriteLine(pers.Name);
            Console.WriteLine("Company:");
            if (pers.Company != null)
            {
                Console.WriteLine(pers.Company);
            }
            Console.WriteLine("Car:");
            if (pers.Car != null)
            {
                Console.WriteLine(pers.Car);
            }
            Console.WriteLine("Pokemon:");
            if (pers.Pokemons != null)
            {
                pers.Pokemons.ForEach(p => Console.WriteLine(p));
            }
            Console.WriteLine("Parents:");
            if (pers.Parents != null)
            {
                pers.Parents.ForEach(p => Console.WriteLine(p));
            }
            Console.WriteLine("Children:");
            if (pers.Childrens != null)
            {
                pers.Childrens.ForEach(c => Console.WriteLine(c));
            }
        }
    }
}
