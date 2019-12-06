namespace FastFood.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using FastFood.Data;
    using FastFood.DataProcessor.Dto.Export;
    using FastFood.Models.Enums;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;
    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var @enum = Enum.Parse<OrderType>(orderType);

            var emp = context.Employees
                .Where(x => x.Name == employeeName)
                .Select(x => new ExportEmployeeDto
                {
                    Name = x.Name,
                    Orders = x.Orders
                    .Where(t => t.Type == @enum)
                    .Select(y => new ExportItemDto
                    {
                        Customer = y.Customer,
                        Items = y.OrderItems
                        .Select(i => new ExportSingleItemDto
                        {
                            Name = i.Item.Name,
                            Price = i.Item.Price,
                            Quantity = i.Quantity
                        }).ToArray(),
                        TotalPrice = y.OrderItems.Sum(sum => sum.Item.Price * sum.Quantity)
                    })
                    .OrderByDescending(t => t.TotalPrice)
                    .ThenByDescending(i => i.Items.Count())
                    .ToArray(),
                    TotalMade = x.Orders
                    .Where(o => o.Type == @enum)
                    .Sum(o => o.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity))
                })
                .ToArray();

            return JsonConvert.SerializeObject(emp, Formatting.Indented);
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            var categories = context.Categories
                .Where(x => categoriesString.Contains(x.Name))
                .Select(x => new ExportCategoryDto
                {
                    Name = x.Name,
                    MostPopularItem = x.Items                   
                    .Select(i => new MostPopularItemDto
                    {
                        Name = i.Name,
                        TotalMade = i.OrderItems.Sum(oi => oi.Quantity * oi.Item.Price),
                        TimesSold = i.OrderItems.Sum(oi => oi.Quantity)
                    })
                    .OrderByDescending(i => i.TotalMade)
                    .ThenByDescending(i => i.TimesSold)
                    .FirstOrDefault()
                    
                })
                .OrderByDescending(dto => dto.MostPopularItem.TotalMade)
                .ThenByDescending(dto => dto.MostPopularItem.TimesSold)
                .ToArray();


            var sb = new StringBuilder();
            var xml = new XmlSerializer(typeof(ExportCategoryDto[]), new XmlRootAttribute("Categories"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "")});
            xml.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}