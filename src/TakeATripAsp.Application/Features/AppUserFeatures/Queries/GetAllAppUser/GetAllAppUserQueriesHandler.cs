using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;
using TakeTripAsp.Application.Repository;

namespace TakeTripAsp.Application.Features.AppUserFeatures.Queries.GetAllAppUser
{
    public class GetAllAppUserQueriesHandler : IRequestHandler<GetAllAppUserQueries, IEnumerable<ReadAppUserDto>>
    {
        private readonly IUserRepository _appUserRepository;

        public GetAllAppUserQueriesHandler(IUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<IEnumerable<ReadAppUserDto>> Handle(
            GetAllAppUserQueries request,
            CancellationToken cancellationToken)
        {
            return await _appUserRepository.GetAllAsync();
        }
    }
}
