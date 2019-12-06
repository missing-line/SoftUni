﻿namespace PetStore.Web.Models.Pets
{
    using PetStore.Services.Models.Pet;
    using System;
    using System.Collections.Generic;
    public class AllPetsViewModel
    {
        public IEnumerable<PetListingServiceModel> Pets { get; set; }

        public int CurrentPage { get; set; }

        public int Total { get; set; }

        public int PrevPage 
            => this.CurrentPage - 1;
        public int NextPage 
            => this.CurrentPage + 1;

        public bool PrevDisabled
            => this.CurrentPage == 1;

        public bool NextDisabled 
        {
            get
            {
                var maxPage = Math.Ceiling((double)this.Total / 25);
                return maxPage == this.CurrentPage;
            }
        }
    }
}
