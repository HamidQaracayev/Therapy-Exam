using Microsoft.AspNetCore.Identity;

namespace Therapy.Core.Models;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
}
