using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Repository
{
    public interface IUserRepository
    {
        Task<ReadAppUserDto> GetAsync(string id);
        Task<IEnumerable<ReadAppUserDto>> GetAllAsync();
        Task<string> CreateAsync(AppUser obj);
        Task UpdateAsync(ReadAppUserDto obj, string[] roles);
        Task<IEnumerable<string>> GetRolesAsync();
        Task DeleteAsync(string id);
    }
}
