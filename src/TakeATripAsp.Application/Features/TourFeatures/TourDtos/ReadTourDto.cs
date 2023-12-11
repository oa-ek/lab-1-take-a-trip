using Microsoft.AspNetCore.Http;

namespace TakeTripAsp.Application.Features.Tourfeatures.TourDtos
{
    public class ReadTourDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required string Continent { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public decimal FullPrice { get; set; }

        public decimal BookingPrice { get; set; }

        public int StatusId { get; set; }

        public string? ManagerId { get; set; }

        public string? CoverPath { get; set; } = "\\img\\tour\\tour.jpg";

        public IFormFile? CoverFile { get; set; }

        public int CityId { get; set; }

    }
}
