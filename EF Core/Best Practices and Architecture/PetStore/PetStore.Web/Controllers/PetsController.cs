namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetStore.Services;
    using PetStore.Services.Models.Pet;
    using PetStore.Web.Models.Pets;
    using System.Collections.Generic;

    public class PetsController : Controller
    {
        private readonly IPetService pets;
        public PetsController(IPetService pets)
            => this.pets = pets;

        //public IEnumerable<PetListingServiceModel> All()
        //    => this.pets.All();

        public IActionResult All(int page = 1)
        {
            var model = new AllPetsViewModel()
            {
                Pets = this.pets.All(page),
                CurrentPage = page,
                Total = this.pets.Total,
            };
            return this.View(model);

        }
    }
}
