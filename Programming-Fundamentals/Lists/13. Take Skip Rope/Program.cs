namespace _13._Take_Skip_Rope
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<int> indexes = new List<int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    indexes.Add(int.Parse(text[i].ToString()));
                    text = text.Remove(i, 1);
                    i--;
                }
            }
            List<int> take = new List<int>();
            List<int> skip = new List<int>();
            for (int i = 0; i < indexes.Count; i++)
            {
                if (i % 2 != 0)
                {
                    skip.Add(indexes[i]);
                }
                else
                {
                    take.Add(indexes[i]);
                }
            }
            int count = 0;
            string result = "";
            while (true)
            {
                if (count == take.Count - 1)
                {
                    if (take[count] >= text.Length)
                    {
                        string curr1 = text.Substring(0, text.Length);
                        result += curr1;
                        break;
                    }
                    string curr2 = text.Substring(0, take[count]);
                    result += curr2;
                    break;
                }
                string curr = text.Substring(0, take[count]);
                result += curr;
                text = text.Remove(0, take[count] + skip[count]);
                count++;
            }
            Console.WriteLine(result);
        }
    }
}
