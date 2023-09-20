namespace TakeTripAsp.Core.Entity
{
    public class Reviews : BaseEntity
    {
        public required string Comment { get; set; }

        public int UserId { get; set; }

        public virtual AppUser? User { get; set; }

        public int TourId { get; set; }

        public virtual Tour? Tour { get; set; }
    }
}
