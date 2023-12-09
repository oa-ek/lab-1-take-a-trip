using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TakeTripAsp.Domain.Entity;


namespace TakeTripAsp.Persistence.Context
{
    public class TakeTripAspDbContext : IdentityDbContext<AppUser>
    {
        public TakeTripAspDbContext(DbContextOptions<TakeTripAspDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<BookingStatus> BookingsStatus { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<TourManagerRequest> TourManagerRequest { get; set; }
        public DbSet<SelectedTour> SelectedTours { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tour>()
                .Property(p => p.FullPrice)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Tour>()
                .Property(p => p.BookingPrice)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Bookings>()
                .Property(p => p.Payment)
                .HasColumnType("decimal(18,2)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TakeTripAspDbContext).Assembly);

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}
