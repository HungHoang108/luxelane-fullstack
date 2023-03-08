using System.Text.Json.Serialization;
using Luxelane.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Luxelane.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; } = null!;
        public ICollection<Address> Addresses { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = null!;
        public string Email { get; set; } = null!;
        [JsonIgnore]
        public string Password { get; set; } = null!;
        [Column(TypeName = "user_role")]
        public UserRole Role { get; set; }
        public string Avatar { get; set; } = null!;
    }

}