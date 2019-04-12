using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _08._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Calculate> results = new List<Calculate>();
            for (int i = 0; i < n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                BigInteger c = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                Calculate curr = new Calculate();
                curr.Snow = snowballSnow;
                curr.Time = snowballTime;
                curr.Quanlity = snowballQuality;
                curr.result = c;
                results.Add(curr);
            }
            foreach (var item in results.OrderByDescending(x => x.result))
            {
                Console.WriteLine($"{item.Snow} : {item.Time} = {item.result} ({item.Quanlity})");
                break;
            }
        }
    }
    class Calculate
    {
        public int Snow { set; get; }
        public int Time { set; get; }
        public int Quanlity { set; get; }
        public BigInteger result { set; get; }
    }
}
