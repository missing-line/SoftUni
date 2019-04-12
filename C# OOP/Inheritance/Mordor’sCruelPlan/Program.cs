namespace Mordor_sCruelPlan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            List<Food> foodFactory = new List<Food>();

            for (int i = 0; i < input.Length; i++)
            {
                foodFactory.Add(new Food(input[i]));
            }

            MoodFactory moodFactory = new MoodFactory(foodFactory);
            Console.WriteLine(moodFactory);
        }
    }
}
