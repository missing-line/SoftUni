namespace _4.Froggy
{
    using System;
    using System.Linq;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] numbersOfStones = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(numbersOfStones);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
