using Luxelane.DTOs.UserDto;
using Luxelane.Models;
using Luxelane.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Luxelane.Controllers
{

    // public class UserController : CrudController<User, UserDTO, OutputUserDTO>
    // {
    //     // private readonly ILogger<UserController> _logger;
    //     public UserController(ICrudService<User, UserDTO, OutputUserDTO> service) : base(service)
    //     {
    //     }
    // }

    public class UserController : ApiControllerBase
    {
        protected readonly IUserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(UserSignInDTO request)
        {
            var response = await _service.SignInAsync(request);
            if (response is null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> SignUpAsync(UserSignUpDTO request)
        {
            var user = await _service.SignUpAsync(request);
            // _logger.LogInformation($"User {request} is attempting to signup");
            if (user is null)
            {
                // _logger.LogInformation($"User is null");

                return BadRequest();
            }
            return Ok(UserSignUpResponseDTO.FromUser(user));
        }
    }

}