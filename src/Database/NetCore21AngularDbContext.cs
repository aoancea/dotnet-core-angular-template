﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NetCore21Angular.Database
{
    public class NetCore21AngularDbContext : IdentityDbContext
    {
        public DbSet<Models.PeriodicElement> PeriodicElements { get; set; }

        public DbSet<Models.Isotope> Isotopes { get; set; }

        public DbSet<Models.Person> People { get; set; }

        public NetCore21AngularDbContext(DbContextOptions<NetCore21AngularDbContext> options)
            : base(options)
        { }
    }
}