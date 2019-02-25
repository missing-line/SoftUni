namespace Predicate_Party_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();

            Func<string, string, bool> start = (a, b) => a.StartsWith(b);
            Func<string, string, bool> end = (a, b) => a.EndsWith(b);
            Func<string, int, bool> lenght = (a, b) => a.Length == b;

            Action<List<string>> result = x => Console.WriteLine(string.Join(", ", guests) + " are going to the party!"); ;

            string[] command = Console.ReadLine().Split().ToArray();

            while (string.Join("", command) != "Party!")
            {
                if (command[0] == "Remove")
                {
                    if (command[1] == "StartsWith")
                    {
                        guests.RemoveAll(p => start(p, command[2]));
                    }
                    else if (command[1] == "EndsWith")
                    {
                        guests.RemoveAll(p => end(p, command[2]));
                    }
                    else
                    {
                        guests.RemoveAll(p => lenght(p, int.Parse(command[2])));
                    }
                }
                else
                {
                    if (command[1] == "StartsWith")
                    {
                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (start(guests[i], command[2]))
                            {
                                int index = guests.IndexOf(guests[i]);
                                guests.Insert(index + 1, guests[i]);
                                i++;
                            }
                        }
                    }
                    else if (command[1] == "EndsWith")
                    {
                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (end(guests[i], command[2]))
                            {
                                int index = guests.IndexOf(guests[i]);
                                guests.Insert(index + 1, guests[i]);
                                i++;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (lenght(guests[i], int.Parse(command[2])))
                            {
                                int index = guests.IndexOf(guests[i]);
                                guests.Insert(index + 1, guests[i]);
                                i++;
                            }
                        }
                    }
                }
                command = Console.ReadLine().Split().ToArray();
            }
            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
                return;
            }
            result(guests);
        }
    }
}
