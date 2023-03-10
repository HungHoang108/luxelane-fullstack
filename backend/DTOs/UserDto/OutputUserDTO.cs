using Luxelane.Models;
using Luxelane.Models.Enum;

namespace Luxelane.DTOs.UserDto
{
    public class OutputUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Address> Addresses { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = null!;
        public string Email { get; set; } = null!;
        public UserRole Role { get; set; }
        public string Avatar { get; set; } = null!;
    }
}