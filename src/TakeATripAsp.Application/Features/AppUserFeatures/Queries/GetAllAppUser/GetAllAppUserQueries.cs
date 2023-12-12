using MediatR;
using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;

namespace TakeTripAsp.Application.Features.AppUserFeatures.Queries.GetAllAppUser
{
    public class GetAllAppUserQueries : IRequest<IEnumerable<ReadAppUserDto>> { }
}
