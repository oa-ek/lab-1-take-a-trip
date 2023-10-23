using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Repository.DTOsUser;
//using TakeTripAsp.Core.Entity;

namespace TakeTripAsp.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetAsync(string id);
        Task<IEnumerable<UserDto>> GetAllAsync(); //AppUser
        Task<string> CreateAsync(UserCreateDto obj);
        Task UpdateAsync(UserDto obj, string[] roles);
        Task<IEnumerable<string>> GetRolesAsync();
        Task DeleteAsync(string id);
    }
}


