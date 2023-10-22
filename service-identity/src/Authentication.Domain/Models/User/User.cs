using Microsoft.AspNetCore.Identity;

namespace Authentication.Domain.Models.User
{
    public class User : IdentityUser
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}