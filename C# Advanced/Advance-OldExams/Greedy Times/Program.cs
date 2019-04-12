namespace Greedy_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());

            string[] line = Console.ReadLine()
                .Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, Dictionary<string, long>> treasures = new Dictionary<string, Dictionary<string, long>>();
            treasures.Add("Gold", new Dictionary<string, long>());
            treasures["Gold"].Add("Gold", 0);
            treasures.Add("Gems", new Dictionary<string, long>());
            treasures.Add("Cash", new Dictionary<string, long>());
            for (int i = 0; i < line.Length; i += 2)
            {
                string typeTreasure = line[i].ToLower();
                long value = long.Parse(line[i + 1]);

                if (treasures["Gold"].Values.Sum() + treasures["Gems"].Values.Sum() + treasures["Cash"].Values.Sum() + value > capacity)
                {
                    continue;
                }
                if (typeTreasure == "gold")
                {
                    treasures["Gold"]["Gold"] += value;
                }
                else if (typeTreasure.Length > 3 && typeTreasure.EndsWith("gem"))
                {
                    if (treasures["Gems"].Values.Sum() + value <= treasures["Gold"].Values.Sum())
                    {
                        if (!treasures["Gems"].ContainsKey(line[i]))
                        {
                            treasures["Gems"].Add(line[i], 0);
                        }
                        treasures["Gems"][line[i]] += value;
                    }
                }
                else if (typeTreasure.Length == 3)
                {
                    if (treasures["Cash"].Values.Sum() + value <= treasures["Gems"].Values.Sum())
                    {
                        if (!treasures["Cash"].ContainsKey(line[i]))
                        {
                            treasures["Cash"].Add(line[i], 0);
                        }
                        treasures["Cash"][line[i]] += value;
                    }
                }
            }

            foreach (var treasure in treasures.Where(t => t.Value.Count > 0).OrderByDescending(x => x.Value.Sum(y => y.Value)))
            {
                Console.WriteLine($"<{treasure.Key}> ${treasure.Value.Sum(x=>x.Value)}");
                foreach (var inner in treasure.Value.OrderByDescending(k => k.Key).ThenBy(v => v.Value))
                {
                    Console.WriteLine($"##{inner.Key} - {inner.Value}");
                }

            }
        }
    }
}
