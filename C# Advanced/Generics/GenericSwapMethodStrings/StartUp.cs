namespace GenericSwapMethodStrings
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Swap<string> box = new Swap<string>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                box.Box.Add(line);
            }

            int[] arrIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int indexFirst = arrIndexes[0];
            int indexSecond = arrIndexes[1];

            box.Swaping(indexFirst,indexSecond);

            box.Box.ForEach(x => Console.WriteLine($"{x.GetType()}: {x}"));         
        }
    }
}
