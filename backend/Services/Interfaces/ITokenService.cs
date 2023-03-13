using Luxelane.DTOs.UserDto;
using Luxelane.Models;

namespace Luxelane.Services.Interfaces
{
    public interface ITokenService
    {
        Task<UserSignInResponseDTO> GenerateTokenAsync(User user);
    }
}