using AutoMapper;
using Luxelane.DTOs.UserDto;
using Luxelane.Models;

namespace Luxelane.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, OutputUserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}