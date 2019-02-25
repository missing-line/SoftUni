namespace Inferno_III
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> gems = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            List<string> command = Console.ReadLine()
                .Split(";")
                .ToList();

            List<int> removeIndex = new List<int>();

            Func<int, int, bool> sumLeft = (a, b) => a + (a - 1) == b;
            Func<int, int, bool> sumRight = (a, b) => a + (a + 1) == b;
            Func<int, int, bool> leftRight = (a, b) => a + (a - 1) + (a + 1) == b;
          
            Dictionary<int, string> filter = new Dictionary<int, string>();

            while (string.Join("", command) != "Forge")
            {
                int value = int.Parse(command[2]);
                string currCommand = command[1];
                if (command[0] == "Exclude")
                {
                    if (!filter.ContainsKey(value))
                    {
                        filter.Add(value, currCommand);
                    }
                    else
                    {
                        filter[value] = currCommand;
                    }
                }
                else
                {
                    if (filter.ContainsKey(value) && filter[value] == (currCommand))
                    {
                        filter.Remove(value);
                    }
                }
                command = Console.ReadLine()
                .Split(";")
                .ToList();
            }

            foreach (var kvp in filter)
            {
                if (kvp.Value == "Sum Left")
                {
                    LeftSum(gems, removeIndex, sumLeft, kvp.Key);
                }
                else if (kvp.Value == "Sum Right")
                {
                    RightSum(gems, removeIndex, sumRight, kvp.Key);
                }
                else
                {
                    LeftRight(gems, removeIndex, leftRight, kvp.Key);
                }
            }
            removeIndex = removeIndex.Distinct().ToList();
            foreach (var i in removeIndex)
            {
                gems[i] = -9999;
            }
            gems.RemoveAll(x => x == -9999);
            Console.WriteLine(string.Join(" ", gems));
        }

        private static void LeftRight(List<int> gems, List<int> removeIndex, Func<int, int, bool> leftRight, int value)
        {
            for (int i = 1; i < gems.Count - 1; i++)
            {
                if (leftRight(gems[i], value))
                {
                    removeIndex.Add(i);
                }
            }
            if (gems.Count == 1)
            {
                if (gems[0] == value)
                {
                    removeIndex.Add(0);
                }
            }
            else
            {
                if (gems[0] + gems[1] == value)
                {
                    removeIndex.Add(0);
                }
                else if (gems[gems.Count - 1] + gems[gems.Count - 2] == value)
                {
                    removeIndex.Add(gems.Count - 1);
                }
            }
        }

        private static void RightSum(List<int> gems, List<int> removeIndex, Func<int, int, bool> sumRight, int value)
        {
            for (int i = 0; i < gems.Count - 1; i++)
            {
                if (sumRight(gems[i], value))
                {
                    removeIndex.Add(i);
                }
            }
            if (gems[gems.Count - 1] == value)
            {
                removeIndex.Add(gems.Count - 1);
            }
        }

        private static void LeftSum(List<int> gems, List<int> removeIndex, Func<int, int, bool> sumLeft, int value)
        {
            for (int i = 1; i < gems.Count; i++)
            {
                if (sumLeft(gems[i], value))
                {
                    removeIndex.Add(i);
                }
            }
            if (gems[0] == value)
            {
                removeIndex.Add(0);
            }
        }
    }
}
