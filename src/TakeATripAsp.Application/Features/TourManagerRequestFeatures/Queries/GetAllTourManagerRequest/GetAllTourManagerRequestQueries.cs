using MediatR;
using TakeTripAsp.Application.Features.TourManagerRequestFeatures.TourManagerRequestDtos;


namespace TakeTripAsp.Application.Features.TourManagerRequestFeatures.Queries.GetAllTourManagerRequest
{
    public class GetAllTourManagerRequestQueries 
        : IRequest<IEnumerable<ReadTourManagerRequestDto>>
    { }
}

