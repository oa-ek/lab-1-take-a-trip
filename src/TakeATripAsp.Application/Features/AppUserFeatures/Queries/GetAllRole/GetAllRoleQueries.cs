using MediatR;

namespace TakeTripAsp.Application.Features.AppUserFeatures.Queries.GetAllRole
{
    public class GetAllRoleQueries
        : IRequest<IEnumerable<string>> { }
}
