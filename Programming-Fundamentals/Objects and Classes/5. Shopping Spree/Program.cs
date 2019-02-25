namespace _5._Shopping_Spree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public class Customer
        {
            public string Name { set; get; }
            public int Money { set; get; }

            public List<string> AllProducts { set; get; }
        }
        public class Products
        {
            public string Product { set; get; }
            public int Price { set; get; }
        }
        public static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            List<Products> product = new List<Products>();

            string[] names = Console.ReadLine()
                .Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < names.Length; i++)
            {
                string[] currCustomer = names[i]
                    .Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                customers.Add(new Customer()
                {
                    Name = currCustomer[0],
                    Money = int.Parse(currCustomer[1]),
                    AllProducts = new List<string>(),
                });
            }
            string[] producs = Console.ReadLine()
                .Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < producs.Length; i++)
            {
                string[] currProduct = producs[i]
                    .Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                product.Add(new Products()
                {
                    Product = currProduct[0],
                    Price = int.Parse(currProduct[1])
                });
            }
            string[] line = Console.ReadLine()
                .Split()
                .ToArray();

            while (line[0] != "END")
            {
                string name = line[0];
                string buyProduct = line[1];

                if (customers.Any(x => x.Name == name) && product.Any(y => y.Product == buyProduct))
                {
                    Customer ext1 = customers.First(x => x.Name == name);
                    Products ext2 = product.First(x => x.Product == buyProduct);

                    if (ext1.Money >= ext2.Price)
                    {
                        ext1.Money -= ext2.Price;
                        ext1.AllProducts.Add(buyProduct);
                        Console.WriteLine($"{ext1.Name} bought {ext2.Product}");
                    }
                    else
                    {
                        Console.WriteLine($"{ext1.Name} can't afford {ext2.Product}");
                    }

                }
                line = Console.ReadLine().Split().ToArray();
            }
            foreach (var box in customers)
            {
                if (box.AllProducts.Count == 0)
                {
                    Console.WriteLine($"{box.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{box.Name} - {string.Join(", ", box.AllProducts)}");
                }
            }
        }
    }
}
