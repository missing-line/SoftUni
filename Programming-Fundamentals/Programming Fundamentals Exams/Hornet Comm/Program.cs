using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hornet_Comm
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
               
            List<KeyValuePair<string, string>> boardcast = new List<KeyValuePair<string, string>>();
            List<KeyValuePair<string, string>> msg = new List<KeyValuePair<string, string>>();
            while (string.Join(" ", line) != "Hornet is Green")
            {             
                string pattern = @"^([\d]+) <-> ([a-zA-Z0-9]+)$";
                Match match = Regex.Match(line.ToString(), pattern);
                if (match.Success)
                {
                    string curr1 = match.Groups[1].Value;
                    string cuur2 = match.Groups[2].Value;
                    string mix = "";
                    for (int i = curr1.Length - 1; i >= 0; i--)
                    {
                        mix += curr1[i];
                    }
                    msg.Add(new KeyValuePair<string, string>(mix,cuur2));
                }

                string pattern1 = @"^([^\d]+) <-> ([a-zA-Z0-9]+)$";
                Match match1 = Regex.Match(line.ToString(), pattern1);
                if (match1.Success)
                {
                    string curr1 = match1.Groups[2].Value;
                    string cuur2 = match1.Groups[1].Value;
                    string mix = "";
                    for (int i = 0; i < curr1.Length; i++)
                    {
                        if (char.IsLower(curr1[i]))
                        {
                            mix += char.ToUpper(curr1[i]);
                        }
                        else if (char.IsUpper(curr1[i]))
                        {
                            mix += char.ToLower(curr1[i]);
                        }
                        else
                        {
                            mix += curr1[i];
                        }
                    }
                    boardcast.Add(new KeyValuePair<string, string>(mix, cuur2));
                }

                line = Console.ReadLine();              
            }
            Console.WriteLine("Broadcasts:");
            if (boardcast.Count > 0)
            {
                foreach (var cast in boardcast)
                {
                    Console.WriteLine($"{cast.Key} -> {cast.Value}");
                }
            }
            else
            {
                Console.WriteLine("None");
            }
            Console.WriteLine("Messages:");
            if (msg.Count > 0)
            {
                foreach (var massage in msg)
                {
                    Console.WriteLine($"{massage.Key} -> {massage.Value}");
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }

    }
}
