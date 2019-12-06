namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Dtos;
    using ProductShop.Dtos.Export;
    using ProductShop.Models;
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserDTO, User>();
            this.CreateMap<ProductExportDTO, Product>();
            this.CreateMap<CategoryDTO, Category>();
            this.CreateMap<CategoryProductDTO, CategoryProduct>();
        }
    }
}
