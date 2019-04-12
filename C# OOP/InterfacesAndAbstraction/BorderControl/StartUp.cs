namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<City> city = new List<City>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] arr = input
                    .Split()
                    .ToArray();

                if (arr.Length == 3)
                {
                    city.Add(new City(arr[0], int.Parse(arr[1]), arr[2]));
                }
                else
                {
                    city.Add(new City(arr[0], arr[1]));
                }
            }

            string findId = Console.ReadLine();

            var finded = city.Where(x => x.Id.EndsWith(findId));

            foreach (var i in finded)
            {
                Console.WriteLine(i.Id);
            }
        }
    }
}
