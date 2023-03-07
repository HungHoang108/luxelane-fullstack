using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Services.Interfaces;

namespace Luxelane.Controllers
{
    public class AddressController : CrudController<Address, AddressDTO>
    {
        public AddressController(ICrudService<Address, AddressDTO> service) : base(service)
        {
        }
    }
}