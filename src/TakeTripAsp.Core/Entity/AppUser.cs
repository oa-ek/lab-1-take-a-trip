namespace TakeTripAsp.Core.Entity
{
    public class AppUser : BaseEntity
    {
        public required string Name { get; set; }

        public ICollection<SelectedTour> Tours { get; set; }
    }
}
