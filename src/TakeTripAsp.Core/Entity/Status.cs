namespace TakeTripAsp.Core.Entity
{
    public class Status : BaseEntity
    {
        public required string StatusName { get; set; }

        public ICollection<Tour>? Tours { get; set; }
    }
}
