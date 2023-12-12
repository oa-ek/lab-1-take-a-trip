using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;

namespace TakeTripAsp.Application.Repository
{
    public interface IUserRepository
    {
        Task<ReadAppUserDto> GetAsync(string id);
        Task<IEnumerable<ReadAppUserDto>> GetAllAsync();
        Task<string> CreateAsync(CreateAppUserDto obj);
        Task UpdateAsync(ReadAppUserDto obj, string[] roles);
        Task<IEnumerable<string>> GetRolesAsync();
        Task DeleteAsync(string id);
    }
}
