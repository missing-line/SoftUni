namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Dtos;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierDTO, Supplier>();

            this.CreateMap<PartDTO, Part>();

            this.CreateMap<CarDTO, Car>();

            this.CreateMap<CustomerDTO, Customer>();

            this.CreateMap<SaleDTO, Sale>();
        }
    }
}
