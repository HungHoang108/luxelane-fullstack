using Luxelane.DTOs.UserDto;
using Luxelane.Models;
using Luxelane.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Luxelane.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly ILogger<UserService> _logger;

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, ITokenService tokenService, ILogger<UserService> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<UserSignInResponseDTO?> SignInAsync(UserSignInDTO request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return null;
            }
            if (!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return null;
            }
            return await _tokenService.GenerateTokenAsync(user);
        }

        public async Task<User?> SignUpAsync(UserSignUpDTO request)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email,
                Email = request.Email,
                Avatar = request.Avatar
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            _logger.LogInformation($"User sign up result :{result}");

            if (!result.Succeeded)
            {
                return null;
            }

            var roles = new[] { "Admin", "Dev" };
            foreach (var role in roles)
            {
                if (await _roleManager.FindByNameAsync(role) is null)
                {
                    await _roleManager.CreateAsync(new IdentityRole<int>
                    {
                        Name = role,
                    });
                }
            }

            await _userManager.AddToRolesAsync(user, roles);

            return user;
        }
    }
}