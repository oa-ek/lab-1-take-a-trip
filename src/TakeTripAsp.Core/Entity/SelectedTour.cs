namespace TakeTripAsp.Core.Entity
{
    public class SelectedTour : BaseEntity
    {
        public int UserId { get; set; }

        public virtual AppUser? User { get; set; }

        public int TourId { get; set; }

        public virtual Tour? Tour { get; set; }
    }
}
