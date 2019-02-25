using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split("<:> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<Tuple<string, string, int>> dwarfs = new List<Tuple<string, string, int>>();
            //Dictionary<string, List<string>> colorHat = new Dictionary<string, List<string>>();
            
            while (string.Join(" ", line) != "Once upon a time")
            {
                string color = line[1];
                string name = line[0];
                int physics = int.Parse(line[2]);
                Tuple<string, string, int> tuple = new Tuple<string, string, int>(color,name,physics);
                if (dwarfs.Any(x=>x.Item1 == color) && dwarfs.Any(y=>y.Item2 == name) && dwarfs.Any(v=>v.Item3 < physics))
                {
                    var currTuple = dwarfs.First(x => x.Item1 == color && x.Item2 == name);
                    dwarfs.Remove(currTuple);                                    
                }               
                    dwarfs.Add(tuple);                              
                line = Console.ReadLine().Split("<:> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var dwalf in dwarfs.OrderByDescending(x=>x.Item3))
            {
                Console.WriteLine($"({dwalf.Item1}) {dwalf.Item2} <-> {dwalf.Item3}");
            }
        }
    }
    class Dwarf
    {
        public string Color { set; get; }
        public string Name { set; get; }
        public int Physics { set; get; }
    }
}
