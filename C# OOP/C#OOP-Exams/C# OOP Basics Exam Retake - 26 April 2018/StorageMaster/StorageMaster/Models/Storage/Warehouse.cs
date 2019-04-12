namespace StorageMaster.Models.Storage
{
    using StorageMaster.Models.Vehicles;
    public class Warehouse : Storage
    { 
        private static Vehicle[] vehicles = new Vehicle[]
        {
            new Semi(),
            new Semi(),
            new Semi(),
        };
        public Warehouse(string name)
            : base(name, 10, 10, vehicles)
        {
        }
    }
}
