namespace Word_Count
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> words = new List<string>();
            Dictionary<string, int> counted = new Dictionary<string, int>();

            string word = string.Empty;

            using (var reader = new StreamReader(@"01. Word Count\words.txt"))
            {
                while (true)
                {
                    word = reader.ReadLine();
                    if (word == null)
                    {
                        break;
                    }
                    words.Add(word);
                }
            }
            var separated = words[0].ToLower().Split().ToList();
            foreach (var element in separated)
            {
                if (!counted.ContainsKey(element))
                {
                    counted.Add(element, 0);
                }
            }

            using (var reader = new StreamReader(@"01. Word Count\text.txt"))
            {
                while (true)
                {
                    try
                    {
                        string[] currWords = reader.ReadLine().ToLower().Split(" .-?,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                        foreach (var index in currWords)
                        {
                            if (counted.ContainsKey(index))
                            {
                                counted[index]++;
                            }

                        }
                    }
                    catch (Exception)
                    {

                        break;
                    }
                }
            }

            foreach (var kvp in counted.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
