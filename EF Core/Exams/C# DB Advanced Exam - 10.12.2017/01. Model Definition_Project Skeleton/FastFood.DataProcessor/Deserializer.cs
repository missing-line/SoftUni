namespace FastFood.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using FastFood.Data;
    using FastFood.DataProcessor.Dto.Import;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using Newtonsoft.Json;

    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";
        private const string SuccessMessageForOrder = "Order for {0} on {1} added";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var employees = new List<Employee>();
            var positions = new List<Position>();

            var dtos = JsonConvert
                .DeserializeObject<ImportEmployeeDto[]>(jsonString);


            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var position = positions
                    .FirstOrDefault(x => x.Name == dto.Position);
                if (position == null)
                {
                    position = new Position { Name = dto.Position };
                    positions.Add(position);
                }

                var emp = new Employee
                {
                    Name = dto.Name,
                    Age = dto.Age,
                    Position = position
                };

                employees.Add(emp);
                sb.AppendLine(string.Format(SuccessMessage, emp.Name));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var items = new List<Item>();
            var categories = new List<Category>();

            var dtos = JsonConvert
                .DeserializeObject<ImportItemDto[]>(jsonString);

            foreach (var dto in dtos)
            {
                var item = items.SingleOrDefault(x => x.Name == dto.Name);

                if (!IsValid(dto) || item != null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var category = categories.SingleOrDefault(x => x.Name == dto.Category);

                if (category == null)
                {
                    category = new Category { Name = dto.Category };
                    categories.Add(category);
                }

                var itemInfo = new Item
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Category = category
                };

                items.Add(itemInfo);
                sb.AppendLine(string.Format(SuccessMessage, itemInfo.Name));
            }

            context.Items.AddRange(items);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var orders = new List<Order>();

            var xml = new XmlSerializer(typeof(ImportOrderDto[]), new XmlRootAttribute("Orders"));

            var dtos = (ImportOrderDto[])xml
                .Deserialize(new StringReader(xmlString));

            foreach (var dto in dtos)
            {
                var enumType = Enum.TryParse(dto.Type, out OrderType result);
                var emp = context.Employees.SingleOrDefault(x => x.Name == dto.Employee);

                if (!IsValid(dto) || !enumType || emp == null || !dto.Items.All(IsValid))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (!IsExistAllItems(context, dto.Items))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }


                var order = new Order
                {
                    Customer = dto.Customer,
                    DateTime = DateTime.ParseExact(dto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Type = Enum.Parse<OrderType>(dto.Type),
                    Employee = emp,
                    OrderItems = dto.Items.Select(x => new OrderItem
                    {

                        Item = context.Items.SingleOrDefault(i => i.Name == x.Name),
                        Quantity = x.Quantity

                    })
                    .ToArray()
                };

                orders.Add(order);
                sb.AppendLine(string.Format(SuccessMessageForOrder,
                    order.Customer,
                    order.DateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
            }

            context.Orders.AddRange(orders);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsExistAllItems(FastFoodDbContext context, ICollection<ItemOrderDto> items)
        {
            bool isValid = true;

            foreach (var item in items)
            {
                var itemInfo = context.Items.SingleOrDefault(x => x.Name == item.Name);
                if (itemInfo == null)
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}