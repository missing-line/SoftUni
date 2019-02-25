namespace _5.ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string[] input = Console.ReadLine()
                 .Split()
                 .ToArray();

            while (string.Join("", input) != "END")
            {
                string name = input[0];
                int age = int.Parse(input[1]);
                string town = input[2];

                persons.Add(new Person(name,age,town));

                input = Console.ReadLine()
                 .Split()
                 .ToArray();
            }

            int n = int.Parse(Console.ReadLine());

            Person curr = persons[n - 1];

            int equalPersons = 0;
            int notEqual = 0;

            for (int i = 0; i < persons.Count; i++)
            {
                if (curr.CompareTo(persons[i]) == 0)
                {
                    equalPersons++;
                }
                else
                {
                    notEqual++;
                }
            }

            if (equalPersons == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPersons} {notEqual} {persons.Count}");
            }
        }
    }
}
