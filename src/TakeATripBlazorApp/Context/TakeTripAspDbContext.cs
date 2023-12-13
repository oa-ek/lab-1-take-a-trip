using Microsoft.EntityFrameworkCore;
using TakeATripBlazorApp.Model;

namespace TakeATripBlazorApp.Context
{
    public class TakeTripAspDbContext : DbContext
    {
        public TakeTripAspDbContext(DbContextOptions<TakeTripAspDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(
                "Server=.;Database=TakeATripBlazor;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
