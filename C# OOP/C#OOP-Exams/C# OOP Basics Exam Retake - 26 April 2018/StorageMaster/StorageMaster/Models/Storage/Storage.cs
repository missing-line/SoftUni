namespace StorageMaster.Models.Storage
{
    using StorageMaster.Models.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Storage
    {
        private string name;
        private int capacity;
        private int garageSlots;
        private Vehicle[] garage;
        private List<Product> products;
        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[this.GarageSlots];
            this.products = new List<Product>();            

            FillGarage(vehicles);
        }

        private void FillGarage(IEnumerable<Vehicle> vehicles)
        {
            int index = 0;
            foreach (Vehicle item in vehicles)
            {
                this.garage[index++] = item;
            }
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public int GarageSlots
        {
            get { return this.garageSlots; }
            private set { this.garageSlots = value; }
        }

        public bool IsFull => this.products.Sum(x => x.Weight) >= this.Capacity;


        public IReadOnlyCollection<Vehicle> Garage
            => this.garage;

        public IReadOnlyCollection<Product> Products
            => this.products.AsReadOnly();

        public Vehicle GetVehicle(int garageSlot)
        {
            if (this.GarageSlots <= garageSlot)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            Vehicle vehicle = this.garage[garageSlot];

            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = GetVehicle(garageSlot);

            if (deliveryLocation.garage.All(x => x != null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;
            int index = Array.IndexOf(deliveryLocation.garage, null);
            deliveryLocation.garage[index] = vehicle;

            return index;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = GetVehicle(garageSlot);
            int unloadProducts = 0;
            while (!IsFull && vehicle.IsEmpty == false)
            {               
                Product product = vehicle.Unload();
                this.products.Add(product);
                unloadProducts++;

            }

            return unloadProducts;
        }
    }
}
