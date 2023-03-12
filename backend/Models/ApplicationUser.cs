using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Luxelane.Models;
public class ApplicationUser : IdentityUser<int>
{
    [MaxLength(256)]
    public string FirstName { get; set; } = null!;

    [MaxLength(256)]
    public string LastName { get; set; } = null!;
}