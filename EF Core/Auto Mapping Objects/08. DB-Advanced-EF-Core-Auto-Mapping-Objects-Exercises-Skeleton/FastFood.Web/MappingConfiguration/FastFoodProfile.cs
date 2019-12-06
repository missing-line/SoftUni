namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Web.ViewModels.Categories;
    using FastFood.Web.ViewModels.Employees;
    using FastFood.Web.ViewModels.Items;
    using FastFood.Web.ViewModels.Orders;
    using Models;

    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Employees
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(scr => scr.Id))
                .ForMember(x => x.PositionName, y => y.MapFrom(scr => scr.Name));

            this.CreateMap<RegisterEmployeeInputModel, Employee>()
                .ForMember(x => x.Name, y => y.MapFrom(src => src.Name));

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(src => src.Position.Name));

            //Category

            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(src => src.CategoryName));


            //item
            this.CreateMap<Category, CreateItemViewModel>()
           .ForMember(x => x.CategoryId, y => y.MapFrom(src => src.Id))
           .ForMember(x => x.CategoryName, y => y.MapFrom(src => src.Name)); 

            this.CreateMap<CreateItemInputModel, Item>()
                .ForMember(x => x.Name, y => y.MapFrom(src => src.Name));

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(src => src.Id));

            //Order

            this.CreateMap<CreateOrderInputModel, Order>();
                
                

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.OrderId, y => y.MapFrom(src => src.Id))
                .ForMember(x => x.Employee, y => y.MapFrom(src => src.Employee.Name))
                .ForMember(x => x.DateTime, y => y.MapFrom(src => src.DateTime.ToString("MM/dd/yyyy")));

        }
    }
}
