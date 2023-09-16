namespace TakeTripAsp.Core.Entity
{
    public class Status : BaseEntity
    {
        public required string StatusName { get; set; }

        public int TourId { get; set; }

        public Tour? Tour { get; set; }
    }
}
