using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Services.Interfaces;

namespace Luxelane.Controllers
{
    public class UserController : CrudController<User, UserDTO>
    {
        // private readonly ILogger<UserController> _logger;

        public UserController(IUserService service) : base(service)
        {

        }

    }
}