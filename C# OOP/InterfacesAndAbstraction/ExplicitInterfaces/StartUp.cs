namespace ExplicitInterfaces
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                 .Split()
                 .ToArray();

            while (input[0] != "End")
            {
                string name = input[0];
                string country = input[1];
                int age = int.Parse(input[2]);

                Citizen citizen = new Citizen(name,age,country);
                Console.WriteLine(citizen.GetName());

                input = Console.ReadLine()
                 .Split()
                 .ToArray();
            }
        }
    }
}
