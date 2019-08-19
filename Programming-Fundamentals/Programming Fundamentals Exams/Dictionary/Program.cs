using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        private static Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
        static void Main(string[] args)
        {
            
            var firstLineInput = Console.ReadLine()
                .Split(" | ")
                .ToList();

            var secondLineInput = Console.ReadLine()
                 .Split(" | ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                 .ToList();


            foreach (var sentence in firstLineInput)
            {
                var arr = sentence
                    .Split(": ")
                    .ToArray();

                string word = arr[0];
                string difinition = arr[1];

                if (!dic.ContainsKey(word))
                {
                    dic.Add(word, new List<string>());
                }
                dic[word].Add(difinition);
            }

            string command = Console.ReadLine();

            if (command == "End")
            {
                foreach (var key in secondLineInput)
                {
                    if (dic.ContainsKey(key))
                    {
                        Console.WriteLine($"{key}");
                        foreach (var value in dic[key].OrderByDescending(x => x.Count()))
                        {
                            Console.WriteLine($" -{value}");
                        }
                    }
                }
                return;
            }

            Console.WriteLine(string.Join(" ", dic.Keys.OrderBy(x => x)));

        }
    }
}

