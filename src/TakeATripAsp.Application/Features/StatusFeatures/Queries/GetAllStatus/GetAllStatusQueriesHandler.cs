using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.StatusFeatures.StatusDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.StatusFeatures.Queries.GetAllStatus
{
    public class GetAllStatusQueriesHandler
       : IRequestHandler<GetAllStatusQueries, IEnumerable<ReadStatusDto>>
    {
        protected readonly IBaseRepository<Status, int>? _statusRepository;
        protected readonly IMapper _mapper;

        public GetAllStatusQueriesHandler(
            IBaseRepository<Status, int> statusRepository,
            IMapper mapper)
        {
            (_statusRepository, _mapper) = (statusRepository, mapper);
        }

        public async Task<IEnumerable<ReadStatusDto>> Handle(
            GetAllStatusQueries request,
            CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Status>,
                IEnumerable<ReadStatusDto>>(await _statusRepository.GetAllAsync());
        }
    }
}