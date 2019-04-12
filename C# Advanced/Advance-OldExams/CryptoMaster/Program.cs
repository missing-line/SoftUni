namespace _02._Crypto_Master
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            short[] arr = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(short.Parse)
                .ToArray();

            int bestLenght = 1;

            for (int i = 0; i < arr.Length; i++)
            {

                for (int step = 1; step < arr.Length; step++)
                {
                    int currentIndex = i;

                    int nextIndex = (currentIndex + step) % arr.Length;
                    int flyStep = 1;

                    while (arr[nextIndex] > arr[currentIndex])
                    {
                        flyStep++;
                        if (flyStep > bestLenght)
                        {
                            bestLenght = flyStep;
                        }

                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + step) % arr.Length;
                    }
                }
            }
            Console.WriteLine(bestLenght);
        }
    }
}