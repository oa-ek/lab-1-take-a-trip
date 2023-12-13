using TakeATripBlazorApp.Context;
using TakeATripBlazorApp.IServices;
using TakeATripBlazorApp.Model;

namespace TakeATripBlazorApp.Services
{
        public class CountryService : ICountryService
    {
        private readonly TakeTripAspDbContext _ctx;

        public CountryService(TakeTripAspDbContext ctx)
        {
            _ctx = ctx;
        }

        public bool AddUpdate(Country country)
        {
            try
            {
                if (country.Id == 0)
                    _ctx.Countries.Add(country);
                else
                    _ctx.Countries.Update(country);

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
                var country = FindById(id);
                if (country == null)
                    return false;

                _ctx.Countries.Remove(country);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Country FindById(int id)
        {
            return _ctx.Countries.Find(id);
        }

        public List<Country> GetAll()
        {
            return _ctx.Countries.ToList();
        }
    }
}