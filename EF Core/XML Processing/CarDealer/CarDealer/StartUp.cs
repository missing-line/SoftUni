namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Dtos;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using CarDealer.Dtos.Export;
    using System.Text;
    using System.Xml;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<CarDealerProfile>();
            });

            //var xmlSuppliers = File.ReadAllText(@"C:\Users\swade\Desktop\EF Core\XML Processing\CarDealer\CarDealer\Datasets\suppliers.xml");

            //var xmlParts = File.ReadAllText(@"C:\Users\swade\Desktop\EF Core\XML Processing\CarDealer\CarDealer\Datasets\parts.xml");

            //var xmlCars = File.ReadAllText(@"C:\Users\swade\Desktop\EF Core\XML Processing\CarDealer\CarDealer\Datasets\cars.xml");


            //var xmlCustomers = File.ReadAllText(@"C:\Users\swade\Desktop\EF Core\XML Processing\CarDealer\CarDealer\Datasets\customers.xml");

            //var xmlSales = File.ReadAllText(@"C:\Users\swade\Desktop\EF Core\XML Processing\CarDealer\CarDealer\Datasets\sales.xml");


            using (var context = new CarDealerContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //Console.WriteLine(ImportSuppliers(context, xmlSuppliers));
                //Console.WriteLine(ImportParts(context, xmlParts));
                //Console.WriteLine(ImportCars(context, xmlCars));
                //Console.WriteLine(ImportCustomers(context, xmlCustomers));
                //Console.WriteLine(ImportSales(context, xmlSales));

                Console.WriteLine(GetCarsFromMakeBmw(context));
            }
        }
        /// <summary>
        /// Export Data
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new ExportSaleDTO
                {
                    Car = new ExportCar
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(p => p.Part.Price) -
                        x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportSaleDTO[]), new XmlRootAttribute("sales"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), sales, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Count() > 0)
                .Select(x => new ExportCustomerDTO
                {
                    Name = x.Name,
                    BoughtCount = x.Sales.Count(),
                    SpentMoney = x.Sales.Sum(s => s.Car.PartCars.Sum(c => c.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();


            var xmlSerializer = new XmlSerializer(typeof(ExportCustomerDTO[]), new XmlRootAttribute("customers"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
               .Select(x => new ExportCarWithPartsDTO
               {
                   Make = x.Make,
                   Model = x.Model,
                   Travelled = x.TravelledDistance,
                   Parts = x.PartCars.Select(y => new ExportPartDTO
                   {
                       Name = y.Part.Name,
                       Price = y.Part.Price
                   })
                   .OrderByDescending(p => p.Price)
                   .ToArray()
               })
               .OrderByDescending(t => t.Travelled)
               .ThenBy(m => m.Model)
               .Take(5)
               .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCarWithPartsDTO[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                 .Where(x => x.IsImporter == false)
                 .Select(x => new ExportSuppliersDTO
                 {
                     Id = x.Id,
                     Name = x.Name,
                     PartCount = x.Parts.Count()
                 })
                 .ToArray();

            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ExportSuppliersDTO[]), new XmlRootAttribute("suppliers"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xml.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var carsBMW = context.Cars
                 .Where(x => x.Make == "BMW")
                 .OrderBy(x => x.Model)
                 .ThenByDescending(t => t.TravelledDistance)
                 .Select(x => new ExportCarBmwDTO
                 {
                     Id = x.Id.ToString(),
                     Model = x.Model,
                     Travelled = x.TravelledDistance
                 })
                 .ToArray();

            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ExportCarBmwDTO[]), new XmlRootAttribute("cars"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xml.Serialize(new StringWriter(sb), carsBMW, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                 .Where(x => x.TravelledDistance > 2000000)
                 .Select(x => new ExportCarDTO
                 {
                     Make = x.Make,
                     Model = x.Model,
                     TravelledDistance = x.TravelledDistance
                 })
                 .OrderBy(m => m.Make)
                 .ThenBy(m => m.Model)
                 .Take(10)
                 .ToArray();

            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ExportCarDTO[]), new XmlRootAttribute("cars"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xml.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// Import Data
        /// </summary>
        /// <param name="context"></param>
        /// <param name="inputXml"></param>
        /// <returns></returns>

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xml = new XmlSerializer(typeof(SaleDTO[]), new XmlRootAttribute("Sales"));
            var collection = (SaleDTO[])xml.Deserialize(new StringReader(inputXml));

            var sales = new List<Sale>();

            foreach (var dto in collection)
            {
                var findCar = context.Cars.FirstOrDefault(x => x.Id == dto.CarId);
                if (findCar == null)
                {
                    continue;
                }

                sales.Add(Mapper.Map<Sale>(dto));
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xml = new XmlSerializer(typeof(CustomerDTO[]), new XmlRootAttribute("Customers"));
            var collection = (CustomerDTO[])xml.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();

            foreach (var dto in collection)
            {
                customers.Add(Mapper.Map<Customer>(dto));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xml = new XmlSerializer(typeof(CarDTO[]), new XmlRootAttribute("Cars"));
            var collection = (CarDTO[])xml.Deserialize(new StringReader(inputXml));

            var cars = new List<Car>();

            foreach (var dto in collection)
            {

                var car = Mapper.Map<Car>(dto);

                foreach (var part in dto.Parts.PartId)
                {
                    var find = car.PartCars.FirstOrDefault(x => x.PartId == part.Id);
                    if (find != null)
                    {
                        continue;
                    }
                    car.PartCars.Add(new PartCar() { CarId = car.Id, PartId = part.Id });
                }

                cars.Add(car);
            }


            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xml = new XmlSerializer(typeof(PartDTO[]), new XmlRootAttribute("Parts"));
            var collection = (PartDTO[])xml.Deserialize(new StringReader(inputXml));

            var parts = new List<Part>();

            foreach (var dto in collection)
            {
                var validSupplierId = context.Suppliers.FirstOrDefault(x => x.Id == dto.SupplierId);

                if (validSupplierId == null)
                {
                    continue;
                }

                var part = Mapper.Map<Part>(dto);
                parts.Add(part);
            }


            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";

        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xml = new XmlSerializer(typeof(SupplierDTO[]), new XmlRootAttribute("Suppliers"));
            var collection = (SupplierDTO[])xml.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();

            foreach (var dto in collection)
            {
                suppliers.Add(Mapper.Map<Supplier>(dto));
            }


            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}"; ;
        }
    }
}