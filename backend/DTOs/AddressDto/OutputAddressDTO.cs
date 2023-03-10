namespace Luxelane.DTOs.AddressDto
{
    public class OutputAddressDTO
    {
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public int PostalCode { get; set; }
        public string Country { get; set; } = null!;
        public int UserId { get; set; }
    }
}