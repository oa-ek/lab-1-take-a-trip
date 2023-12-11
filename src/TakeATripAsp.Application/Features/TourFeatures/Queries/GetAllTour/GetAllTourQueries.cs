using MediatR;
using TakeTripAsp.Application.Features.Tourfeatures.TourDtos;

namespace TakeTripAsp.Application.Features.Tourfeatures.Queries.GetAllTour
{
    public class GetAllTourQueries
        : IRequest<IEnumerable<ReadTourDto>>
    { }

}
