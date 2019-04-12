namespace StorageMaster.Models.Vehicles.VehicleFactory
{
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(string type);
    }
}
