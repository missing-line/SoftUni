using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {          
            List<string> filter = new List<string>();

            List<string> people = Console.ReadLine().Split().ToList();

            List<string> command = Console.ReadLine()
                .Split(";")
                .ToList();

            while (string.Join("", command) != "Print")
            {
                if (command[0] == "Add filter")
                {
                    FilteredPeople(people, filter, command);
                }
                else
                {
                    Filtered(people,filter, command);                    
                }
                command = Console.ReadLine()
                .Split(";")
                .ToList();
            }
            Console.WriteLine(string.Join(" ", people));
        }

        private static void Filtered(List<string> people, List<string> filter, List<string> command)
        {
            Func<string, string, bool> start = (a, b) => a.StartsWith(b);
            Func<string, string, bool> end = (a, b) => a.EndsWith(b);
            Func<string, int, bool> lenght = (a, b) => a.Length == b;
            Func<string, string, bool> contains = (a, b) => a.Contains(b);
            if (command[1] == "Starts with")
            {
                people.AddRange(filter.Where(x => start(x, command[2])));
            }
            else if (command[1] == "Ends with")
            {
                people.AddRange(filter.Where(x => end(x, command[2])));
            }
            else if (command[1] == "Length")
            {
                people.AddRange(filter.Where(x => lenght(x, int.Parse(command[2]))));
            }
            else if (command[1] == "Contains")
            {
                people.AddRange(filter.Where(x => x == command[2]));
            }
            filter.RemoveAll(x => people.Contains(x));
        }

        private static void FilteredPeople(List<string> people, List<string> filter, List<string> command)
        {
            Func<string, string, bool> start = (a, b) => a.StartsWith(b);
            Func<string, string, bool> end = (a, b) => a.EndsWith(b);
            Func<string, int, bool> lenght = (a, b) => a.Length == b;
            Func<string, string, bool> contains = (a, b) => a.Contains(b);

            if (command[1] == "Starts with")
            {
                filter.AddRange(people.Where(x => start(x, command[2])));
            }
            else if (command[1] == "Ends with")
            {
                filter.AddRange(people.Where(x => end(x, command[2])));
            }
            else if (command[1] == "Length")
            {
                filter.AddRange(people.Where(x => lenght(x, int.Parse(command[2]))));
            }
            else if (command[1] == "Contains")
            {
                filter.AddRange(people.Where(x => contains(x, command[2])));
            }
            people.RemoveAll(x => filter.Contains(x));
        }
    }
}
