namespace PetStore.Services.Implementations
{
    using System;
    using System.Linq;
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Models.Enums;
    using PetStore.Services.Models.Food;
    public class FoodService : IFoodService
    {
        private readonly PetStoreDbContext data;

        public FoodService(PetStoreDbContext context)
            => this.data = context;

        public void BuyFromDistributor(string name, double weight, decimal price, decimal profit, DateTime expirationDate, int brandId, int categoryId)
        {
            if (
                    string.IsNullOrWhiteSpace(name) ||
                    weight <= 0 ||
                    price <= 0 ||
                    profit <= 0 ||
                    !this.data.Brands.Any(b => b.Id == brandId) ||
                    !this.data.Categories.Any(c => c.Id == categoryId)
                )
            {
                throw new ArgumentException("Data argumnets aren't valid!");
            }

            var food = new Food()
            {
                Name = name,
                Weight = weight,
                Price = price * (price * profit),
                PriceFromDistributor = price,
                ExpirationDate = expirationDate,
                BrandId = brandId,
                CategoryId = categoryId
            };

            this.data.Foods.Add(food);
            this.data.SaveChanges();
        }

        public void BuyFromDistributor(AddFoodServiceModel foodServiceModel)
        {
            if (
                    string.IsNullOrWhiteSpace(foodServiceModel.Name) ||
                    foodServiceModel.Weight <= 0 ||
                    foodServiceModel.Price <= 0 ||
                    foodServiceModel.Profit <= 0 ||
                    !this.data.Brands.Any(b => b.Id == foodServiceModel.BrandId) ||
                    !this.data.Categories.Any(c => c.Id == foodServiceModel.CategoryId)
                )
            {
                throw new ArgumentException("Data argumnets aren't valid!");
            }

            var food = new Food()
            {
                Name = foodServiceModel.Name,
                Weight = foodServiceModel.Weight,
                Price = foodServiceModel.Price * (foodServiceModel.Price * foodServiceModel.Profit),
                PriceFromDistributor = foodServiceModel.Price,
                ExpirationDate = foodServiceModel.ExpirationDate,
                BrandId = foodServiceModel.BrandId,
                CategoryId = foodServiceModel.CategoryId
            };

            this.data.Foods.Add(food);
            this.data.SaveChanges();
        }

        public void SellFoodToUser(int foodId, int userId)
        {
            if (
                    !this.data.Foods.Any(b => b.Id == foodId) ||
                    !this.data.Users.Any(c => c.Id == userId)
                )
            {
                throw new ArgumentException("Invalid data!");
            }

            var order = new Order()
            {
                PurchaseDate = DateTime.Now,
                Status = Status.Done,
                UserId = userId,
            };

            var foorOder = new FoodOrder()
            {
                FoodId = foodId,
                OrderId = order.Id
            };

            this.data.Orders.Add(order);
            this.data.FoodOrders.Add(foorOder);
            this.data.SaveChanges();
        }
    }
}
