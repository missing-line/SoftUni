namespace Oldest_Family_Member
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine().Split().ToArray();
                string name = person[0];
                int age = int.Parse(person[1]);
                Person currentPerson = new Person(name, age);
                family.AddMember(currentPerson);
            }

            Person oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
