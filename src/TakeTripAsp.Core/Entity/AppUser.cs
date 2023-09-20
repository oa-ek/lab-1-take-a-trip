namespace TakeTripAsp.Core.Entity
{
    public class AppUser : BaseEntity
    {
        public required string Name { get; set; }

        public virtual ICollection<SelectedTour>? Tours { get; set; }
    }
}
