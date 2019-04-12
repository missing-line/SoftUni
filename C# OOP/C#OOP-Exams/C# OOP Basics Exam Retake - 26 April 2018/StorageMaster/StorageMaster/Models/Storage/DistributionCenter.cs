namespace StorageMaster.Models.Storage
{
    using System.Collections.Generic;
    using StorageMaster.Models.Vehicles;
    public class DistributionCenter : Storage
    {
        private static Vehicle[] vehicles = new Vehicle[]
        {
           new Van(),
           new Van(),
           new Van()

        };
        


        public DistributionCenter(string name)
            : base(name, 2, 5, vehicles)
        {
        }
    }
}
