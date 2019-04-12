namespace Cubic_Artillery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static StringBuilder resultOfAllFullBunkers = new StringBuilder();
        public static void Main(string[] args)
        {

            Queue<Bunker> bunkers = new Queue<Bunker>();

            int capacity = int.Parse(Console.ReadLine());

            string input;

            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                Queue<string> queue = new Queue<string>(input.Split().ToArray());

                while (queue.Count != 0)
                {
                    string value = queue.Dequeue();
                    if (value.Any(x => char.IsDigit(x)))
                    {
                        int weapon = int.Parse(value);

                        if (bunkers.Count == 1 && weapon <= capacity)
                        {
                            var currQueue = bunkers.Dequeue();
                            currQueue.Weapons.Enqueue(weapon);
                            if (currQueue.Weapons.Sum() > capacity)
                            {
                                while (currQueue.Weapons.Count != 0)
                                {
                                    currQueue.Weapons.Dequeue();
                                    if (currQueue.Weapons.Sum() <= capacity)
                                    {
                                        break;
                                    }
                                }
                            }
                            bunkers.Enqueue(currQueue);
                        }
                        else
                        {
                            while (bunkers.Count > 1)
                            {
                                if (bunkers.Peek().Weapons.Sum() + weapon <= capacity)
                                {
                                    bunkers.Peek().Weapons.Enqueue(weapon);
                                    if (bunkers.Peek().Weapons.Sum() == capacity)
                                    {
                                        AddBunkerToPrinting(bunkers.Dequeue());
                                    }
                                    break;
                                }
                                else
                                {
                                    AddBunkerToPrinting(bunkers.Dequeue());
                                }
                            }
                        }
                    }
                    else
                    {
                        bunkers.Enqueue(new Bunker(value, new Queue<string>()));
                    }
                }
            }
            Console.WriteLine(resultOfAllFullBunkers);
        }

        private static void AddBunkerToPrinting(Bunker bunker)
        {
            resultOfAllFullBunkers.Append((bunker.Weapons.Count == 0)
                    ? $"{bunker.Name} -> Empty"
                    : $"{bunker.Name} -> {string.Join(", ", bunker.Weapons)}");

            resultOfAllFullBunkers.Append(Environment.NewLine);
        }
    }

    public class Bunker
    {
        public Bunker(string name, Queue<string> weapons)
        {
            this.Name = name;
            this.Weapons = new Queue<int>();
        }

        public string Name { get; set; }
        public Queue<int> Weapons { get; set; }
    }
}

