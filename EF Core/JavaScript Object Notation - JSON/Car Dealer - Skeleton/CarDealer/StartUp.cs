namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTO;
    using CarDealer.DTO.Exports;
    using CarDealer.Models;
    using Newtonsoft.Json;
    public class StartUp
    {

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            //var jsonReader = File.ReadAllText(@"C:\Users\swade\Desktop\EF Core\JavaScript Object Notation - JSON\Car Dealer - Skeleton\CarDealer\Datasets\customers.json");

            //Console.WriteLine(GetCarsFromMakeToyota(context));
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {

            var list = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new CarExportDTO
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = $"{x.Discount:f2}",
                    price = $"{(x.Car.PartCars.Sum(p => p.Part.Price)):f2}",
                    priceWithDiscount = $"{(x.Car.PartCars.Sum(p => p.Part.Price) - (x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100)):f2}"

                })
                .ToList();

            return JsonConvert.SerializeObject(list , Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var list = context.Customers
               .Where(x => x.Sales.Count > 0)
               .Select(x => new CustomerWithCarDTO // use dto!!!
               {
                   FullName = x.Name,
                   BoughtCars = x.Sales.Count(),
                   SpentMoney = x.Sales.Sum(s => s.Car.PartCars.Sum(sum => sum.Part.Price))
               })
               .OrderByDescending(x => x.SpentMoney)
               .ThenByDescending(x => x.BoughtCars)
               .ToList();

            return JsonConvert.SerializeObject(list);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var list = context.Cars
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance
                    },
                    parts = x.PartCars
                    .Select(y => new
                    {
                        Name = y.Part.Name,
                        Price = $"{y.Part.Price:f2}"
                    }).ToArray()
                })
                .ToList();


            return JsonConvert.SerializeObject(list, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToList();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {

            var toyota = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(m => m.Model)
                .ThenByDescending(d => d.TravelledDistance)
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                })
                .ToList();

            return JsonConvert.SerializeObject(toyota, Formatting.Indented); ;
        }

        //public static string GetOrderedCustomers(CarDealerContext context)
        //{
        //    var customsers = context.Customers
        //        .OrderBy(x => x.BirthDate)
        //        .ThenBy(e => e.IsYoungDriver)
        //        .Select(x => new
        //        {
        //            Name = x.Name,
        //            BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
        //            IsYoungDriver = x.IsYoungDriver
        //        })
        //        .ToList();

        //    return JsonConvert.SerializeObject(customsers, Formatting.Indented);
        //}

        //public static string ImportSuppliers(CarDealerContext context, string inputJson)
        //{
        //    var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson)
        //        .ToList();


        //    context.Suppliers.AddRange(suppliers);
        //    context.SaveChanges();

        //    return $"Successfully imported {suppliers.Count()}."; ;
        //}

        //public static string ImportParts(CarDealerContext context, string inputJson)
        //{
        //    var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
        //        .Where(x => x.SupplierId <= 31)
        //        .ToList();


        //    context.Parts.AddRange(parts);
        //    context.SaveChanges();

        //    return $"Successfully imported {parts.Count()}."; ;
        //}

        //public static string ImportCars(CarDealerContext context, string inputJson)
        //{
        //    var dtos = JsonConvert
        //        .DeserializeObject<CarImportDTO[]>(inputJson);

        //    foreach (var dto in dtos)
        //    {
        //        Car car = new Car
        //        {
        //            Make = dto.Make,
        //            Model = dto.Model,
        //            TravelledDistance = dto.TravelledDistance
        //        };

        //        context.Cars.Add(car);

        //        foreach (var partId in dto.PartsId)
        //        {
        //            PartCar partCar = new PartCar
        //            {
        //                CarId = car.Id,
        //                PartId = partId
        //            };

        //            if (car.PartCars.All(p => p.PartId != partId))
        //            {
        //                context.PartCars.Add(partCar);
        //            }
        //        }
        //    }

        //    context.SaveChanges();

        //    return $"Successfully imported {dtos.Count()}.";
        //}

        //public static string ImportCustomers(CarDealerContext context, string inputJson)
        //{
        //    var customers = JsonConvert
        //      .DeserializeObject<Customer[]>(inputJson)
        //      .ToList();


        //    context.Customers.AddRange(customers);
        //    context.SaveChanges();
        //    return $"Successfully imported {customers.Count()}.";
        //}

        //public static string ImportSales(CarDealerContext context, string inputJson)
        //{

        //    var sales = JsonConvert
        //     .DeserializeObject<Sale[]>(inputJson)
        //     .ToList();

        //    context.Sales.AddRange(sales);
        //    context.SaveChanges();
        //    return $"Successfully imported {sales.Count()}.";
        //}

    }
}