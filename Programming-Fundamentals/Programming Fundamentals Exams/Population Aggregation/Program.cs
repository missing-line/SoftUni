using System;
using System.Collections.Generic;
using System.Linq;

namespace Population_Aggregation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split("\\".ToArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            Dictionary<string, int> country = new Dictionary<string, int>();
            Dictionary<string, int> city = new Dictionary<string, int>();
            while (string.Join("",line) != "stop")
            {
                string cuur1 = FindString(line[0]);
                string cuur2 = FindString(line[1]);
                if (char.IsUpper(cuur1[0]))
                {
                    if (!country.ContainsKey(cuur1))
                    {
                        country.Add(cuur1, 1);
                    }
                    else if (country.ContainsKey(cuur1))
                    {
                        country[cuur1]++;
                    }
                    if (!city.ContainsKey(cuur2))
                    {
                        city.Add(cuur2, int.Parse(line[2]));
                    }
                    else if (city.ContainsKey(cuur2))
                    {
                        city[cuur2] = int.Parse(line[2]);
                    }
                }
                else
                {
                    if (!country.ContainsKey(cuur2))
                    {
                        country.Add(cuur2, 1);
                    }
                    else if (country.ContainsKey(cuur2))
                    {
                        country[cuur2]++;
                    }
                    if (!city.ContainsKey(cuur1))
                    {
                        city.Add(cuur1, int.Parse(line[2]));
                    }
                    else if (city.ContainsKey(cuur1))
                    {
                        city[cuur1] = int.Parse(line[2]);

                    }
                    
                }
                line = Console.ReadLine().Split("\\".ToArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            int count = 0;
            foreach (var countries in country.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{countries.Key} -> {countries.Value}");
            }
            foreach (var cities in city.OrderByDescending(x=>x.Value))
            {
                count++;
                Console.WriteLine($"{cities.Key} -> {cities.Value}");
                if (count == 3)
                {
                    return;
                }
            }
        }
        static string FindString( string curr)
        {
            string find = string.Empty;
            for (int i = 0; i < curr.Length; i++)
            {
                if (char.IsLetter(curr[i]))
                {
                    find += curr[i];
                }
            }
            return find;
        }
    }
}
