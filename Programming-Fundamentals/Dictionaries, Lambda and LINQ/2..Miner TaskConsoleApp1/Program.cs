namespace _2.Miner_TaskConsoleApp1
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            long line2 = int.Parse(Console.ReadLine());

            Dictionary<string, long> result = new Dictionary<string, long>();

            while (true)
            {
                if (!result.ContainsKey(line1))
                {
                    result.Add(line1, line2);
                }
                else
                {
                    result[line1] += line2;
                }
                line1 = Console.ReadLine();
                if (line1 == "stop")
                {
                    break;
                }

                line2 = long.Parse(Console.ReadLine());
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
