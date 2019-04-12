namespace StorageMaster.Models.Storage.StorageFactory.ResendingVehicle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SendVehicle : ISendVehicle
    {

        public int SendingVehicle(List<Storage> storageRegistry, string sourceName, int sourceGarageSlot, string destinationName)
        {
            var sendTo = storageRegistry.FirstOrDefault(x=>x.Name == sourceName);
            if (sendTo == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            var takeOF = storageRegistry.FirstOrDefault(x => x.Name == destinationName);

            if (takeOF == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

           return  sendTo.SendVehicleTo(sourceGarageSlot, takeOF);          
        }
    }
}
