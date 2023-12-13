using TakeATripBlazorApp.Context;
using TakeATripBlazorApp.IServices;
using TakeATripBlazorApp.Model;

namespace TakeATripBlazorApp.Services
{
    public class StatusService : IStatusService
    {
        private readonly TakeTripAspDbContext _ctx;

        public StatusService(TakeTripAspDbContext ctx)
        {
            _ctx = ctx;
        }

        public bool AddUpdate(Status status)
        {
            try
            {
                if (status.Id == 0)
                    _ctx.Statuses.Add(status);
                else
                    _ctx.Statuses.Update(status);

                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var status = FindById(id);
                if (status == null)
                    return false;

                _ctx.Statuses.Remove(status);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Status FindById(int id)
        {
            return _ctx.Statuses.Find(id);
        }

        public List<Status> GetAll()
        {
            return _ctx.Statuses.ToList();
        }
    }
}
