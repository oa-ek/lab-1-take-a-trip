using MediatR;
using TakeTripAsp.Application.Features.StatusFeatures.StatusDtos;

namespace TakeTripAsp.Application.Features.StatusFeatures.Queries.GetAllStatus
{
    public class GetAllStatusQueries
        : IRequest<IEnumerable<ReadStatusDto>>
    { }
}
