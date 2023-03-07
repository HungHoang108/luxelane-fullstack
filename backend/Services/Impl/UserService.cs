using Luxelane.Db;
using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Services.Interfaces;

namespace Luxelane.Services.Impl
{
    public class UserService : CrudService<User, UserDTO>, IUserService
    {
        public UserService(DataContext context) : base(context)
        {
        }

    }
}