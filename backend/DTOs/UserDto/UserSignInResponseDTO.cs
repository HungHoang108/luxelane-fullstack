namespace Luxelane.DTOs.UserDto
{
    public class UserSignInResponseDTO
    {
        public string Token { get; set; } = null!;
        public DateTime Expiration { get; set; }
    }
}