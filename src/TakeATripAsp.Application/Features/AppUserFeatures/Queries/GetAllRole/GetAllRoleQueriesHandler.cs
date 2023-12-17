using MediatR;
using TakeTripAsp.Application.Repository;

namespace TakeTripAsp.Application.Features.AppUserFeatures.Queries.GetAllRole
{
    public class GetAllRoleQueriesHandler : IRequestHandler<GetAllRoleQueries, IEnumerable<string>>
    {
        protected readonly IUserRepository _userRepository;

        public GetAllRoleQueriesHandler( IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<string>> Handle(
            GetAllRoleQueries request,
            CancellationToken cancellationToken)
        {
            return await _userRepository.GetRolesAsync();
        }
    }
}
