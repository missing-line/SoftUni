namespace PetStore.Services.Implementations
{
    using System;
    using Data;
    using System.Collections.Generic;
    using PetStore.Services.Models.Brand;
    using PetStore.Models;
    using System.Linq;

    public class BrandService : IBrandService
    {
        private readonly PetStoreDbContext data;

        public BrandService(PetStoreDbContext context)
            => this.data = context;

        public int Create(string name)
        {
            if (
                name.Length > DataValidation.MaxLength ||
                string.IsNullOrEmpty(name) ||
                this.data.Brands.Any(x => x.Name == name)
               )
            {
                throw new InvalidOperationException("Exception data validations");
            }

            var brand = new Brand
            {
                Name = name
            };

            this.data.Brands.Add(brand);
            this.data.SaveChanges();

            return brand.Id;
        }

        public IEnumerable<BrandListingServiceModel> SearchByName(string name)
            => this.data.Brands
            .Where(br => br.Name.ToLower().Contains(name.ToLower()))
            .Select(br => new BrandListingServiceModel
            {
                  Id = br.Id,
                  Name = br.Name
            })
            .ToList();
            
    }
}
