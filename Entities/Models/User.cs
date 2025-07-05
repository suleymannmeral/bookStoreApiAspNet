using Microsoft.AspNetCore.Identity;

namespace Entities.Models;

public sealed class User:IdentityUser
{
    public String? FirstName { get; set; }
    public String? LastName { get; set; }

}
