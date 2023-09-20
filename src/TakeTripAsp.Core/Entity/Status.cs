namespace TakeTripAsp.Core.Entity
{
    public class Status : BaseEntity
    {
        public required string StatusName { get; set; }

        public virtual ICollection<Tour>? Tours { get; set; }
    }
}
