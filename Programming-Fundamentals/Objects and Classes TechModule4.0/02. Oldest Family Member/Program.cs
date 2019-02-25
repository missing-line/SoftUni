namespace _02._Oldest_Family_Member
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public class Person
        {
            public string Name { set; get; }
            public int Age { set; get; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> family = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] currPerson = Console.ReadLine().Split().ToArray();
                Person curr = new Person();
                curr.Name = currPerson[0];
                curr.Age = int.Parse(currPerson[1]);
                family.Add(curr);
            }

            foreach (var person in family.OrderByDescending(x => x.Age))
            {
                Console.WriteLine($"{person.Name} {person.Age}");
                return;
            }
        }
    }
}
