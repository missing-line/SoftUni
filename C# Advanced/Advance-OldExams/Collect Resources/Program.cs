namespace Collect_Resources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            // 70/100
            string[] arr = Console.ReadLine()
                .Split()
                .ToArray();
            List<int> values = new List<int>();

            string[] validResources = new string[]
            {
                "stone", "gold", "wood" ," food",
            };

            Queue<string> queue = new Queue<string>(arr);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                int start = array[0];
                int step = array[1];

                Queue<string> current = new Queue<string>(arr);
                List<string> currentValues = new List<string>();
                int currValue = 0;
                for (int j = 0; j < start; j++)
                {
                    current.Enqueue(current.Dequeue());
                }

                while (true)
                {
                    string firstResurcion = current.Peek();
                    if (!currentValues.Contains(firstResurcion))
                    {
                        if (firstResurcion.Contains("stone") || firstResurcion.Contains("gold") || firstResurcion.Contains("wood") ||
                        firstResurcion.Contains("food"))
                        {

                            currentValues.Add(firstResurcion);
                            if (firstResurcion.Contains("_"))
                            {
                                int index = firstResurcion.IndexOf("_");
                                int value = int.Parse(firstResurcion.Remove(0, index + 1));
                                currValue += value;
                            }
                            else
                            {
                                currValue++;
                            }
                        }
                    }
                    for (int j = 1; j <= step; j++)
                    {
                        current.Enqueue(current.Dequeue());
                    }

                    string secondResurcion = current.Peek();
                    if (!currentValues.Contains(secondResurcion))
                    {
                        if (secondResurcion.Contains("stone") || secondResurcion.Contains("gold") || secondResurcion.Contains("wood") ||
                        secondResurcion.Contains("food"))
                        {
                            currentValues.Add(secondResurcion);
                            if (secondResurcion.Contains("_"))
                            {
                                int index = secondResurcion.IndexOf("_");
                                int value = int.Parse(secondResurcion.Remove(0, index + 1));
                                currValue += value;
                            }
                            else
                            {
                                currValue++;
                            }
                        }
                    }
                    else if (currentValues.Contains(secondResurcion))
                    {
                        break;
                    }
                }
                values.Add(currValue);
            }
            Console.WriteLine(values.Max());
        }
    }
}
