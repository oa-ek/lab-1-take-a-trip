using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TakeTripAsp.Domain.Entity;
using TakeTripAsp.Application;
using TakeTripAsp.Persistence.Context;
using TakeTripAsp.Persistence;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("TakeTripAspDbContextConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<TakeTripAspDbContext>(options =>
//    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<TakeTripAspDbContext>();

builder.Services.AddDefaultIdentity<AppUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 4;
}).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<TakeTripAspDbContext>();

//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IRepository<Status, int>, Repository< Status, int>>();
//builder.Services.AddScoped<IRepository<BookingStatus, int>, Repository< BookingStatus, int>>();
//builder.Services.AddScoped<IRepository<Category, int>, Repository< Category, int>>(); 
//builder.Services.AddScoped<IRepository<Tour, int>, Repository<Tour, int>>();
//builder.Services.AddScoped<IRepository<Bookings, int>, Repository<Bookings, int>>();
//builder.Services.AddScoped<IRepository<Reviews, int>, Repository<Reviews, int>>();
//builder.Services.AddScoped<IRepository<TourManagerRequest, int>, Repository<TourManagerRequest, int>>();
//builder.Services.AddScoped<IRepository<SelectedTour, int>, Repository<SelectedTour, int>>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
