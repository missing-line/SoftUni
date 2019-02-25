namespace Family_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static List<Person> persons;
        static List<string> realtions;
        public static void Main(string[] args)
        {
            string personInfo = Console.ReadLine();

            persons = new List<Person>();
            realtions = new List<string>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                if (!input.Contains("-"))
                {
                    AddMemeber(input);
                    continue;
                }

                realtions.Add(input);
            }

            foreach (var member in realtions)
            {
                string[] arr = member
                    .Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Person parent = GetPerson(arr[0]);
                Person child = GetPerson(arr[1]);

                if (!parent.Childrens.Contains(child))
                {
                    parent.Childrens.Add(child);
                }
                if (!child.Parents.Contains(parent))
                {
                    child.Parents.Add(parent);
                }                 
            }

            Print(personInfo);
        }

        private static void Print(string personInfo)
        {
            Person person = GetPerson(personInfo);

            Console.WriteLine($"{person.Name} {person.Birth}");

            Console.WriteLine($"Parents:");
            foreach (var parent in person.Parents)
            {
                Console.WriteLine($"{parent.Name} {parent.Birth}");
            }
            Console.WriteLine("Children:");
            foreach (var child in person.Childrens)
            {
                Console.WriteLine($"{child.Name} {child.Birth}");
            }
        }     
        private static Person GetPerson(string input)
        {
            if (input.Contains("/"))
            {
                return persons.FirstOrDefault(x => x.Birth == input);
            }

            return persons.FirstOrDefault(x => x.Name == input);
        }

        private static void AddMemeber(string input)
        {
            string[] info = input.Split();
            string name = $"{info[0]} {info[1]}";
            string date = info[2];

            Person person = new Person(name, date);

            persons.Add(person);
        }
    }
}
