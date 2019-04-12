namespace Crypto_Master
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                  .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();

            Queue<int> queue = new Queue<int>(arr);

            int bestLenght = 0;          
            int outCount = 0;
            while (outCount != arr.Length - 1)
            {
                outCount++;
                int count = 0;
                while (count != arr.Length - 1)
                {
                    count++;
                    int step = arr.Length - outCount;
                    List<int> currUsedNums = new List<int>();
                    int num = queue.Dequeue();
                    queue.Enqueue(num);
                    currUsedNums.Add(num);
                    var rotating = new Queue<int>(queue);
                    int innerCount = 0;
                    while (true)
                    {
                        innerCount++;
                        if (step == innerCount)
                        {
                            int currValue = rotating.Dequeue();
                            if (currValue > num && !currUsedNums.Contains(currValue))
                            {
                                rotating.Enqueue(currValue);
                                currUsedNums.Add(currValue);
                                num = currValue;
                                innerCount = 0;
                                continue;
                            }
                            break;
                        }
                        rotating.Enqueue(rotating.Dequeue());
                    }
                    if (bestLenght < currUsedNums.Count)
                    {
                        bestLenght = currUsedNums.Count;                     
                    }
                }
            }
            Console.WriteLine(bestLenght);
        }
    }
}
