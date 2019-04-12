namespace StorageMaster
{
    using StorageMaster.Core;
    using StorageMaster.Models.Intefaces;
    using StorageMaster.Models.Storage;
    using StorageMaster.Models.Vehicles;
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
