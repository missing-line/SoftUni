using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Legendary_Farming_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            SortedDictionary<string, int> keyMats = new SortedDictionary<string, int>() { { "shards", 0 }, { "motes", 0 }, { "fragments", 0 } };
            SortedDictionary<string, int> Junk = new SortedDictionary<string, int>();
            string legendary = "";
            while (true)
            {
                string[] arr = input.Split().ToArray();
                int quantity = 0;
                string material = "";
                List<string> mats = new List<string>();
                List<int> qty = new List<int>();
                for (int i = 0; i < arr.Length; i += 2)
                {
                    quantity = int.Parse(arr[i]);
                    material = arr[i + 1];

                    if (material == "fragments" || material == "shards" || material == "motes")
                    {
                        keyMats[material] += quantity;
                        legendary = LegendaryCheck(keyMats);
                        if (legendary != "")
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (Junk.ContainsKey(material) == false) //nqma takuv material
                        {
                            Junk.Add(material, quantity);
                        }
                        else
                        {
                            Junk[material] += quantity;
                        }
                    }
                }
                if (legendary != "")
                {
                    break;
                }
                else
                {
                    input = Console.ReadLine().ToLower();
                }
            }
            if (legendary == "Shadowmourne")
            {
                keyMats["shards"] -= 250;
            }
            else if (legendary == "Dragonwrath")
            {
                keyMats["motes"] -= 250;
            }
            else if (legendary == "Valanyr")
            {
                keyMats["fragments"] -= 250;
            }         
            Console.WriteLine(legendary + " obtained!");

            foreach (var kvp in keyMats.OrderBy(x => -x.Value)) //MATS
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in Junk) //JUNK
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
        private static string LegendaryCheck(SortedDictionary<string, int> keyMats)
        {

            string legendary = "";
            foreach (var kvp in keyMats)
            {
                if (kvp.Value >= 250)
                {
                    if (kvp.Key == "shards")
                    {
                        legendary = "Shadowmourne";
                    }
                    else if (kvp.Key == "motes")
                    {
                        legendary = "Dragonwrath";
                    }
                    else
                    {
                        legendary = "Valanyr";
                    }
                }
            }
            return legendary;
        }
    }
}