namespace PetClinic
{
    using AutoMapper;
    using PetClinic.Models;
    using PetClinic.Processor.Dto.Export;
    using PetClinic.Processor.Dto.Import;
    using System;
    using System.Globalization;

    public class PetClinicProfile : Profile
    {
        public PetClinicProfile()
        {
            CreateMap<ImportAnimalAidDto, AnimalAid>();
            CreateMap<ImportVetDto, Vet>();
            CreateMap<AnimalAid, ExportAnimalAidsDto>();
        }
    }
}
