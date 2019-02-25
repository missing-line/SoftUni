namespace Parking_Lot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<string> regs = new HashSet<string>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] arr = input
                    .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (arr[0] == "IN")
                {
                    regs.Add(arr[1]);
                }
                else
                {
                    regs.Remove(arr[1]);
                }
            }
            Console.WriteLine(regs.Count == 0 ? "Parking Lot is Empty" : string.Join("\n", regs));
        }
    }
}
