namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using ProductShop.Data;
    using ProductShop.DateTransferObject.Export;
    using ProductShop.Models;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();


            //var json = File.ReadAllText(@"C:\Users\swade\Desktop\EF Core\JavaScript Object Notation - JSON\Product Shop - Skeleton\ProductShop\Datasets\categories-products.json");

            //string output = ImportCategoryProducts(context, json);

            Console.WriteLine(GetUsersWithProducts(context));

        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson)
                .Where(x => x.LastName != null && x.LastName.Length >= 3)
                .ToList();


            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson)
                .Where(x => x.Name != null && x.Name.Length >= 3)
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(x => x.Name != null && x.Name.Length >= 3 && x.Name.Length <= 15)
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson)
               .ToList();

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();
            return $"Successfully imported {categoriesProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(e => new ProductDTO
                {
                    Name = e.Name,
                    Price = e.Price,
                    Seller = $"{e.Seller.FirstName} {e.Seller.LastName}"

                })
                .OrderBy(x => x.Price)
                .ToList();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(b => b.Buyer != null))
                .Select(e => new UserDTO
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    SoldProducts = e.ProductsSold
                    .Where(x => x.Buyer != null)
                    .Select(p => new SoldProductsDTO
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName,
                    })
                    .ToList()
                })
                .OrderBy(l => l.LastName)
                .ThenBy(f => f.FirstName)
                .ToList();


            DefaultContractResolver defaultContract = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(users, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = defaultContract
            });

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                 .OrderByDescending(x => x.CategoryProducts.Count())
                 .Select(e => new CategoryDTO
                 {
                     Category = e.Name,
                     ProductsCount = e.CategoryProducts.Count(),
                     AveragePrice = $"{(e.CategoryProducts.Sum(p => p.Product.Price) / e.CategoryProducts.Count()):f2}",
                     TotalRevenue = $"{e.CategoryProducts.Sum(p => p.Product.Price):f2}"
                 })
                 .ToList();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                 .Where(x => x.ProductsSold.Any(b => b.Buyer != null))                  
                 .Select(x => new
                 {
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     Age = x.Age,
                     SoldProducts = new
                     {
                         Count = x.ProductsSold.Count(b => b.Buyer != null),
                         Products = x.ProductsSold
                         .Where(b => b.Buyer != null)
                         .Select(y => new
                         {
                             Name = y.Name,
                             Price = y.Price,
                         })
                         .ToList()
                     }
                 })
                 .OrderByDescending(x => x.SoldProducts.Count)
                 .ToList();

            var filteredUsers = new
            {
                UsersCount = users.Count(),
                Users = users
            };

            DefaultContractResolver defaultContract = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(filteredUsers, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = defaultContract,
                NullValueHandling = NullValueHandling.Ignore
            });


            return json;
        }
    }
}