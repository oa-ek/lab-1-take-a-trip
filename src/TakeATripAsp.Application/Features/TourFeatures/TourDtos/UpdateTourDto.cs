﻿using Microsoft.AspNetCore.Http;

namespace TakeTripAsp.Application.Features.TourFeatures.TourDtos
{
    public class UpdateTourDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string Continent { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public decimal FullPrice { get; set; }

        public decimal BookingPrice { get; set; }

        public int StatusId { get; set; }

        public List<int> CategoryIds { get; set; }

        public string wwwRootPath { get; set; }

        public IFormFile? CoverFile { get; set; }

        public int CityId { get; set; }
    }
}
