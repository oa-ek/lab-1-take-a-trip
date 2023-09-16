namespace TakeTripAsp.Core.Entity
{
    public class SelectedTour : BaseEntity
    {
        public int UserId { get; set; }

        public AppUser? User { get; set; }

        public int TourId { get; set; }

        public Tour? Tour { get; set; }
    }
}
