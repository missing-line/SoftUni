namespace Telephony
{
    using System;
    using System.Linq;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split()
                .ToArray();

            string[] urls = Console.ReadLine()
               .Split()
               .ToArray();

            ICall calls = new Smartphone();

            calls.Calling(numbers);

            IBrows brows = new Smartphone();

            brows.Browsing(urls);
        }
    }
}
