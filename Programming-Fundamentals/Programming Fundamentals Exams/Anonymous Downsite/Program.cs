using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Anonymous_Downsite
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int key = int.Parse(Console.ReadLine());
            decimal total = 0;
            List<string> mail = new List<string>();
            for (int i = 0; i < n; i++)
            {
                List<string> line = Console.ReadLine().Split().ToList();
                string email = line[0];
                decimal visit = decimal.Parse(line[1]);
                decimal visitPerOne = decimal.Parse(line[2]);
                total += visit * visitPerOne;
                mail.Add(email);
            }
            BigInteger token = BigInteger.Pow(key,n);
            foreach (var m in mail)
            {
                Console.WriteLine(m);
            }
            Console.WriteLine($"Total Loss: {total:f20}");
            Console.WriteLine($"Security Token: {token}");
        }   
    }
}
