namespace _7._Order_by_Age
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public class User
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }
        }
        public static void Main(string[] args)
        {
            string[] line = Console.ReadLine()
                .Split()
                .ToArray();

            List<User> users = new List<User>();

            while (line[0] != "End")
            {
                users.Add(new User()
                {
                    Name = line[0],
                    ID = line[1],
                    Age = int.Parse(line[2])
                });

                line = Console.ReadLine().Split().ToArray();
            }

            foreach (var user in users.OrderBy(x => x.Age))
            {
                Console.WriteLine($"{user.Name} with ID: {user.ID} is {user.Age} years old.");
            }
        }
    }
}
