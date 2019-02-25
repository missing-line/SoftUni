namespace OpinionPoll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] currPerson = Console.ReadLine()
                    .Split()
                    .ToArray();
                string name = currPerson[0];
                int age = int.Parse(currPerson[1]);
                Person person = new Person(name, age);
                persons.Add(person);
            }

            GetOldest(persons);
        }

        private static void GetOldest(List<Person> persons)
        {
            Console.WriteLine(string.Join(Environment.NewLine, persons
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .Select(p => $"{p.Name} - {p.Age}")));
        }
    }
}
