using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;
using TakeTripAsp.Persistence.Context;

namespace TakeTripAsp.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private TakeTripAspDbContext _ctx;
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(TakeTripAspDbContext ctx,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            _ctx = ctx;
        }

        public async Task<string> CreateAsync(AppUser obj, string roleName)
        {
            await _userManager.CreateAsync(obj, obj.PasswordHash);
            await _userManager.AddToRoleAsync(obj, roleName);
            return _ctx.Users.First(x => x.Email == obj.Email).Id;
        }

        public async Task DeleteAsync(string id)
        {
            var user = _ctx.Users.Find(id);

            if ((await _userManager.GetRolesAsync(user)).Any())
            {
                await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
            }
            await _userManager.DeleteAsync(user);
        }

        public async Task<ReadAppUserDto> GetAsync(string id)
        {
            var user = await _ctx.Users.FindAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            return
                new ReadAppUserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsConfirmed = user.EmailConfirmed,
                    CoverPath = user.CoverPath,
                    Role = roles.First()
                };
        }

        public async Task<IEnumerable<ReadAppUserDto>> GetAllAsync()
        {
            var userIds = _ctx.Users.Select(x => x.Id).ToList();
            var usersDto = new List<ReadAppUserDto>();

            foreach (var id in userIds)
                usersDto.Add(await GetAsync(id));

            return usersDto;
        }

        public async Task UpdateAsync(ReadAppUserDto model, string roleName)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (user.Email != model.Email)
            {
                user.Email = model.Email;
                user.UserName = model.Email;
                user.NormalizedUserName = model.Email.ToUpper();
                user.NormalizedEmail = model.Email.ToUpper();
            }

            if (user.FirstName != model.FirstName) user.FirstName = model.FirstName;
            if (user.LastName != model.LastName) user.LastName = model.LastName;
            if (user.EmailConfirmed != model.IsConfirmed) user.EmailConfirmed = model.IsConfirmed;

            if ((await _userManager.GetRolesAsync(user)).Any())
            {
                await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
            }

            await _userManager.AddToRoleAsync(user, roleName);

            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<string?>> GetRolesAsync()
        {
            return _ctx.Roles.Select(x => x.Name).ToList();
        }
    }
}
