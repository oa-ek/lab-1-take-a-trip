using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;
using TakeTripAsp.Persistence.Context;
using TakeTripAsp.Persistence.Repository;

namespace TakeTripAsp.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TripConnectionString") ?? throw new InvalidOperationException();
            services.AddDbContext<TakeTripAspDbContext>(option =>
            option.UseSqlServer(connectionString));

            services.AddScoped<IBaseRepository<Category, int>, BaseRepository<Category, int>>();
            services.AddScoped<IBaseRepository<Status, int>, BaseRepository<Status, int>>();
            services.AddScoped<IBaseRepository<BookingStatus, int>, BaseRepository<BookingStatus, int>>();
            services.AddScoped<IBaseRepository<Reviews, int>, BaseRepository<Reviews, int>>();
            services.AddScoped<IBaseRepository<SelectedTour, int>, BaseRepository<SelectedTour, int>>();
            services.AddScoped<IBaseRepository<Country, int>, BaseRepository<Country, int>>();

        }
    }
}
