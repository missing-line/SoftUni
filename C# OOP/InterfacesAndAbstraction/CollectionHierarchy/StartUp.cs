namespace CollectionHierarchy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IAdd add = new AddCollection();
            AddRemoveCollection collection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(add.Add(input[i]) + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(collection.Add(input[i]) + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(myList.Add(input[i]) + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.Write(collection.Remove() + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.Write(myList.Remove() + " ");
            }
            Console.WriteLine();
        }
    }
}
