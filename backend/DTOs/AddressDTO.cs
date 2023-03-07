using Luxelane.Models;

namespace Luxelane.DTOs
{
    public class AddressDTO : BaseDTO<Address>
    {
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public int PostalCode { get; set; }
        public string Country { get; set; } = null!;

        public override void UpdateModel(Address model)
        {
            model.Street = Street;
            model.City = City;
            model.PostalCode = PostalCode;
            model.Country = Country;
        }
    }
}