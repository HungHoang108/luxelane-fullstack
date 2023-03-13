using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Luxelane.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace Luxelane.Models
{
    public class User : IdentityUser<int>
    {
        // public string Name { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public ICollection<Address> Addresses { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = null!;
        // public string Email { get; set; } = null!;
        // public string Password { get; set; } = null!;
        public UserRole Role { get; set; }
        public string Avatar { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}