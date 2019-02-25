namespace Word_Count
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {

            Dictionary<string, int> counting = new Dictionary<string, int>();
            string symbols = "?.-!,";

            using (var reader = new StreamReader("words.txt"))
            {
                while (true)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    string[] array = line.ToLower().Split().ToArray();

                    foreach (var element in array)
                    {
                        if (!counting.ContainsKey(element))
                        {
                            counting.Add(element, 0);
                        }
                    }

                }
            }

            using (var reader = new StreamReader("text.txt"))
            {
                using (var write = new StreamWriter("actualResults.txt"))
                {
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }

                        string[] array = line
                            .ToLower()
                            .Split()
                            .ToArray();
                        foreach (var element in array)
                        {
                            string currWord = element.Trim(symbols.ToCharArray());
                            if (counting.ContainsKey(currWord))
                            {
                                counting[currWord]++;
                            }
                        }

                    }
                    Console.WriteLine("actualResults:");
                    foreach (var kvp in counting)
                    {
                        Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                        write.WriteLine($"{kvp.Key} - {kvp.Value}");
                    }
                    using (var writter = new StreamWriter("expectedResult.txt"))
                    {
                        Console.WriteLine("expectedResult:");
                        foreach (var kvp in counting.OrderByDescending(x => x.Value))
                        {
                            Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                            write.WriteLine($"{kvp.Key} - {kvp.Value}");
                        }
                    }
                }

            }

        }
    }

}
