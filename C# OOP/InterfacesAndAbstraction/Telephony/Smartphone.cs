namespace Telephony
{
    using System;
    using System.Linq;
    public class Smartphone : ICall, IBrows
    {
        public void Browsing(string[] browsName)
        {
            for (int i = 0; i < browsName.Length; i++)
            {
                if (browsName[i].Any(x => char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Console.WriteLine($"Browsing: {browsName[i]}!");
                }

            }
        }

        public void Calling(string[] phoneNumber)
        {
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (!phoneNumber[i].Any(x => char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid number!");
                }
                else
                {
                    Console.WriteLine($"Calling... {phoneNumber[i]}");
                }
            }
        }
    }
}
