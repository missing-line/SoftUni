namespace Cities_by_Continent_and_Country
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> map = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string continent = arr[0];
                string country = arr[1];
                string city = arr[2];

                if (!map.ContainsKey(continent))
                {
                    map.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!map[continent].ContainsKey(country))
                {
                    map[continent].Add(country, new List<string>());
                }
                map[continent][country].Add(city);
            }

            foreach (var kvp in map)
            {
                Console.WriteLine($"{kvp.Key}:");
                foreach (var inner in kvp.Value)
                {
                    Console.WriteLine($"  {inner.Key} -> {string.Join(", ", inner.Value)}");
                }
            }
        }
    }
}
