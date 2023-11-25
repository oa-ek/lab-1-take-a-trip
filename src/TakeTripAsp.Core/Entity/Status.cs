using TakeTripAsp.Domain.Common;

namespace TakeTripAsp.Domain.Entity
{
    public class Status : BaseEntity<int>
    {
        public required string StatusName { get; set; }

        public virtual ICollection<Tour>? Tours { get; set; }
    }
}
