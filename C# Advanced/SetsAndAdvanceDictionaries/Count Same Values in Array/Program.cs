namespace Count_Same_Values_in_Array
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> counted = new Dictionary<string, int>();

            string[] array = Console.ReadLine()
                .Split()
                .ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                string currValue = array[i];
                if (!counted.ContainsKey(currValue))
                {
                    counted.Add(currValue, 0);
                }
                counted[currValue]++;
            }

            foreach (var digit in counted)
            {
                Console.WriteLine($"{digit.Key} - {digit.Value} times");
            }
        }
    }
}
