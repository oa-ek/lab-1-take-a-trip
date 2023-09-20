namespace TakeTripAsp.Core.Entity
{
    public class BookingStatus : BaseEntity
    {
        public required string BookingStatusName { get; set; }

        public virtual ICollection<Bookings>? Bookings { get; set; }
    }
}
