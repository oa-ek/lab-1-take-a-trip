using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TakeTripAsp.Core.Entity;

namespace TakeTripAsp.Data
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
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
                     UserName = "Mariia",
                     Email = "admin@taketrip.com",
                     FirstName = "Mariia",
                     LastName = "Kovalchuk",
                     EmailConfirmed = true,
                     NormalizedUserName = "MARIIA",
                     NormalizedEmail = "ADMIN@TAKETRIP.COM",
                     PasswordHash = hasher.HashPassword(null, "admin$pass"),
                     AccessFailedCount = 0,
                 },
                 new AppUser
                 {
                     Id = SELLER_ID,
                     DateOfBirth = DateTime.Now.AddYears(-25),
                     UserName = "Ivan",
                     Email = "seller@taketrip.com",
                     FirstName = "Ivan",
                     LastName = "Petrovych",
                     EmailConfirmed = true,
                     NormalizedUserName = "IVAN",
                     NormalizedEmail = "SELLER@TAKETRIP.COM",
                     PasswordHash = hasher.HashPassword(null, "maneger$pass"), 
                     AccessFailedCount = 0,

                 },
                 new AppUser
                 {
                     Id = CLIENT_ID,
                     DateOfBirth = DateTime.Now.AddYears(-25),
                     UserName = "Oleksandr",
                     Email = "client@taketrip.com",
                     FirstName = "Oleksandr",
                     LastName = "Shevchenko",
                     EmailConfirmed = true,
                     NormalizedUserName = "OLEKSANDR",
                     NormalizedEmail = "CLIENT@TAKETRIP.COM",
                     PasswordHash = hasher.HashPassword(null, "client$pass"),
                     AccessFailedCount = 0,

                 }
            };

            builder.HasData(users);

            var roles = new List<IdentityRole>
            {
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
                }
            };

            builder.HasData(roles);

            var userRoles = new List<IdentityUserRole<string>>
            {
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
                }
            };

            builder.HasData(userRoles);
        }
    }
}
