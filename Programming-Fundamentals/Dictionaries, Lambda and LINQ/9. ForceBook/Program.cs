namespace _9._ForceBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine();

            Dictionary<string, List<string>> side = new Dictionary<string, List<string>>();

            while (line != "Lumpawaroo")
            {
                if (line.Contains("|"))
                {
                    string[] curr = line.Split("|".ToCharArray(), StringSplitOptions.None).ToArray();
                    string currSide = curr[0].Trim();
                    string name = curr[1].Trim();

                    if (!side.ContainsKey(currSide))
                    {
                        side.Add(currSide, new List<string>());
                    }

                    side[currSide].Add(name);
                }
                else
                {
                    string[] curr = line
                        .Split("->".ToCharArray(), StringSplitOptions.None)
                        .ToArray();

                    string name = curr[0].Trim();
                    string currSide = curr[curr.Length - 1].Trim();

                    if (side.Values.Any(x => x.Contains(name)))
                    {
                        if (!side.ContainsKey(currSide))
                        {
                            side.Add(currSide, new List<string>() { name });
                            Console.WriteLine($"{name} joins the {currSide} side!");
                        }
                        else if (side.ContainsKey(currSide) && !side[currSide].Contains(name))
                        {
                            side[currSide].Add(name);
                            Console.WriteLine($"{name} joins the {currSide} side!");
                        }
                        foreach (var user in side)
                        {
                            if (user.Key != currSide)
                            {
                                if (user.Value.Contains(name))
                                {
                                    user.Value.Remove(name);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!side.ContainsKey(currSide))
                        {
                            side.Add(currSide, new List<string>() { name });
                            Console.WriteLine($"{name} joins the {currSide} side!");
                        }
                        else
                        {
                            side[currSide].Add(name);
                            Console.WriteLine($"{name} joins the {currSide} side!");
                        }
                    }

                }
                line = Console.ReadLine();
            }

            foreach (var everySide in side.OrderByDescending(x => x.Value.Count()).ThenBy(l => l.Key))
            {
                if (everySide.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {everySide.Key}, Members: {everySide.Value.Count()}");
                    foreach (var inner in everySide.Value.OrderBy(l => l))
                    {
                        Console.WriteLine($"! {inner}");
                    }
                }
            }
        }
    }
}
