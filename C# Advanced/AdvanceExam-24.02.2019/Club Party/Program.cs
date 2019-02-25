namespace Club_Party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine()
                .Split()
                .ToArray();           
          
            Stack<string> stack = new Stack<string>(input);
            
            Queue<string> halls = new Queue<string>();

            List<long> count = new List<long>() ;
           
            while (stack.Count != 0)
            {
                string value = stack.Pop();
                if (value.All(x=>char.IsDigit(x)))
                {
                    int people = int.Parse(value);
                    if (count.Sum() + people <= capacity && halls.Count != 0)
                    {
                        count.Add(people);
                    }
                    else
                    {
                        if (halls.Count != 0)
                        {
                            string hall = halls.Dequeue();                          
                            Console.WriteLine($"{hall} -> {string.Join(", ",count)}");
                            count.Clear();
                            
                            if (halls.Count != 0)
                            {
                                count.Add(people);
                            }
                        }
                    }
                }
                else
                {
                    halls.Enqueue(value) ;
                }
            }
        }         
    }
}

