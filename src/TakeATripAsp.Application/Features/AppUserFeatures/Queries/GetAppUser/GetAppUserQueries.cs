using MediatR;
using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;

namespace TakeTripAsp.Application.Features.AppUserFeatures.Queries.GetAppUser
{
    public class GetAppUserQueries : IRequest<ReadAppUserDto>
    {
        public string Id { get; set; }
    }
}
