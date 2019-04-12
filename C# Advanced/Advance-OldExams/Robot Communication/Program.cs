namespace Robot_Communication
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<Queue<string>> queue = new Queue<Queue<string>>();
            string pattern = @"[,|_]([a-zA-Z]+)[0-9]";

            string input;

            while ((input = Console.ReadLine()) != "Report")
            {
                Queue<string> currQueue = new Queue<string>();
                MatchCollection match = Regex.Matches(input, pattern);
                foreach (Match element in match)
                {
                    string currElement = element.Value;
                    int digit = int.Parse(currElement[currElement.Length - 1].ToString());
                    if (currElement[0] == ',')
                    {
                        currQueue.Enqueue(Add(element.Groups[1].Value, digit));
                    }
                    else
                    {
                        currQueue.Enqueue(Subtract(element.Groups[1].Value, digit));
                    }
                }
                queue.Enqueue(currQueue);
            }
            PrintQueues(queue);          
        }

        public static void PrintQueues(Queue<Queue<string>> queue)
        {
            foreach (var line in queue)
            {
                Console.WriteLine(string.Join(" ", line.ToArray()));
            }
        }

        public static string Add(string crypt, int digit)
        {
            string decrypt = string.Empty;
            foreach (var ch in crypt)
            {
                char charCurr = (char)((int)ch + digit);
                decrypt += charCurr;
            }
            return decrypt;
        }
        public static string Subtract(string crypt, int digit)
        {
            string decrypt = string.Empty;
            foreach (var ch in crypt)
            {
                char charCurr = (char)((int)ch - digit);
                decrypt += charCurr;
            }
            return decrypt;
        }
    }
}
