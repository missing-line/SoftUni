namespace GenericSwapMethodInteger
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Swap<int> box = new Swap<int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                box.Box.Add(number);
            }

            int[] arrIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int indexFirst = arrIndexes[0];
            int indexSecond = arrIndexes[1];

            box.Swaping(indexFirst, indexSecond);

            box.Box.ForEach(x => Console.WriteLine($"{x.GetType()}: {x}"));
        }
    }
}
