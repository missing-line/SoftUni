namespace Hit_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int targetInfo = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, string>> info = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, int> sumOfKeyAndValue = new Dictionary<string, int>();

            string input;

            while ((input = Console.ReadLine()) != "end transmissions")
            {
                string[] arr = input
                    .Split("=;:".ToCharArray())
                    .ToArray();

                string name = arr[0];
                if (!info.ContainsKey(name))
                {
                    info.Add(name, new Dictionary<string, string>());
                    sumOfKeyAndValue.Add(name, 0);
                }

                for (int i = 1; i < arr.Length; i += 2)
                {
                    string key = arr[i];
                    string value = arr[i + 1];
                    
                    if (!info[name].ContainsKey(key))
                    {
                        info[name].Add(key, null);
                    }
                    info[name][key] = value;
                }
            }

            foreach (var person in info)
            {
                foreach (var inner in person.Value)
                {
                    sumOfKeyAndValue[person.Key] += inner.Key.Length + inner.Value.Length;
                }
            }

            string[] giveMeInfoForPerson = Console.ReadLine().Split(' ').ToArray();

            var finded = info
               .GroupBy(x => x.Key)
               .Where(x => x.Key == giveMeInfoForPerson[1])
               .ToDictionary(x => x.Key, y => y.ToDictionary(k => k.Key, v => v.Value));


            foreach (var kvp in finded)
            {
                Console.WriteLine($"Info on {kvp.Key}:");
                foreach (var inner in kvp.Value)
                {
                    foreach (var inner2 in inner.Value.OrderBy(x => x.Key))
                    {
                        Console.WriteLine($"---{inner2.Key}: {inner2.Value}");
                    }
                }
            }
            Console.WriteLine($"Info index: {sumOfKeyAndValue[giveMeInfoForPerson[1]]}");
            Console.WriteLine(sumOfKeyAndValue[giveMeInfoForPerson[1]] >= targetInfo ? $"Proceed" : $"Need {targetInfo - sumOfKeyAndValue[giveMeInfoForPerson[1]]} more info.");
        }
    }
}
