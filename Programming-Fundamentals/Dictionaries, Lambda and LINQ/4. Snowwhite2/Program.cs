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

            List<Dwarf> dwarfs = new List<Dwarf>();

            while (string.Join(" ", line) != "Once upon a time")
            {
                string color = line[1];
                string name = line[0];
                int physics = int.Parse(line[2]);

                if (dwarfs.Any(x => x.Color == color && x.Name == name))
                {
                    Dwarf currD = dwarfs.First(x => x.Color == color && x.Name == name);
                    if (currD.Physics < physics)
                    {
                        currD.Physics = physics;
                    }
                }
                else
                {
                    dwarfs.Add(new Dwarf(color, name, physics));
                }

                line = Console.ReadLine().Split("<:> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var dwarf in dwarfs.OrderByDescending(x => x.Physics).ThenByDescending(c => dwarfs.Where(j => j.Color == c.Color).Count()))
            {
                Console.WriteLine($"({dwarf.Color}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
    }
    public class Dwarf
    {
        public string Color { set; get; }
        public string Name { set; get; }
        public int Physics { set; get; }
        public Dwarf(string color, string name, int physics)
        {
            this.Color = color;

            this.Name = name;

            this.Physics = physics;
        }
    }
}
