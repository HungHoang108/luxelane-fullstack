using Luxelane.DTOs;
using Luxelane.DTOs.AddressDto;
using Luxelane.Models;
using Luxelane.Services.Interfaces;

namespace Luxelane.Controllers
{
    public class AddressController : CrudController<Address, AddressDTO, OutputAddressDTO>
    {
        public AddressController(ICrudService<Address, AddressDTO, OutputAddressDTO> service) : base(service)
        {
        }
    }
}