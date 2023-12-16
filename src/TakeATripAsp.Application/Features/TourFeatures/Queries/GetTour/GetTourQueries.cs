using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.TourFeatures.TourDtos;

namespace TakeTripAsp.Application.Features.TourFeatures.Queries.GetTour
{
    public class GetTourQueries : IRequest<UpdateTourDto>
    {
        public int Id { get; set; }
    }
}
