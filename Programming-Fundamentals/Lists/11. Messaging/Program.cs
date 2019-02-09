namespace _11._Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string text = Console.ReadLine();
            string msg = "";
            for (int i = 0; i < nums.Count; i++)
            {
                string currN = nums[i].ToString();
                int sum = 0;
                for (int j = 0; j < currN.Length; j++)
                {
                    sum += int.Parse(currN[j].ToString());
                }
                msg += FindChar(text, sum);
                text = ClearText(text, sum);
            }
            Console.WriteLine(msg);
        }
        public static string ClearText(string text, int sum)
        {
            int currIndex = 0;
            if (sum >= 0 && sum < text.Length)
            {
                currIndex = sum;
            }
            else if (sum > text.Length)
            {
                int index = sum - text.Length;
                while (index > text.Length)
                {
                    sum = index;
                    index = sum - text.Length;
                }
                currIndex = index;
            }
            text = text.Remove(currIndex, 1);
            return text;
        }
        public static string FindChar(string text, int sum)
        {
            string currCh = "";
            if (sum >= 0 && sum < text.Length)
            {
                currCh = text[sum].ToString();
            }
            else if (sum > text.Length)
            {
                int index = sum - text.Length;
                while (index > text.Length)
                {
                    sum = index;
                    index = sum - text.Length;
                }
                currCh = text[index].ToString();
            }
            return currCh;
        }
    }
}
