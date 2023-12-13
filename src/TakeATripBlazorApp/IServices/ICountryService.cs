using TakeATripBlazorApp.Model;

namespace TakeATripBlazorApp.IServices
{
    public interface ICountryService
    {
        bool AddUpdate(Country country);
        bool Delete(int id);
        Country FindById(int id);
        List<Country> GetAll();
    }
}
