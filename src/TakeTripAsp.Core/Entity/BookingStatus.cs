namespace TakeTripAsp.Core.Entity
{
    public class BookingStatus : BaseEntity
    {
        public required string BookingStatusName { get; set; }

        public ICollection<Bookings>? Bookings { get; set; }
    }
}
