using System;

namespace _02._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstCh = Console.ReadLine();
            string secondCh = Console.ReadLine();
            string randomString = Console.ReadLine();
            int first = (int)firstCh[0];
            int second = (int)secondCh[0];
            int sum = 0;
            if (first >= second)
            {
                for (int i = 0; i < randomString.Length; i++)
                {
                    if ((int)randomString[i] < first && (int)randomString[i] > second)
                    {
                        sum += (int)randomString[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < randomString.Length; i++)
                {
                    if ((int)randomString[i] < second && (int)randomString[i] > first)
                    {
                        sum += (int)randomString[i];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
