using TakeATripBlazorApp.Model;

namespace TakeATripBlazorApp.IServices
{
    public interface IStatusService
    {
        bool AddUpdate(Status status);
        bool Delete(int id);
        Status FindById(int id);
        List<Status> GetAll();
    }
}
