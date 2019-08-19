using System;
using System.Collections.Generic;
using System.Linq;

namespace On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var arr = input
                    .Split(">".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = arr[0].TrimEnd('-');

                switch (command)
                {
                    case "Add":
                        Add(dic, arr[1].TrimEnd('-'), arr[2]);
                        break;
                    case "Remove":
                        Remove(dic, arr[1].Trim('-'));
                        break;
                    default:
                        break;
                }
            }

            Print(dic);
        }

        private static void Print(Dictionary<string, List<string>> dic)
        {
            Console.WriteLine("Stores list:");

            foreach (var store in dic.OrderByDescending(x => x.Value.Count).ThenByDescending(k => k.Key))
            {
                Console.WriteLine($"{store.Key}");
               
                foreach (var inner in store.Value)
                {
                    Console.WriteLine($"<<{inner}>>");
                }
            }
        }

        private static void Add(Dictionary<string, List<string>> dic, string store, string items)
        {
            if (!dic.ContainsKey(store))
            {
                dic.Add(store, new List<string>());
            }

            var arr = items
                    .Split(',');

            foreach (var item in arr)
            {
                dic[store].Add(item);
            }
        }

        private static void Remove(Dictionary<string, List<string>> dic, string store)
        {
            if (dic.ContainsKey(store))
            {
                dic.Remove(store);
            }
        }
    }
}
