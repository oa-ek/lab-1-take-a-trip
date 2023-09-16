namespace TakeTripAsp.Core.Entity
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }

        public ICollection<SelectedTour> Tours { get; set; }
    }
}
