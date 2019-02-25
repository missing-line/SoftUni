namespace _4._Snowwhite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] line = Console.ReadLine()
                .Split("<:> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, int> dwarfs = new Dictionary<string, int>();

            while (string.Join(" ", line) != "Once upon a time")
            {
                string dwarf = $"({line[1]}) {line[0]}";
                int physics = int.Parse(line[2]);

                if (!dwarfs.ContainsKey(dwarf))
                {
                    dwarfs.Add(dwarf, physics);
                }
                else if (dwarfs.ContainsKey(dwarf) && dwarfs[dwarf] < physics)
                {
                    dwarfs[dwarf] = physics;
                }

                line = Console.ReadLine().Split("<:> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var dwarf in dwarfs.OrderByDescending(x => x.Value).ThenByDescending(l => dwarfs.Where(c => c.Key[1] == l.Key[1]).Count()))
            {
                Console.WriteLine($"{dwarf.Key} <-> {dwarf.Value}");
            }
        }
    }
}
