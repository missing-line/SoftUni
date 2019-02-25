namespace _1.ListyIterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ListyIterator<string> listeIterator = null;
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] arr = input.Split().ToArray();

                string command = arr[0];

                if (command == "Create")
                {
                    listeIterator = new ListyIterator<string>(arr.Skip(1).ToList());
                }
                else if (command == "Move")
                {
                    Console.WriteLine(listeIterator.Move());
                }
                else if (command == "Print")
                {
                    Console.WriteLine(listeIterator.Print());
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listeIterator.HasNext());
                }
            }
        }
    }
}

