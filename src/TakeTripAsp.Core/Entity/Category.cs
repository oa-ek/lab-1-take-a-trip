namespace TakeTripAsp.Core.Entity
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }

        public virtual ICollection<Tour>? Tours { get; set; }
    }
}
