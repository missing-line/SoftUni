namespace Data_Transfer
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string patternt = @"^s:([^.;]+);r:([^.;]+);m--(\W[a-zA-Z ]+\W)$";
            int sumTotal = 0;
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                Match match = Regex.Match(line, patternt);
                if (match.Success)
                {
                    string sender = match.Groups[1].Value;
                    char[] charsSender = sender.Where(x => char.IsLetter(x) || x == ' ').ToArray();
                    string reciever = match.Groups[2].Value;
                    char[] charsReciever = reciever.Where(x => char.IsLetter(x) || x == ' ').ToArray();
                    
                    var digitsSender = sender.Where(x => char.IsDigit(x)).ToArray();
                    var digitsReciever = reciever.Where(x => char.IsDigit(x)).ToArray();

                    int sumSender = digitsSender.Select(x => int.Parse(x.ToString())).Sum();
                    int sumReciever = digitsReciever.Select(x => int.Parse(x.ToString())).Sum();

                    sumTotal += sumReciever + sumSender;

                    Console.WriteLine($"{string.Join("", charsSender)} says {match.Groups[3].Value} to {string.Join("", charsReciever)}");
                }
            }
            Console.WriteLine($"Total data transferred: {sumTotal}MB");
        }
    }
}
