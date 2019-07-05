namespace Make_a_Salad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> results = new List<int>();
            int index = 0;

            string[] vegetables = Console.ReadLine()
                .Split()
                .ToArray();

            int[] calories = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            Stack<int> stack = new Stack<int>(calories);
            Queue<int> queue = new Queue<int>();
            FillVegetables(queue, vegetables);

            int currCal = 0;
            while (stack.Count != 0 && queue.Count != 0)
            {
                int veg = queue.Dequeue();
                currCal = stack.Pop();
               
                currCal -= veg;

                if (currCal <= 0)
                {
                    results.Add(index++);                 
                    currCal = 0;
                }
                else
                {                
                    stack.Push(currCal);
                }
            }
            if (currCal != 0)
            {
                results.Add(index++);
            }

            Print(queue, results, calories, queue);
        }

        private static void Print(Queue<int> queue, List<int> results, int[] calories, Queue<int> q)
        {
            Array.Reverse(calories);
            List<int> salads = new List<int>();
            for (int i = 0; i < results.Count; i++)
            {
                salads.Add(calories[results[i]]);
            }
            Console.WriteLine(string.Join(" ", salads));
            var leftCal = calories.Skip(results.Count).ToArray();
            if (leftCal.Length != 0)
            {
                Console.WriteLine(string.Join(" ", leftCal));
            }

            if (q.Count != 0)
            {             
                Console.WriteLine(ReverseVegetables(q));
            }
        }

        private static string ReverseVegetables(Queue<int> q)
        {
            List<string> leftVeg = new List<string>();
            var vegCal = q.ToArray();
            for (int i = 0; i < vegCal.Length; i++)
            {
                if (vegCal[i] == 80)
                {
                    leftVeg.Add("tomato");

                }
                else if (vegCal[i] == 109)
                {
                    leftVeg.Add("lettuce");

                }
                else if (vegCal[i] == 136)
                {
                    leftVeg.Add("carrot");

                }
                else
                {
                    leftVeg.Add("potato");

                }
            }

            return string.Join(" ", leftVeg);
        }

        private static void FillVegetables(Queue<int> queue, string[] vegetables)
        {
            for (int i = 0; i < vegetables.Length; i++)
            {
                if (vegetables[i] == "tomato")
                {
                    queue.Enqueue(80);
                }
                else if (vegetables[i] == "lettuce")
                {
                    queue.Enqueue(109);
                }
                else if (vegetables[i] == "carrot")
                {
                    queue.Enqueue(136);
                }
                else if(vegetables[i] == "potato")
                {
                    queue.Enqueue(215);
                }
            }
        }
    }
}
