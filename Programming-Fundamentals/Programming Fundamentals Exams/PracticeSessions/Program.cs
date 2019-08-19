using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeSessions
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
                    .Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = arr[0].TrimEnd('-');

                switch (command)
                {
                    case "Add":
                        Add(dic, arr[1], arr[2]);
                        break;
                    case "Close":
                        Close(dic, arr[1]);
                        break;
                    case "Move":
                        Move(dic, arr[1], arr[2], arr[3]);
                        break;
                    default:
                        break;
                }
            }

            Print(dic);
        }
        private static void Add(Dictionary<string, List<string>> dic, string road, string racer)
        {
            if (!dic.ContainsKey(road))
            {
                dic.Add(road, new List<string>());
            }

            dic[road].Add(racer);   
        }

        private static void Print(Dictionary<string, List<string>> dic)
        {
            Console.WriteLine("Practice sessions:");

            foreach (var store in dic.OrderByDescending(x => x.Value.Count).ThenBy(k => k.Key))
            {
                Console.WriteLine($"{store.Key}");

                foreach (var inner in store.Value)
                {
                    Console.WriteLine($"++{inner}");
                }
            }
        }

        private static void Close(Dictionary<string, List<string>> dic, string road)
        {
            if (dic.ContainsKey(road))
            {
                dic.Remove(road);
            }
        }

        private static void Move(Dictionary<string, List<string>> dic, string road,string racer, string nextRoad)
        {
            if (dic.ContainsKey(road) && dic.ContainsKey(nextRoad) && dic[road].Contains(racer))
            {
                dic[road].Remove(racer);

                dic[nextRoad].Add(racer);
            }
        }
    }
}
