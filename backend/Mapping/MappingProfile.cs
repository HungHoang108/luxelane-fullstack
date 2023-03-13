using AutoMapper;
using Luxelane.DTOs;
using Luxelane.DTOs.AddressDto;
using Luxelane.DTOs.OrderDto;
using Luxelane.DTOs.OrderProductDto;
using Luxelane.DTOs.ProductDto;
using Luxelane.DTOs.UserDto;
using Luxelane.Models;

namespace Luxelane.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, OutputUserDTO>();
            // CreateMap<UserDTO, User>();

            CreateMap<Address, OutputAddressDTO>();
            CreateMap<AddressDTO, Address>();

            CreateMap<Order, OutputOrderDTO>();
            CreateMap<OrderDTO, Order>();

            CreateMap<OrderProduct, OutputOrderProductDTO>();
            CreateMap<OrderProductDTO, OrderProduct>();

            CreateMap<Product, OutputProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}