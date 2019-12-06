namespace PetStore.Services.Implementations
{
    using System;
    using System.Linq;
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Models.Enums;
    using PetStore.Services.Models.Toy;

    public class ToyService : IToyService
    {
        private PetStoreDbContext data;

        public ToyService(PetStoreDbContext data)
            => this.data = data;

        public void BuyToyFromDestributor(AddToyServiceModel toyServiceModel)
        {
            if (
                       string.IsNullOrWhiteSpace(toyServiceModel.Name) ||
                       string.IsNullOrWhiteSpace(toyServiceModel.Description) ||
                       toyServiceModel.DistributorPrice >= 0 ||
                       toyServiceModel.Profit >= 0 ||
                       data.Brands.Any(x => x.Id == toyServiceModel.BrandId) ||
                       data.Categories.Any(x => x.Id == toyServiceModel.CategoryId)
                   )
            {
                throw new ArgumentException("Invalid arguments! Please check your's input data");
            }

            var toy = new Toy()
            {
                Name = toyServiceModel.Name,
                Description = toyServiceModel.Description,
                PriceFromDistributor = toyServiceModel.DistributorPrice,
                Price = toyServiceModel.Price + (toyServiceModel.DistributorPrice * toyServiceModel.Profit),
                BrandId = toyServiceModel.BrandId,
                CategoryId = toyServiceModel.CategoryId
            };

            this.data.Toys.Add(toy);
            this.data.SaveChanges();

        }

        public void BuyToyFromDistributor(string name, string description, decimal distributorPrice, decimal price, decimal profit, int brandId, int categoryId)
        {

            if (
                    string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(description) ||
                    distributorPrice >= 0 ||
                    profit >= 0 ||
                    data.Brands.Any(x => x.Id == brandId) ||
                    data.Categories.Any(x => x.Id == categoryId) 
                )
            {
                throw new ArgumentException("Invalid arguments! Please check your's input data");
            }

            var toy = new Toy()
            {
                Name = name,
                Description = description,
                PriceFromDistributor = distributorPrice,
                Price = price + (distributorPrice * profit),
                BrandId = brandId,
                CategoryId = categoryId
            };

            this.data.Toys.Add(toy);
            this.data.SaveChanges();
        }

        public bool Exists(int toyId)
            => this.data.Toys.Any(t => t.Id == toyId);

        public void SellToyToUser(int toyId, int userId)
        {
            if (
                    !this.Exists(toyId) ||
                    !this.data.Users.Any(u => u.Id == userId)
               )
            {
                throw new ArgumentException("Invalid data toy or user!");
            }

            var order = new Order
            {
                PurchaseDate = DateTime.Now,
                Status = Status.Done,
                UserId = userId
            };

            var toyOrder = new ToyOrder
            {
                ToyId = toyId,
                Order = order
            };

            this.data.Orders.Add(order);
            this.data.ToyOrders.Add(toyOrder);

            this.data.SaveChanges();
        }
    }
}
