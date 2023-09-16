namespace TakeTripAsp.Core.Entity
{
    public class Reviews : BaseEntity
    {
        public required string Comment { get; set; }

        public int UserId { get; set; }

        public AppUser? User { get; set; }

        public int TourId { get; set; }

        public Tour? Tour { get; set; }
    }
}
