using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace TakeTripAsp.Core.Entity
{
    public class Images : BaseEntity
    {
        public string? CoverPath { get; set; } = "\\img\\tour\\tour.jpg";

        [NotMapped]
        public IFormFile? CoverFile { get; set; }

        public int TourId { get; set; }

        public Tour? Tour { get; set; }
    }
}
