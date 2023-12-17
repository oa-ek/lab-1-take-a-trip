using MediatR;
using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;
using TakeTripAsp.Application.Repository;

namespace TakeTripAsp.Application.Features.AppUserFeatures.Queries.GetAppUser
{
    public class GetAppUserQueriesHandler : IRequestHandler<GetAppUserQueries, ReadAppUserDto>
    {
        protected readonly IUserRepository _userRepository;

        public GetAppUserQueriesHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ReadAppUserDto> Handle(
            GetAppUserQueries request,
            CancellationToken cancellationToken)
        {
            return await _userRepository.GetAsync(request.Id);
        }
    }
}
