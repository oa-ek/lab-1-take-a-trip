namespace TakeTripAsp.Core.Entity
{
    public class Payment : BaseEntity
    {
        public decimal Amount { get; set; }

        public int BookingId { get; set; }

        public virtual Bookings? Booking { get; set; }
    }
}
