namespace _3._Legendary_Farming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> materials = Console.ReadLine().ToLower().Split().ToList();
            Dictionary<string, int> requires = new Dictionary<string, int>();

            requires.Add("motes", 0);
            requires.Add("shards", 0);
            requires.Add("fragments", 0);

            Dictionary<string, int> junk = new Dictionary<string, int>();

            bool winner = false;

            while (true)
            {
                for (int i = 0; i < materials.Count; i += 2)
                {
                    string material = materials[i + 1];
                    int quantity = int.Parse(materials[i]);

                    if (material == "motes" ||
                        material == "shards" ||
                        material == "fragments")
                    {
                        requires[material] += quantity;
                    }
                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk.Add(material, quantity);
                        }
                        else
                        {
                            junk[material] += quantity;
                        }
                    }
                    if (requires.Any(x => x.Value >= 250))
                    {
                        winner = true;
                        break;
                    }
                }
                if (winner)
                {
                    if (requires["motes"] >= 250)
                    {
                        Console.WriteLine("Dragonwrath obtained!");
                        requires["motes"] -= 250;
                    }
                    else if (requires["shards"] >= 250)
                    {
                        Console.WriteLine("Shadowmourne obtained!");
                        requires["shards"] -= 250;
                    }
                    else if (requires["fragments"] >= 250)
                    {
                        Console.WriteLine("Valanyr obtained!");
                        requires["fragments"] -= 250;
                    }
                    foreach (var currReq in requires.OrderByDescending(x => x.Value).ThenBy(l => l.Key))
                    {
                        Console.WriteLine($"{currReq.Key}: {currReq.Value}");
                    }
                    foreach (var currJunk in junk.OrderBy(y => y.Key))
                    {
                        Console.WriteLine($"{currJunk.Key}: {currJunk.Value}");
                    }
                    return;
                }

                materials = Console.ReadLine().ToLower().Split().ToList();
            }
        }
    }
}
