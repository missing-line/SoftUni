using System;

namespace _5._HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string h1 = Console.ReadLine();
            string content = Console.ReadLine();
            Console.WriteLine("<h1>");
            Console.WriteLine($"    {h1}");
            Console.WriteLine("</h1>");
            Console.WriteLine("<article>");
            Console.WriteLine($"    {content}");
            Console.WriteLine("</article>");
            
            string div = Console.ReadLine();
            while (div != "end of comments")
            {
                Console.WriteLine("<div>");
                Console.WriteLine($"    {div}");
                Console.WriteLine("</div>");
                div = Console.ReadLine();
            }
        }
    }
}
