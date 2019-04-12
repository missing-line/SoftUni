namespace StorageMaster.Core
{
    using StorageMaster.Models;
    using StorageMaster.Models.Intefaces;
    using StorageMaster.Models.Products.ProductFactory;
    using StorageMaster.Models.Storage;
    using StorageMaster.Models.Storage.StorageFactory;
    using StorageMaster.Models.Storage.StorageFactory.ResendingVehicle;
    using StorageMaster.Models.Vehicles;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StorageController
    {
        private IProductFactory productFactory;
        private IStorageFactory storageFactory;
        private IProductFinder productFinder;
        private ISendVehicle sendVehicle;
        private List<Product> pool;
        private List<Storage> storageRegistry;
        private IVehicle currentVehicle;
        public StorageController()
        {
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.productFinder = new ProductFinder();
            this.pool = new List<Product>();
            this.storageRegistry = new List<Storage>();
            this.sendVehicle = new SendVehicle();
        }

        public string AddProduct(string type, double price)
        {
            IProduct product = this.productFactory.CreateProduct(type, price);

            this.pool.Add((Product)product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);

            this.storageRegistry.Add(storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);

            this.currentVehicle = storage.GetVehicle(garageSlot);

            return $"Selected {this.currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProducts = 0;
            foreach (var product in productNames)
            {
                Product productFinded = this.productFinder.FindProduct(this.pool, product);
                if (this.currentVehicle.IsFull)
                {
                    break;
                }
                this.currentVehicle.LoadProduct(productFinded);
                loadedProducts++;
            }

            return $"Loaded {loadedProducts}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            int index = this.sendVehicle.SendingVehicle(this.storageRegistry, sourceName, sourceGarageSlot, destinationName);

            Storage destination = this.storageRegistry.FirstOrDefault(x => x.Name == destinationName);

            Vehicle vehicle = destination.GetVehicle(index);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {index})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            int countOfUnloadProducts = 0;

            Storage storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);

            Vehicle vehicle = storage.GetVehicle(garageSlot);

            int productsInVehicle = vehicle.Trunk.Count;

            countOfUnloadProducts = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {countOfUnloadProducts}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            //Stock(2.7 / 10): [HardDrive(2), Gpu(1)]
            //Garage: [Semi|Semi|Semi|Van|empty|empty|empty|empty|empty|empty]
            StringBuilder sb = new StringBuilder();

            Storage storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);

            string sortedproducts = SortProducts(storage.Products);

            sb.AppendLine($"Stock ({storage.Products.Sum(x => x.Weight)}/{storage.Capacity}): [{sortedproducts}]");
            string p = GroupeVehicles(storage.Garage);
            sb.AppendLine($"Garage: [{p}]");

            return sb.ToString().TrimEnd();

        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var storage in this.storageRegistry.OrderByDescending(x => x.Products.Sum(y => y.Price)))
            {
                //{ storageName}:
                //Storage worth: ${ totalMoney: F2}
                sb.AppendLine($"{storage.Name}:");
                sb.AppendLine($"Storage worth: ${storage.Products.Sum(x => x.Price):f2}");
            }

            return sb.ToString().TrimEnd();
        }

        private string SortProducts(IReadOnlyCollection<Product> products)//
        {
            List<string> sb = new List<string>();

            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (var product in products.Where(x => x != null))
            {
                if (!dic.ContainsKey(product.GetType().Name))
                {
                    dic.Add(product.GetType().Name, 0);
                }
                dic[product.GetType().Name]++;

            }

            foreach (var product in dic.OrderByDescending(x => x.Value).ThenBy(n => n.Key))
            {
                sb.Add($"{product.Key} ({product.Value})");
            }

            return string.Join(", ", sb);
        }

        private string GroupeVehicles(IReadOnlyCollection<Vehicle> garage)
        {
            List<string> namesOfVehicles = new List<string>();
            foreach (var vehicle in garage)
            {
                if (vehicle == null)
                {
                    namesOfVehicles.Add("empty");

                }
                else
                {

                    namesOfVehicles.Add(vehicle.GetType().Name);
                }
            }
            return string.Join("|", namesOfVehicles);
        }
    }
}
