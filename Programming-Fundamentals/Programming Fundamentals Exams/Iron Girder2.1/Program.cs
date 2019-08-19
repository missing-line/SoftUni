using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iron_Girder2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, int> results1 = new Dictionary<string, int>();
            Dictionary<string, int> results2 = new Dictionary<string, int>();
            while (line != "Slide rule")
            {
                string[] curr = line.Split(":>".ToCharArray(),StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (!results1.ContainsKey(curr[0]))
                {
                    results1.Add(curr[0], 0);
                    results2.Add(curr[0], 0);
                }           
                if (curr[1].Trim('-') == "ambush")
                {
                    results1[curr[0]] = 0;
                    if (results2[curr[0]] > 0)
                    {
                        results2[curr[0]] -= int.Parse(curr[2]);
                    }
                    
                    line = Console.ReadLine();
                    continue;
                }               
                results2[curr[0]] += int.Parse(curr[2]);

                if (results1[curr[0]] == 0)
                {
                    results1[curr[0]] = int.Parse(curr[1].Trim('-'));
                }
                else if(results1[curr[0]] > int.Parse(curr[1].Trim('-')))
                {
                    results1[curr[0]] = int.Parse(curr[1].Trim('-'));
                }
                line = Console.ReadLine();
            }
            foreach (var bestTime in results1.OrderBy(x=>x.Value).ThenBy(y=>y.Key))
            {
                foreach (var town in results2)
                {
                    if (bestTime.Value > 0 && town.Value > 0 && bestTime.Key == town.Key)
                    {
                        Console.WriteLine($"{town.Key} -> Time: {bestTime.Value} -> Passengers: {town.Value}");
                    }
                }
            }
        }
    }
}
