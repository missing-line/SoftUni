using System;
using System.Collections.Generic;
using System.Linq;

namespace Anonymous_Cache
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split("->| ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var cache = new Dictionary<string, long>();

            var cacheUsers = new Dictionary<string, List<string>>();

            List<string> setData = new List<string>();

            while (string.Join(" ", line) != "thetinggoesskrra")
            {
                if (line.Count == 1)
                {
                    string dataToSet = line[0];
                    if (!setData.Contains(dataToSet))
                    {
                        setData.Add(dataToSet);
                    }
                }
                else
                {
                    string dataKey = line[0];
                    long dataSize = int.Parse(line[1]);
                    string dataToSet = line[2];

                    if (!cache.ContainsKey(dataToSet))
                    {
                        cache.Add(dataToSet, dataSize);
                        cacheUsers.Add(dataToSet, new List<string>() { dataKey });
                    }
                    else if (cache.ContainsKey(dataToSet))
                    {
                        cache[dataToSet] += dataSize;
                        cacheUsers[dataToSet].Add(dataKey);
                    }
                }
                line = Console.ReadLine()
                .Split("->| ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            }
            foreach (var caches in cache.OrderByDescending(z => z.Value))
            {
                foreach (var users in cacheUsers)
                {
                    foreach (var date in setData)
                    {
                        if (caches.Key == date && caches.Key == users.Key)
                        {                           
                            Console.WriteLine($"Data Set: {caches.Key}, Total Size: {caches.Value}");
                            foreach (var user in users.Value)
                            {
                                Console.WriteLine($"$.{user}");
                            }
                            return;
                        }
                    }
                }
            }
        }
    }
}
