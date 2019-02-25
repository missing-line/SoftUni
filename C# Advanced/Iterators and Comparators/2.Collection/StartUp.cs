namespace _2.Collection
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
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
                else if (command == "PrintAll")
                {
                    foreach (var elemetn in listeIterator)
                    {
                        Console.Write(elemetn + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
