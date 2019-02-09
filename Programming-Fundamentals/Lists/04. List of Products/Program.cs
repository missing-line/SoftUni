﻿namespace _04._List_of_Products
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string currProduct = Console.ReadLine();
                products.Add(currProduct);
            }
            products.Sort();
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }
    }
}
