namespace PetStore.Services
{
    using PetStore.Services.Models.Pet;
    using System;
    using System.Collections.Generic;

    public interface IPetService
    {
         IEnumerable<PetListingServiceModel> All(int page = 1);

        void BuyPetFomDistributor(string gender, DateTime dateTime, decimal price, string dscription, int breedId, int categoryId);

        void SellPet(int petId, int userId);

        int Total { get; }
    }
}
