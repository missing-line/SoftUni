namespace PetStore.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Models.Enums;
    using PetStore.Services.Models.Pet;

    public class PetService : IPetService
    {
        private const int PageSize = 25;

        private PetStoreDbContext data;

        public PetService(PetStoreDbContext data)
            => this.data = data;


        public void BuyPetFomDistributor(string gender, DateTime dateOfBirth, decimal price, string description, int breedId, int categoryId)
        {

            var g = Enum.TryParse(gender, ignoreCase: false, out Gender result);
            if (
                    !g || 
                    price <= 0 ||
                    !this.data.Breeds.Any(br => br.Id == breedId) ||
                    !this.data.Categories.Any(c => c.Id == categoryId)
               )
            {
                throw new ArgumentException("");
            }

            var pet = new Pet()
            {
                Gender = Enum.Parse<Gender>(gender),
                DateOfBirth = dateOfBirth,
                Price = price,
                BreedId = breedId,
                CategoryId = categoryId,
                Description = description,
            };

            this.data.Pets.Add(pet);
            this.data.SaveChanges();
        }

        public void SellPet(int petId, int userId)
        {
            if (
                    !this.data.Pets.Any(b => b.Id == petId) ||
                    !this.data.Users.Any(c => c.Id == userId)
                )
            {
                throw new ArgumentException("Invalid data!");
            }

            var order = new Order()
            {
                PurchaseDate = DateTime.Now,
                UserId = userId,
                Status = Status.Done,
            };

            order.Pets.Add(this.data.Pets
                .SingleOrDefault(p => p.Id == petId));

            this.data.Orders.Add(order);
            this.data.SaveChanges();
        }

        public IEnumerable<PetListingServiceModel> All(int page = 1)
            => this.data
            .Pets
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .Select(x => new PetListingServiceModel
            {
                Id = x.Id,
                Category = x.Category.Name,
                Breed = x.Breed.Name,
                Price = x.Price
            })
            .ToList();

        public int Total 
            => this.data.Pets.Count();
    }
}
