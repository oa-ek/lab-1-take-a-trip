using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.Tourfeatures.TourDtos;

namespace TakeTripAsp.Application.Features.Tourfeatures.Commands.CreateTour
{
    public class CreateTourCommand : IRequest<CreateTourDto>
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public string Continent { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public decimal FullPrice { get; set; }

        public decimal BookingPrice { get; set; }

        public int StatusId { get; set; }

        public string? ManagerId { get; set; }

        public List<int> CategoryIds { get; set; }

        public string wwwRootPath { get; set; }

        public IFormFile? CoverFile { get; set; }

        public int CityId { get; set; }
    }
}
