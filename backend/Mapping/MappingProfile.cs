using AutoMapper;
using Luxelane.DTOs;
using Luxelane.DTOs.AddressDto;
using Luxelane.DTOs.CategoryDto;
using Luxelane.DTOs.OrderDto;
using Luxelane.DTOs.OrderProductDto;
using Luxelane.DTOs.ProductCategoryDto;
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

            CreateMap<Address, OutputAddressDTO>();
            CreateMap<AddressDTO, Address>();

            CreateMap<Order, OutputOrderDTO>();
            CreateMap<OrderDTO, Order>();

            CreateMap<OrderProduct, OutputOrderProductDTO>();
            CreateMap<OrderProductDTO, OrderProduct>();

            CreateMap<Product, OutputProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<Category, OutputCategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<ProductCategory, OutputProductCategoryDTO>();
            CreateMap<ProductCategoryDTO, ProductCategory>();

        }
    }
}