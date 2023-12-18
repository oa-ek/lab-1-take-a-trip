using MediatR;
using TakeTripAsp.Application.Features.TourFeatures.TourDtos;

namespace TakeTripAsp.Application.Features.TourFeatures.Queries.GetTour
{
    public class GetTourQueries : IRequest<UpdateTourDto>
    {
        public int Id { get; set; }
    }
}
