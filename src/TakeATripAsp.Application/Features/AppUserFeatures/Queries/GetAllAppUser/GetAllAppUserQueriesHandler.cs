using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;
using TakeTripAsp.Application.Repository;

namespace TakeTripAsp.Application.Features.AppUserFeatures.Queries.GetAllAppUser
{
    public class GetAllAppUserQueriesHandler : IRequestHandler<GetAllAppUserQueries, IEnumerable<ReadAppUserDto>>
    {
        private readonly IUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public GetAllAppUserQueriesHandler(
            IUserRepository appUserRepository,
            IMapper mapper)
        {
            (_appUserRepository, _mapper) = (appUserRepository, mapper);
        }

        public async Task<IEnumerable<ReadAppUserDto>> Handle(
            GetAllAppUserQueries request,
            CancellationToken cancellationToken)
        {
            return await _appUserRepository.GetAllAsync();
        }
    }
}
