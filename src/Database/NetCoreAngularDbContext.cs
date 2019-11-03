using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NetCoreAngular.Database
{
    public class NetCoreAngularDbContext : IdentityDbContext
    {
        public DbSet<Models.PeriodicElement> PeriodicElements { get; set; }

        public DbSet<Models.Isotope> Isotopes { get; set; }

        public DbSet<Models.Person> People { get; set; }

        public NetCoreAngularDbContext(DbContextOptions<NetCoreAngularDbContext> options)
            : base(options)
        { }
    }
}