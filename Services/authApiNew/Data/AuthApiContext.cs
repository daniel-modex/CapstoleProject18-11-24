using authApiNew.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace authApiNew.Data
{
    public class AuthApiContext:IdentityDbContext<ApplicationUser>
    {
        public AuthApiContext(DbContextOptions<AuthApiContext> options) : base(options) { }


    }
}
