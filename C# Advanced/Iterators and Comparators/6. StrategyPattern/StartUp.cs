namespace _6._StrategyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SortedSet<Person> setByName = new SortedSet<Person>(new PersonNameComparer());
            SortedSet<Person> setByAge = new SortedSet<Person>(new PersonAgeComparer());

            int line = int.Parse(Console.ReadLine());

            for (int i = 0; i < line; i++)
            {
                string[] arra = Console.ReadLine().Split().ToArray();

                string name = arra[0];
                int age = int.Parse(arra[1]);

                Person person = new Person(name, age);

                setByName.Add(person);
                setByAge.Add(person);
            }

            foreach (var person in setByName)
            {
                Console.WriteLine(person);
            }
            foreach (var person in setByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
