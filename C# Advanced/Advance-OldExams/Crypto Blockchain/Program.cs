namespace Crypto_Blockchain
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<char> queue = new Queue<char>();

            string block = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    queue.Enqueue(line[j]);
                }
            }


            while (queue.Count > 0)
            {
                char symbol = queue.Dequeue();
                if (symbol == '{')
                {
                    string digits = "";
                    int count = 1;
                    bool isValid = false;
                    while (queue.Count > 0)
                    {
                        count++;
                        symbol = queue.Dequeue();
                        if (symbol == ']')
                        {
                            break;
                        }
                        else if (symbol == '}')
                        {
                            isValid = true;
                            break;
                        }
                        else if (char.IsDigit(symbol))
                        {
                            digits += symbol;
                        }
                    }
                    if (digits.Length % 3 == 0 && isValid)
                    {                       
                        for (int i = 0; i < digits.Length; i += 3)
                        {
                            string currDigit = digits[i].ToString() + digits[i + 1].ToString() + digits[i + 2].ToString();
                            int parser = int.Parse(currDigit) - count;
                            block += (char)parser;
                        }

                    }
                }
                else if (symbol == '[')
                {
                    string digits = "";
                    int count = 1;
                    bool isValid = false;
                    while (queue.Count > 0)
                    {
                        count++;
                        symbol = queue.Dequeue();
                        if (symbol == '}')
                        {
                            break;
                        }
                        else if (symbol == ']')
                        {
                            isValid = true;
                            break;
                        }
                        else if (char.IsDigit(symbol))
                        {
                            digits += symbol;
                        }
                    }
                    if (digits.Length % 3 == 0 && isValid)
                    {
                        for (int i = 0; i < digits.Length; i += 3)
                        {
                            string currDigit = digits[i].ToString() + digits[i + 1].ToString() + digits[i + 2].ToString();
                            int parser = int.Parse(currDigit) - count;
                            block += (char)parser;
                        }

                    }
                }
            }
            Console.WriteLine(block);
        }
    }
}
