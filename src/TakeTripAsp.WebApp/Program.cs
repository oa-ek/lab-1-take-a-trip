using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TakeTripAsp.Core.Context;
using TakeTripAsp.Core.Entity;
using TakeTripAsp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("TripConnectionString") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<TakeTripAspDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TakeTripAspDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRepository<Status, int>, Repository< Status, int>>();
builder.Services.AddScoped<IRepository<BookingStatus, int>, Repository< BookingStatus, int>>();
builder.Services.AddScoped<IRepository<Category, int>, Repository< Category, int>>();


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
