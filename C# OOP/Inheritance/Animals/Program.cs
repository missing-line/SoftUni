namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                string type = input;

                string[] arr = Console.ReadLine()
                    .Split()
                    .ToArray();
                try
                {
                    switch (type)
                    {
                        case "Cat":
                            animals.Add(new Cat(arr[0], int.Parse(arr[1]), arr[2]));
                            break;
                        case "Dog":
                            animals.Add(new Dog(arr[0], int.Parse(arr[1]), arr[2]));
                            break;
                        case "Frog":
                            animals.Add(new Frog(arr[0], int.Parse(arr[1]), arr[2]));
                            break;
                        case "Kitten":
                            animals.Add(new Kitten(arr[0], int.Parse(arr[1])));
                            break;
                        case "Tomcat":
                            animals.Add(new Tomcat(arr[0], int.Parse(arr[1])));
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }               
            }

            animals.ForEach(Console.WriteLine);
        }
    }
}
