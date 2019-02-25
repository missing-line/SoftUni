namespace _7.EqualityLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            HashSet<Person> hashPerson = new HashSet<Person>();
            SortedSet<Person> sortedPerson = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arra = Console.ReadLine().Split().ToArray();

                string name = arra[0];
                int age = int.Parse(arra[1]);

                Person person = new Person(name, age);

                hashPerson.Add(person);
                sortedPerson.Add(person);

            }

            Console.WriteLine(hashPerson.Count);
            Console.WriteLine(sortedPerson.Count);
        }
    }
}
