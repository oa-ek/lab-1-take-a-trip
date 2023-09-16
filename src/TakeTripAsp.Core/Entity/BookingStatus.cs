namespace TakeTripAsp.Core.Entity
{
    public class BookingStatus : BaseEntity
    {
        public required string BookingStatusName { get; set; }

        ICollection<Bookings> Bookings { get; set; }
    }
}
