namespace PetStore.Services
{
    using PetStore.Services.Models.Toy;
    public interface IToyService
    {
        void BuyToyFromDistributor(string name, string description, decimal distributorPrice, decimal price, decimal profit, int brandId, int categoryId);

        void BuyToyFromDestributor(AddToyServiceModel toyServiceModel);

        void SellToyToUser(int toyId, int userId);

        bool Exists(int toyId);
    }
}
