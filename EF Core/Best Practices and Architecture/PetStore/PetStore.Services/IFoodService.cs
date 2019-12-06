namespace PetStore.Services.Implementations
{
    using PetStore.Services.Models.Food;
    using System;
    public interface IFoodService
    {
        void BuyFromDistributor(string name, double weight, decimal price, decimal profil, DateTime expirationDate, int brandId, int categoryId);

        void BuyFromDistributor(AddFoodServiceModel foodServiceModel);

        void SellFoodToUser(int foodId, int userId);
    }
}
