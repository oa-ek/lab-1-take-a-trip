using TakeTripAsp.Domain.Common;

namespace TakeTripAsp.Domain.Entity
{
    public class Category : BaseEntity<int>
    {
        public required string Name { get; set; }

        public virtual ICollection<Tour>? Tours { get; set; }
    }
}
