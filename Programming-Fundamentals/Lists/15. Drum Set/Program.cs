namespace _15._Drum_Set
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            List<int> drums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> drumsStart = drums.ToList();
            string command = Console.ReadLine();
            while (command != "Hit it again, Gabsy!")
            {
                int applied = int.Parse(command.ToString());
                for (int i = 0; i < drums.Count; i++)
                {
                    int curr = drums[i] - applied;
                    if (drums[i] == 999999)
                    {
                        continue;
                    }
                    if (curr > 0 && drums[i] != 999999)
                    {
                        drums[i] -= applied;
                    }
                    else if (curr <= 0 && drums[i] != 999999)
                    {
                        if (money >= drumsStart[i] * 3)
                        {
                            drums[i] = drumsStart[i];
                            money -= drumsStart[i] * 3;
                        }
                        else
                        {
                            drums[i] = 999999;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", drums.Where(x => x != 999999)));
            Console.WriteLine($"Gabsy has {money:f2}lv. ");
        }
    }
}
