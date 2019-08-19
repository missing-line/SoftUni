using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine()
                .Split(":>".ToCharArray());
            var track1 = new Dictionary<string, int>();
            var track2 = new Dictionary<string, int>();
            while (line[0].ToString() != "Slide rule")
            {
                //var curr = new Dictionary<int, int>();
                int curr = 0;
                string town = line[0];
                string check = line[1].Remove(line[1].Length - 1, 1);             
                int passangers = int.Parse(line[2]);
                if (check != "ambush")
                {
                    
                    int time = int.Parse(check);
                    curr = time;
                    if (!track1.ContainsKey(town))
                    {
                        track1.Add(town, time);
                        track2.Add(town, passangers);

                    }
                    else if (track1.ContainsKey(town))
                    {
                        if (track1[town] > curr && track1[town] > 0)
                        {
                            track1[town] = curr;
                        }
                        else if (track1[town] == 0)
                        {
                            track1[town] = curr;
                        }
                        track2[town] += passangers;
                    }
                }
                else if (check == "ambush")
                {
                    if (!track1.ContainsKey(town))
                    {
                        track1.Add(town, 0);
                        track2.Add(town, 0);

                    }
                    else
                    {
                        track1[town] = 0;
                        track2[town] -= passangers;
                    }                  
                }
                
                line = Console.ReadLine().Split(":>".ToCharArray());
            }
            foreach (var kvp1 in track1.OrderBy(x=>x.Value).ThenBy(x=>x.Key))
            {
                foreach (var kvp2 in track2)
                {
                    if (kvp1.Key == kvp2.Key && kvp1.Value >0 && kvp2.Value > 0)
                    {
                        Console.WriteLine($"{kvp1.Key} -> Time: {kvp1.Value} -> Passengers: {kvp2.Value}");
                    }
                }
            }
        }
    }
}

