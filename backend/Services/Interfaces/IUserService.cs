using Luxelane.DTOs.UserDto;
using Luxelane.Models;

namespace Luxelane.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> SignUpAsync(UserSignUpDTO request);
        Task<UserSignInResponseDTO?> SignInAsync(UserSignInDTO request);

    }
}