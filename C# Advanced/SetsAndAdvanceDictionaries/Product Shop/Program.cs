namespace Product_Shop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> products = new SortedDictionary<string, Dictionary<string, double>>();
            string input;

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] arr = input
                    .Split(", ")
                    .ToArray();

                string shopName = arr[0];
                string product = arr[1];
                double price = double.Parse(arr[arr.Length - 1]);

                if (!products.ContainsKey(shopName))
                {
                    products.Add(shopName, new Dictionary<string, double>());
                    products[shopName].Add(product, price);
                }
                else if (products.ContainsKey(shopName) && !products[shopName].ContainsKey(product))
                {
                    products[shopName].Add(product, price);
                }
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key}->");
                foreach (var inner in product.Value)
                {
                    Console.WriteLine($"Product: {inner.Key}, Price: {inner.Value}");
                }
            }
        }
    }
}
