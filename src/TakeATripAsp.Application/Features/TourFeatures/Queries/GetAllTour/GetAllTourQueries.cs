using MediatR;
using TakeTripAsp.Application.Features.TourFeatures.TourDtos;

namespace TakeTripAsp.Application.Features.TourFeatures.Queries.GetAllTour
{
    public class GetAllTourQueries
        : IRequest<IEnumerable<ReadTourDto>>
    { }

}
