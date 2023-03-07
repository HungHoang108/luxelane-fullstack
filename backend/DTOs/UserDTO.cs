using Luxelane.Models;

namespace Luxelane.DTOs
{
    public class UserDTO : BaseDTO<User>
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Avatar { get; set; } = null!;

        public override void UpdateModel(User model)
        {
            model.Name = Name;
            model.Email = Email;
            model.Password = Password;
            model.Avatar = Avatar;
        }
    }
}