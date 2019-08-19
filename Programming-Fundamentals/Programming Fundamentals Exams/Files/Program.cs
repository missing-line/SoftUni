using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            //100 / 100
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, long>> print = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split('\\');

                string root = line[0];

                string[] ext = line[line.Length - 1]
                    .Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string extantion = ext[0];

                long kb = long.Parse(ext[ext.Length - 1]);

                if (!print.ContainsKey(root))
                {
                    print.Add(root, new Dictionary<string, long>());
                    print[root].Add(extantion,kb);
                }
                else if (print.ContainsKey(root))
                {
                    if (print[root].ContainsKey(extantion))
                    {
                        print[root][extantion] = kb;
                    }
                    else
                    {
                        print[root].Add(extantion, kb);
                    }
                }
            }
            string[] command = Console.ReadLine()
                .Split(" ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string findRoot = command[2];

            string findExtantion = command[0];

            bool isFind = false;

            foreach (var files in print.Where(x=>x.Key == findRoot))
            {
                foreach (var inner in files.Value.OrderByDescending(kb=>kb.Value).ThenBy(l=>l.Key))
                {
                    if (inner.Key.Contains($".{findExtantion}"))
                    {
                        isFind = true;
                        Console.WriteLine($"{inner.Key} - {inner.Value} KB");
                    }
                }
            }
            if (!isFind)
            {
                Console.WriteLine("No");
            }
        }
    }
}
