namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Products> products = new List<Products>();
            try
            {
                string[] personsArgs = Console.ReadLine()
                    .Split("=;".ToCharArray())
                    .ToArray();

                for (int i = 0; i < personsArgs.Length - 1; i += 2)
                {
                    string name = personsArgs[i];
                    int money = int.Parse(personsArgs[i + 1]);
                    persons.Add(new Person(name, money, new List<Products>()));
                }

                string[] productsArgs = Console.ReadLine()
                    .Split("=;".ToCharArray())
                    .ToArray();

                for (int i = 0; i < productsArgs.Length - 1; i += 2)
                {
                    string name = productsArgs[i];
                    int cost = int.Parse(productsArgs[i + 1]);
                    products.Add(new Products(name, cost));
                }
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] arr = input.Split().ToArray();

                string namePerson = arr[0];
                string nameProduct = arr[1];

                if (persons.Any(x => x.Name == namePerson) && products.Any(x => x.Name == nameProduct))
                {
                    Person extPerson = persons.FirstOrDefault(x => x.Name == namePerson);
                    Products extProduct = products.FirstOrDefault(x=>x.Name == nameProduct);
                    if (extPerson.Money - extProduct.Cost >= 0 )
                    {
                        extPerson.Money -= extProduct.Cost;
                        extPerson.Bag.Add(extProduct);
                        Console.WriteLine($"{namePerson} bought {nameProduct}");
                    }
                    else
                    {
                        Console.WriteLine($"{namePerson} can't afford {nameProduct}");
                    }
                }
            }

            persons.ForEach(x => Console.WriteLine
            (
                x.Bag.Count == 0
                ? $"{x.Name} - Nothing bought"
                : $"{x}"
            ));
        }
    }
}
