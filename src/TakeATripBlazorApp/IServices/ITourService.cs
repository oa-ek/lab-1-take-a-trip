using TakeATripBlazorApp.Model;

namespace TakeATripBlazorApp.IServices
{
    public interface ITourService
    {
        bool AddUpdate(Tour tour);
        bool Delete(int id);
        Tour FindById(int id);
        List<Tour> GetAll();
    }
}
