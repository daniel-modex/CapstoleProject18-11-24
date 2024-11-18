using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.Data
{
    public class UserDBContext:DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
