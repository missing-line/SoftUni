using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine()
                .Split('-', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> results = new Dictionary<string, int>();
            Dictionary<string, int> submittion = new Dictionary<string, int>();

            while (line[0] != "exam finished")
            {
                string name = line[0];
                string lang = line[1];     
                
                if (lang == "banned")
                {
                    if (results.ContainsKey(name))
                    {
                        results.Remove(name);
                    }
                }
                else  if (!results.ContainsKey(name))
                {
                    int score = int.Parse(line[2]);
                    results.Add(name, score);
                }
                else if (results.ContainsKey(name))
                {
                    int score = int.Parse(line[2]);
                    if (results[name] < score)
                    {
                        results[name] = score;
                    }
                }
                
                if (!submittion.ContainsKey(lang) && lang != "banned")
                {
                    submittion.Add(lang, 1);
                }
                else if (submittion.ContainsKey(lang))
                {
                    submittion[lang]++;
                }
                line = Console.ReadLine()
                .Split('-', StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine("Results:");
            foreach (var kvp in results.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }
            Console.WriteLine($"Submissions:");
            foreach (var kvp in submittion.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
