namespace StorageMaster.Models.Storage
{
    using System.Collections.Generic;
    using StorageMaster.Models.Vehicles;
    public class AutomatedWarehouse : Storage
    {
        private static Vehicle[] vehicles = new Vehicle[]
        {
            new Truck()
        };
        public AutomatedWarehouse(string name)
            : base(name, 1, 2, vehicles)
        {
        }
    }
}
