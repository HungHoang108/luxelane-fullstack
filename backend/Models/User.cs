using System.Text.Json.Serialization;
using Luxelane.Models.Enum;

namespace Luxelane.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; } = null!;
        public ICollection<Address> Addresses { get; set; } = null!;
        public string Email { get; set; } = null!;

        [JsonIgnore]
        public string Password { get; set; } = null!;
        public UserRole Role { get; set; }
        public string Avatar { get; set; } = null!;
    }

}