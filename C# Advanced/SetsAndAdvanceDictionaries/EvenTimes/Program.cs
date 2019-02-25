namespace EvenTimes
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> digits = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int nummber = int.Parse(Console.ReadLine());

                if (!digits.ContainsKey(nummber))
                {
                    digits.Add(nummber, 0);
                }
                digits[nummber]++;
            }

            foreach (var digit in digits.OrderByDescending(x => x.Value % 2 == 0))
            {
                Console.WriteLine(digit.Key);
                break;
            }
        }
    }
}
