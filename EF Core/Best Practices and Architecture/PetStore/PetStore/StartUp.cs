namespace PetStore
{
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Models.Enums;
    using PetStore.Services.Implementations;
    using System;
    using System.Globalization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var data = new PetStoreDbContext();
          
            var service = new PetService(data);

          
        }
    }
}
