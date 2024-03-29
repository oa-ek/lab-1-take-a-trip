﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TakeTripAsp.Core.Context;
using TakeTripAsp.Core.Entity;
using TakeTripAsp.Repository.DTOsUser;
using TakeTripAsp.Repository.Interfaces;

namespace TakeTripAsp.Repository.Repos
{
    public class UserRepository :IUserRepository
    {
        private TakeTripAspDbContext _context;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserRepository(TakeTripAspDbContext context,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            _context = context;
        }

        public async Task<string> CreateAsync(UserCreateDto obj)
        {
            var newUser = new AppUser
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Email = obj.Email,
                UserName = obj.Email,
                NormalizedEmail = obj.Email.ToUpper(),
                NormalizedUserName = obj.Email.ToUpper(),
                EmailConfirmed = true
            };

            await userManager.CreateAsync(newUser, obj.Password);
            await userManager.AddToRoleAsync(newUser,obj.Role); // додати до ролі 
            return _context.Users.First(x => x.Email == obj.Email).Id;
        }

        public async Task DeleteAsync(string id)
        {
            var user = _context.Users.Find(id);

            if ((await userManager.GetRolesAsync(user)).Any())
            {
                await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
            }
            await userManager.DeleteAsync(user);
        }

        public async Task<UserDto> GetAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            var roles = await userManager.GetRolesAsync(user);
            return
                new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsConfirmed = user.EmailConfirmed,
                    Role = roles.ToList()
                };
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var userIds = _context.Users.Select(x => x.Id).ToList();
            var usersDto = new List<UserDto>();

            foreach (var id in userIds)
                usersDto.Add(await GetAsync(id));

            return usersDto;
        }

        public async Task UpdateAsync(UserDto model, string[] roles)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.Id);

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

            if ((await userManager.GetRolesAsync(user)).Any())
            {
                await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
            }

            if (roles.Any())
            {
                await userManager.AddToRolesAsync(user, roles.ToList());
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<string?>> GetRolesAsync()
        {
            return _context.Roles.Select(x => x.Name).ToList();
        }
    }
}