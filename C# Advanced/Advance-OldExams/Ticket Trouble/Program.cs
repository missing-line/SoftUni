namespace Ticket_Trouble
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            string first = Console.ReadLine();

            string second = Console.ReadLine();

            List<string> seats = new List<string>();
            int firstRow = 0;
            int secondRow = 0;

            string pattern2 = @"\{[^.\[]*\.*[^.\[]*\[([A-Z]{3} [A-Z]{2})\][^.\[]*\.*[^.\[]*\[([A-Z]\d{1,2})\][^.\[]*\.*[^.\[]*\}";
            string pattern1 = @"\[[^.\{]*\.*[^.{]*\{([A-Z]{3} [A-Z]{2})\}[^.\{]*\.*[^.{]*\{([A-Z]\d{1,2})\}[^.\{]*\.*[^.{]*\]";

            MatchCollection match1 = Regex.Matches(second, pattern1);
            foreach (Match i in match1)
            {
                string chekcerLocation = i.Groups[1].Value;
                if (chekcerLocation == first)
                {
                    seats.Add(i.Groups[2].Value);
                }
            }

            MatchCollection match2 = Regex.Matches(second, pattern2);
            foreach (Match i in match2)
            {
                string chekcerLocation = i.Groups[1].Value;
                if (chekcerLocation == first)
                {
                    seats.Add(i.Groups[2].Value);
                }
            }
            if (seats.Count > 2)
            {
                Dictionary<string, List<int>> sortedRow = new Dictionary<string, List<int>>();
                int count = 0;
                foreach (var row in seats)
                {
                    string letterRow = row.Remove(0, 1);
                    if (!sortedRow.ContainsKey(letterRow))
                    {
                        sortedRow.Add(letterRow, new List<int>());
                    }
                    sortedRow[letterRow].Add(count);
                    count++;
                }
                foreach (var i in sortedRow.OrderByDescending(x => x.Value.Count == 2))
                {
                    firstRow = i.Value[0];
                    secondRow = i.Value[1];
                    break;
                }
                Console.WriteLine($"You are traveling to {first} on seats {seats[firstRow]} and {seats[secondRow]}.");
                return;
            }
            Console.WriteLine($"You are traveling to {first} on seats {seats[0]} and {seats[1]}.");
        }
    }
}
