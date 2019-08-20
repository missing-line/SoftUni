namespace Summer_Cocktails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            var ingredient = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var freshness = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(ingredient);
            Stack<int> stack = new Stack<int>(freshness);


            while (queue.Count > 0 && stack.Count > 0)
            {               
                int currIngredient = queue.Peek();
                if (currIngredient == 0)
                {
                    queue.Dequeue();
                    continue;
                }

                int fresh = stack.Peek();

                string cocktail = GetCocktail(fresh * currIngredient);

                if (cocktail != null)
                {
                    if (!dic.ContainsKey(cocktail))
                    {
                        dic.Add(cocktail, 0);
                    }
                    dic[cocktail]++;                  
                }
                else
                {
                    currIngredient += 5;                   
                    queue.Enqueue(currIngredient);
                }
                stack.Pop();
                queue.Dequeue();
            }

            GetResult(queue, stack, dic);                   
        }

        private static void GetResult(Queue<int> queue, Stack<int> stack, Dictionary<string, int> dic)
        {
            if (queue.Count == 0 && stack.Count == 0 && dic.Count >= 4)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
                if (queue.Count > 0)
                {
                    Console.WriteLine($"Ingredients left: {queue.Sum()}");
                }
            }

            PrintCocktails(dic);
        }

        private static void PrintCocktails(Dictionary<string, int> dic)
        {
            foreach (var cocktail in dic.OrderBy(k => k.Key))
            {
                Console.WriteLine($" # {cocktail.Key} --> {cocktail.Value}");
            }
        }

        private static string GetCocktail(int value)
        {
            switch (value)
            {
                case 150:
                    return "Mimosa";
                case 250:
                    return "Daiquiri";
                case 300:
                    return "Sunshine";
                case 400:
                    return "Mojito";
                default:
                    return null;
            }
        }
    }
}
