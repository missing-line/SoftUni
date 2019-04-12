namespace Cubic_Assault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> regions = new Dictionary<string, Dictionary<string, long>>();

            string input;

            while ((input = Console.ReadLine()) != "Count em all")
            {
                string[] arr = input
                    .Split(new string[] { " -> " },StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string region = arr[0];
                string type = arr[1];
                int meteors = int.Parse(arr[2]);

                if (!regions.ContainsKey(region))
                {
                    regions.Add(region, new Dictionary<string, long>());

                    regions[region].Add("Black", 0);
                    regions[region].Add("Green", 0);
                    regions[region].Add("Red", 0);
                }
                regions[region][type] += meteors;

                if (regions[region]["Green"] >= 1000000)
                {
                    long value = regions[region]["Green"] / 1000000;
                    regions[region]["Green"] %= 1000000;
                    regions[region]["Red"] += value;
                }
                if (regions[region]["Red"] >= 1000000)
                {
                    long value = regions[region]["Red"] / 1000000;
                    regions[region]["Red"] %= 1000000;
                    regions[region]["Black"] += value;
                }
            }

            foreach (var region in regions.OrderByDescending(x => x.Value["Black"]).ThenBy(x => x.Key.Length).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{region.Key}");
                foreach (var inner in region.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"-> {inner.Key} : {inner.Value}");
                }
            }
        }
    }
}
