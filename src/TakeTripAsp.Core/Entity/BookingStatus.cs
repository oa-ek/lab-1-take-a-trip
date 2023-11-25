using TakeTripAsp.Domain.Common;

namespace TakeTripAsp.Domain.Entity
{
    public class BookingStatus : BaseEntity<int>
    {
        public required string BookingStatusName { get; set; }

        public virtual ICollection<Bookings>? Bookings { get; set; }
    }
}
