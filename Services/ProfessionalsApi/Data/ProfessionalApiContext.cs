using Microsoft.EntityFrameworkCore;
using ProfessionalsApi.Models;

namespace ProfessionalsApi.Data
{
    public class ProfessionalApiContext : DbContext
    {
        public ProfessionalApiContext(DbContextOptions<ProfessionalApiContext> options) : base(options) { }

        public DbSet<Professionals> Professionals { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Domains> Domains { get; set; }

        
    }
}
