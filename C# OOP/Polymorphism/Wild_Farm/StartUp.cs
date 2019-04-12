namespace Wild_Farm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wild_Farm.Models.Animals.Factory;
    using Wild_Farm.Models.Contracts;
    using Wild_Farm.Models.Food.Factory;

    public class StartUp
    {
        private static IAnimalFactory createAnimal = new AnimalFactory();
        private static IFoodFactory createFood = new FoodFactory();
        public static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>(); 

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] currAnimal = input
                    .Split()
                    .ToArray();               
               
                try
                {
                    IAnimal animal = createAnimal.CreateAnimal(currAnimal);

                    animals.Add(animal);
                    Console.WriteLine(animal.Sound());

                    string[] dataFood = Console.ReadLine()
                   .Split()
                   .ToArray();

                    IFood food = createFood.CreateFood(dataFood);
                 
                    animal.Eating(food);

                }
                catch (Exception ms)
                {

                    Console.WriteLine(ms.Message);
                }
                
            }

            animals.ForEach(x => Console.WriteLine(x));
        }
    }
}
