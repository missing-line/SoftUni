using System;
using System.Linq;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {           
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                SumDigits(i);
            }
        }
        static void SumDigits(int n)
        {
            string num = n.ToString();
            int[] arr = new int[num.Length];
            for (int i = 0; i < num.Length; i++)
            {
                arr[i] = int.Parse(num[i].ToString());
            }
            bool isOdd = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    isOdd = true;
                    break;
                }
            }
            if (arr.Sum() % 8 == 0 && isOdd)
            {
                Console.WriteLine(string.Join("",arr));
            }
        }
    }
}
