using Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DealLocator.Models
{
    [ExcludeFromCodeCoverage]
    public class DealLocatorDbContext : DbContext
    {
        public DealLocatorDbContext(DbContextOptions<DealLocatorDbContext> options) : base(options)
        {
        }


        public DbSet<Business> Businesses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Deal> Deals { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>().ToTable("Business");
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<Deal>().ToTable("Deal");

        }
    }
}
