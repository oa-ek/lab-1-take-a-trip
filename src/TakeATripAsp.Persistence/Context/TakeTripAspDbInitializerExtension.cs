using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Persistence.Context
{
    public static class TakeTripAspDbInitializerExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            (string adminId, string sellerId, string clientId) = seedUsersAndRoles(builder);

        }

        static (string, string, string) seedUsersAndRoles(ModelBuilder builder)
        {
            var ADMIN_ID = Guid.NewGuid().ToString();
            var CLIENT_ID = Guid.NewGuid().ToString();
            var SELLER_ID = Guid.NewGuid().ToString();

            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string CLIENT_ROLE_ID = Guid.NewGuid().ToString();
            string SELLER_ROLE_ID = Guid.NewGuid().ToString();

            var hasher = new PasswordHasher<AppUser>();

            var users = new List<AppUser>
            {
                 new AppUser
                 {
                     Id = ADMIN_ID,
                     DateOfBirth = DateTime.Now.AddYears(-25),
                     UserName = "admin@taketrip.com",
                     Email = "admin@taketrip.com",
                     FirstName = "Mariia",
                     LastName = "Kovalchuk",
                     EmailConfirmed = true,
                     NormalizedUserName = "ADMIN@TAKETRIP.COM",
                     NormalizedEmail = "ADMIN@TAKETRIP.COM",
                     PasswordHash = hasher.HashPassword(null, "admin$pass"),
                     AccessFailedCount = 0,
                 },
                 new AppUser
                 {
                     Id = SELLER_ID,
                     DateOfBirth = DateTime.Now.AddYears(-25),
                     UserName = "seller@taketrip.com",
                     Email = "seller@taketrip.com",
                     FirstName = "Ivan",
                     LastName = "Petrovych",
                     EmailConfirmed = true,
                     NormalizedUserName = "SELLER@TAKETRIP.COM",
                     NormalizedEmail = "SELLER@TAKETRIP.COM",
                     PasswordHash = hasher.HashPassword(null, "maneger$pass"),
                     AccessFailedCount = 0,

                 },
                 new AppUser
                 {
                     Id = CLIENT_ID,
                     DateOfBirth = DateTime.Now.AddYears(-25),
                     UserName = "client@taketrip.com",
                     Email = "client@taketrip.com",
                     FirstName = "Oleksandr",
                     LastName = "Shevchenko",
                     EmailConfirmed = true,
                     NormalizedUserName = "CLIENT@TAKETRIP.COM",
                     NormalizedEmail = "CLIENT@TAKETRIP.COM",
                     PasswordHash = hasher.HashPassword(null, "client$pass"),
                     AccessFailedCount = 0,

                 }
            };

            builder.Entity<AppUser>().HasData(users);

            builder.Entity<IdentityRole>().HasData(
               new IdentityRole
               {
                   Id = ADMIN_ROLE_ID,
                   Name = "admin",
                   NormalizedName = "ADMIN"
               },
                new IdentityRole
                {
                    Id = SELLER_ROLE_ID,
                    Name = "seller",
                    NormalizedName = "SELLER"
                },
                new IdentityRole
                {
                    Id = CLIENT_ROLE_ID,
                    Name = "client",
                    NormalizedName = "CLIENT"
                });

            builder.Entity<IdentityUserRole<string>>().HasData(

               new IdentityUserRole<string>
               {
                   UserId = ADMIN_ID,
                   RoleId = ADMIN_ROLE_ID
               },
                new IdentityUserRole<string>
                {
                    UserId = SELLER_ID,
                    RoleId = SELLER_ROLE_ID
                },
                new IdentityUserRole<string>
                {
                    UserId = CLIENT_ID,
                    RoleId = CLIENT_ROLE_ID
                });
            return (ADMIN_ID, SELLER_ID, CLIENT_ID);
        }
    }
}