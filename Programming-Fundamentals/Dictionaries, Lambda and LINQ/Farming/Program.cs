namespace LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Program
    {
        public static void Main(string[] args)
        { 
            // bad input reading...
            List<string> input = Console.ReadLine().Split().ToList();

            Dictionary<string, int> currency = new Dictionary<string, int>();

            SortedDictionary<string, int> junk = new SortedDictionary<string, int>();

            for (int i = 1; i <= input.Count; i += 2)
            {

                input[i] = input[i].ToLower();

                if (input[i] == "motes")
                {
                    int motesQuantity = int.Parse(input[i - 1]);
                    if (!currency.ContainsKey("motes"))
                    {
                        currency[input[i]] = 0;
                    }
                    currency[input[i]] += motesQuantity;
                    if (currency[input[i]] >= 250)
                    {
                        currency[input[i]] = currency[input[i]] - 250;
                        Console.WriteLine("Dragonwrath obtained!");
                        break;
                    }
                }
                else if (input[i] == "fragments")
                {
                    int fragmentsQuantity = int.Parse(input[i - 1]);
                    if (!currency.ContainsKey("fragments"))
                    {
                        currency[input[i]] = 0;
                    }
                    currency[input[i]] += fragmentsQuantity;
                    if (currency[input[i]] >= 250)
                    {
                        currency[input[i]] = currency[input[i]] - 250;
                        Console.WriteLine("Valanyr obtained!");
                        break;
                    }
                }
                else if (input[i] == "shards")
                {
                    int shardsQuantity = int.Parse(input[i - 1]);
                    if (!currency.ContainsKey("shards"))
                    {
                        currency[input[i]] = 0;
                    }
                    currency[input[i]] += shardsQuantity;
                    if (currency[input[i]] >= 250)
                    {
                        currency[input[i]] = currency[input[i]] - 250;
                        Console.WriteLine("Shadowmourne obtained!");
                        break;
                    }

                }
                else
                {
                    int junkQuantity = int.Parse(input[i - 1]);
                    if (!junk.ContainsKey(input[i]))
                    {

                        junk[input[i]] = 0;
                    }
                    junk[input[i]] += junkQuantity;
                }
            }

            Dictionary<string, int> currencyFinal = currency.OrderByDescending(text => text.Value).ThenBy(text => text.Key).ToDictionary(text => text.Key, text => text.Value);

            if (!currencyFinal.ContainsKey("fragments"))
            {

                currencyFinal.Add("fragments", 0);
            }
            if (!currencyFinal.ContainsKey("motes"))
            {

                currencyFinal.Add("motes", 0);
            }
            if (!currencyFinal.ContainsKey("shards"))
            {

                currencyFinal.Add("shards", 0);
            }


            foreach (var kvp in currencyFinal)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junk)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}