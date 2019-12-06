namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Data;
    using ProductShop.Dtos;
    using ProductShop.Dtos.Export;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });


            using (var context = new ProductShopContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //string xml = File.ReadAllText(@"C:\Users\swade\Desktop\EF Core\XML Processing\ProductShop - Skeleton\ProductShop\Datasets\categories-products.xml");

                //Console.WriteLine(ImportCategoryProducts(context, xml));

                Console.WriteLine(GetCategoriesByProductsCount(context));
            }
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var sb = new StringBuilder();

            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(p => p.ProductsSold.Count())
                .Select(u => new UsersWithSoldProductsDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsCountDto
                    {
                        Count = u.ProductsSold.Count(),
                        Products = u.ProductsSold
                        .Select(p => new SoldProductDTO
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var result = new UsersAndProductsDto
            {
                Count = context.Users.Count(p => p.ProductsSold.Any()),
                Users = users
            };

            var xmlSerializer = new XmlSerializer(typeof(UsersAndProductsDto), new XmlRootAttribute("Users"));          
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), result, namespaces);

            return sb.ToString().TrimEnd();

        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {        
            var categories = context.Categories
                  .Select(c => new ExportCategoryDTO
                  {
                      Name = c.Name,
                      Count = c.CategoryProducts.Count,
                      AveragePrice = c.CategoryProducts.Average(a => a.Product.Price),
                      TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                  })
                  .OrderByDescending(c => c.Count)
                  .ThenBy(x => x.TotalRevenue)
                  .ToArray();

            var sb = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(ExportCategoryDTO[]), new XmlRootAttribute("Categories"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {

            var sb = new StringBuilder();

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new ExportUserDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ProductsSold = u.ProductsSold
                    .Select(p => new SoldProductDTO
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportUserDTO[]), new XmlRootAttribute("Users"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                  .Where(p => p.Price >= 500 && p.Price <= 1000)
                  .OrderBy(p => p.Price)
                  .Select(p => new ExportProductDTO
                  {
                      Name = p.Name,
                      Price = p.Price,
                      Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                  })
                  .Take(10)
                  .ToArray();

            var xml = new XmlSerializer(typeof(ExportProductDTO[]), new XmlRootAttribute("Products"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xml.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xml =
               new XmlSerializer(typeof(CategoryProductDTO[]),
               new XmlRootAttribute("CategoryProducts"));

            var dtos = (CategoryProductDTO[])xml
                .Deserialize(new StringReader(inputXml));

            var categoryProducts = new List<CategoryProduct>();

            foreach (var dto in dtos)
            {
                var innerProductId = context.Products
                    .FirstOrDefault(x => x.Id == dto.ProductId);

                var innerCategoryId = context.Categories
                    .FirstOrDefault(x => x.Id == dto.CategoryId);

                if (innerProductId != null || innerCategoryId != null)
                {
                    categoryProducts.Add(Mapper.Map<CategoryProduct>(dto));
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)

        {
            var xml =
               new XmlSerializer(typeof(CategoryDTO[]), new XmlRootAttribute("Categories"));

            var dtos = (CategoryDTO[])xml
                .Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var dto in dtos)
            {
                categories.Add(Mapper.Map<Category>(dto));
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xml = new XmlSerializer(typeof(ProductExportDTO[]), new XmlRootAttribute("Products"));

            var dtos = (ProductExportDTO[])xml
                .Deserialize(new StringReader(inputXml));

            var products = new List<Product>();

            foreach (var dto in dtos)
            {
                products.Add(Mapper.Map<Product>(dto));
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xml = new XmlSerializer(typeof(UserDTO[]), new XmlRootAttribute("Users"));

            var dtos = (UserDTO[])xml
                .Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var dto in dtos)
            {
                users.Add(Mapper.Map<User>(dto));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

    }
}