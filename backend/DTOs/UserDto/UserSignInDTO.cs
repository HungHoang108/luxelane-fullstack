using System.ComponentModel.DataAnnotations;

namespace Luxelane.DTOs.UserDto
{
    public class UserSignInDTO
    {
    [EmailAddress]
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    }
}