namespace FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine()
                    .Split()
                    .ToArray();

                if (arr.Length == 3)
                {
                    buyers.Add(
                        new Rebel(arr[0],
                        int.Parse(arr[1]),
                        arr[2]
                        ));
                }
                else
                {
                    buyers.Add(
                        new Citizen(arr[0],
                        int.Parse(arr[1]),
                        arr[2],
                        arr[3]
                        ));
                }
            }

            string name;

            while ((name = Console.ReadLine()) != "End")
            {
                var buyer = buyers.SingleOrDefault(x => x.Name == name);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(x=>x.Food));
        }
    }
}
