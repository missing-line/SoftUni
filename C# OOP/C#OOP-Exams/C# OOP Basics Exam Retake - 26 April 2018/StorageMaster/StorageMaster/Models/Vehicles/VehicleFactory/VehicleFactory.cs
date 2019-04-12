using System;

namespace StorageMaster.Models.Vehicles.VehicleFactory
{
    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            switch (type)
            {
                case "Van":
                    Vehicle van = new Van();
                    return van;
                case "Semi":
                    Vehicle semi = new Semi();
                    return semi;
                case "Truck":
                    Vehicle truck = new Truck();
                    return truck;
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }
        }
    }
}
