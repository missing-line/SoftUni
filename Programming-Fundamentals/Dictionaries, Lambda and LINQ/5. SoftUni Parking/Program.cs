namespace _5._SoftUni_Parking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> park = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                string username = command[1];

                if (command.Contains("register"))
                {
                    string plate = command[2];
                    if (!park.ContainsKey(username))
                    {
                        park.Add(username, plate);
                        Console.WriteLine($"{username} registered {plate} successfully");
                    }
                    else if (park.ContainsKey(username))
                    {
                        string regNum = park[username];
                        Console.WriteLine($"ERROR: already registered with plate number {regNum}");
                    }
                }
                else
                {
                    if (park.Any(x => x.Key == username))
                    {
                        park.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (var regPlate in park)
            {
                Console.WriteLine($"{regPlate.Key} => {regPlate.Value}");
            }
        }
    }
}
