using TakeTripAsp.Domain.Common;

namespace TakeTripAsp.Domain.Entity
{
    public class Country : BaseEntity<int>
    {
        public required string CountryName { get; set; }

        public virtual ICollection<City>? Cities { get; set; }
    }
}
