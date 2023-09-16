namespace TakeTripAsp.Core.Entity
{
    public class Tour : BaseEntity
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public decimal FullPrice { get; set; }

        public decimal BookingPrice { get; set; }

        public ICollection<Category>? Categories { get; set; }
        public ICollection<Bookings>? Bookings { get; set; }

        public ICollection<Images>? Images { get; set; }

        public ICollection<Reviews>? Reviews { get; set; }

    }

}
