namespace StorageMaster.Models.Storage.StorageFactory.ResendingVehicle
{
    using System.Collections.Generic;
    public interface ISendVehicle
    {
        int SendingVehicle(List<Storage> storageRegistry, string sourceName, int sourceGarageSlot, string destinationName);
    }
}
