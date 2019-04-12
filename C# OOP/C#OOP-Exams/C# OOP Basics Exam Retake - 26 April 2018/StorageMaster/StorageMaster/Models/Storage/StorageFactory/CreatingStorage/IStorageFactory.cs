using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storage.StorageFactory
{
    public interface IStorageFactory
    {
        
        Storage CreateStorage(string typ, string name);
    }
}
