namespace DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dragons = new Dictionary<string, Dictionary<string, int[]>>();

            for (int i = 0; i < n; i++)
            {
                string[] dragon = Console.ReadLine().Split().ToArray();
                string type = dragon[0];
                string name = dragon[1];
                int dmg = 0;
                int health = 0;
                int armor = 0;

                if (dragon[2] == "null")
                    dmg = 45;
                else
                    dmg = int.Parse(dragon[2]);
                if (dragon[3] == "null")
                    health = 250;
                else
                    health = int.Parse(dragon[3]);
                if (dragon[4] == "null")
                    armor = 10;
                else
                    armor = int.Parse(dragon[4]);

                var currentDragon = new Dictionary<string, int[]>();

                if (!dragons.ContainsKey(type))
                {
                    currentDragon.Add(name, new int[] { dmg, health, armor });
                    dragons.Add(type, currentDragon);
                }
                else
                {
                    if (!dragons[type].ContainsKey(name))
                    {
                        dragons[type].Add(name, new int[] { dmg, health, armor });
                    }
                    else
                    {
                        dragons[type][name] = new int[] { dmg, health, armor };
                    }
                }
            }

            foreach (var type in dragons)
            {
                Console.WriteLine($"{type.Key}::({(type.Value.Select(x => x.Value[0]).Average()):f2}/{(type.Value.Select(x => x.Value[1]).Average()):f2}/{(type.Value.Select(x => x.Value[2]).Average()):f2})");
                foreach (var inner in type.Value.OrderBy(l => l.Key))
                {
                    Console.WriteLine($"-{inner.Key} -> damage: {inner.Value[0]}, health: {inner.Value[1]}, armor: {inner.Value[2]}");
                }
            }
        }
    }
}


