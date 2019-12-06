namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;
    using System;
    public class BreedService : IBreedService
    {
        private PetStoreDbContext data;

        public BreedService(PetStoreDbContext data)
            => this.data = data;


        public void Add(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Inavalid name!");
            }

            var breed = new Breed() { Name = name };

            this.data.Breeds.Add(breed);
            this.data.SaveChanges(); ;
        }
    }
}
