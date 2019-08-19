using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] line = Console.ReadLine().Split("!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<string> sequance = new List<string>();
            while (string.Join(" ", line) != "Clone them")
            {
                string curr = string.Join("", line);
                if (curr.Length == num)
                {
                    sequance.Add(curr);
                }
                line = Console.ReadLine().Split("!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            string sequances = "";
            int sequanceIndex = 0;
            int sumSeq = 0;
            int lenghtOfSeq = 0;
            int position = 0;
            for (int i = 0; i < sequance.Count; i++)
            {
                string curr = sequance[i].ToString();
                int index = 111;
                int indexLast = 0;
                int countSeq = 0;
                int lastSeq = 0;
                int currSum = 0;
                for (int i1 = 1; i1 <= curr.Length - 1; i1++)
                {
                    if (curr[i1] == curr[i1 - 1] && curr[i1] == '1')
                    {
                        if (i1 - 1 < index)
                        {
                            index = i1 - 1;
                        }
                        countSeq++;
                    }
                    else
                    {
                        if (countSeq > lastSeq)
                        {
                            lastSeq = countSeq;
                            indexLast = index;//
                        }
                        countSeq = 0;
                    }
                }
                currSum = Sum(curr);
                if (lastSeq != 0)
                {
                    lastSeq++;
                }
                if (lenghtOfSeq < lastSeq)
                {
                    sequances = curr;
                    sequanceIndex = indexLast;
                    sumSeq = currSum;
                    position = i;
                    lenghtOfSeq = lastSeq;
                }
                else if (lenghtOfSeq == lastSeq)
                {
                    if (sequanceIndex > indexLast)
                    {
                        sequances = curr;
                        sequanceIndex = indexLast;
                        position = i;
                        sumSeq = currSum;
                    }
                    else if (sequanceIndex == indexLast)
                    {
                        if (sumSeq < currSum)
                        {
                            sequances = curr;
                            sequanceIndex = indexLast;
                            sumSeq = currSum;
                            position = i;
                        }
                    }
                }
            }
            if (sequances == string.Empty)
            {
                Console.WriteLine($"Best DNA sample {0} with sum: {0}.");
                for (int i = 0; i < sequances.Length; i++)
                {
                    Console.Write(sequance[i] + " ");
                }
                Console.WriteLine();
                return;
            }
            Console.WriteLine($"Best DNA sample {position + 1} with sum: {sumSeq}.");
            for (int i = 0; i < sequances.Length; i++)
            {
                Console.Write(sequances[i] + " ");
            }
            Console.WriteLine();

        }
        static int Sum(string curr)
        {
            int sum = 0;
            for (int i = 0; i < curr.Length; i++)
            {
                sum += int.Parse(curr[i].ToString());
            }
            return sum;
        }

    }
}
