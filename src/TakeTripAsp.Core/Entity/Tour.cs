using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace TakeTripAsp.Core.Entity
{
    public class Tour : BaseEntity
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public required string Continent { get; set; }

        public required string City { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public decimal FullPrice { get; set; }

        public decimal BookingPrice { get; set; }

        public int StatusId { get; set; }

        public virtual Status? Status { get; set; }

        public virtual ICollection<Category>? Categories { get; set; }

        public virtual ICollection<Bookings>? Bookings { get; set; }

        public string? CoverPath { get; set; } = "\\img\\tour\\tour.jpg";

        [NotMapped]
        public IFormFile? CoverFile { get; set; }

        public virtual ICollection<Reviews>? Reviews { get; set; }

    }

}
