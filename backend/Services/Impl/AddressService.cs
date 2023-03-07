using Luxelane.Db;
using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Services.Interfaces;

namespace Luxelane.Services.Impl
{
    public class AddressService : CrudService<Address, AddressDTO>, IAddressService
    {
        public AddressService(DataContext context) : base(context)
        {
        }
    }
}