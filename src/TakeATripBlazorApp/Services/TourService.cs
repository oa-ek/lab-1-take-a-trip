using Microsoft.EntityFrameworkCore;
using TakeATripBlazorApp.Context;
using TakeATripBlazorApp.IServices;
using TakeATripBlazorApp.Model;

namespace TakeATripBlazorApp.Services
{
    public class TourService : ITourService
    {
        private readonly TakeTripAspDbContext _ctx;

        public TourService(TakeTripAspDbContext ctx)
        {
            _ctx = ctx;
        }

        public bool AddUpdate(Tour tour)
        {
            try
            {
                if (tour.Id == 0)
                    _ctx.Tours.Add(tour);
                else
                    _ctx.Tours.Update(tour);

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
                var tour = FindById(id);
                if (tour == null)
                    return false;

                _ctx.Tours.Remove(tour);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Tour FindById(int id)
        {
            return _ctx.Tours.Find(id);
        }

        public List<Tour> GetAll()
        {
            return _ctx.Tours.Include(t => t.Status).ToList();
        }
    }
}