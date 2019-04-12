namespace Regeh
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine();

            string pattern = @"\[[^.\[| |\t]+<(\d+)REGEH(\d+)>[^.\]| |\t]+\]";

            MatchCollection match = Regex.Matches(line, pattern);

            int index = 0;
            string result = string.Empty;

            foreach (Match m in match)
            {
                int firstDigit = int.Parse(m.Groups[1].Value);
                int secondDigit = int.Parse(m.Groups[2].Value);

                index += firstDigit;
                if (index >= line.Length)
                {
                    int indexTrim = (index % line.Length) + 1;
                    result += line[indexTrim];
                }
                else
                {
                    result += line[index];
                }

                index += secondDigit;
                if (index >= line.Length)
                {
                    int indexTrim = (index % line.Length) + 1;
                    result += line[indexTrim];
                }
                else
                {
                    result += line[index];
                }
            }
            Console.WriteLine(result);
        }
    }
}
