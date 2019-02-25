namespace Wardrobe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine()
                        .Split(">")
                        .ToArray();

                string color = arr[0].Trim(" -".ToCharArray());
                List<string> items = arr.Skip(1).ToList();
                List<string> item = items[0].Split(",").ToList();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < item.Count; j++)
                {
                    item[j] = item[j].Trim();
                    if (!wardrobe[color].ContainsKey(item[j]))
                    {
                        wardrobe[color].Add(item[j], 0);
                    }
                    wardrobe[color][item[j]]++;
                }
            }

            string[] found = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string foundColor = found[0];
            string foundItem = found[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var inner in item.Value)
                {
                    if (foundColor == item.Key && foundItem == inner.Key)
                    {
                        Console.WriteLine($"* {inner.Key} - {inner.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {inner.Key} - {inner.Value}");
                    }
                }
            }
        }
    }
}
