using Microsoft.AspNetCore.Identity;

namespace authApiNew.models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

    }
}
