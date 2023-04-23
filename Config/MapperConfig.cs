using AutoMapper;
using WebApi2.Dtos;
using WebApi2.Models;

namespace WebApi2.Config
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Order, OrderDto>()
    .ForMember(dto => dto.UserId, opt => opt.MapFrom(src => src.User.Id))
    .ForMember(dto => dto.OrderDate, opt => opt.MapFrom(src => src.OrderDate.ToLocalTime()));

            CreateMap<OrderDto, Order>();

            CreateMap<OrderProduct, OrderProductDto>();

            CreateMap<OrderProductDto, OrderProduct>();

            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>();

            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>();

            CreateMap<UserRegisterDto, User>();
        }
    }
}
