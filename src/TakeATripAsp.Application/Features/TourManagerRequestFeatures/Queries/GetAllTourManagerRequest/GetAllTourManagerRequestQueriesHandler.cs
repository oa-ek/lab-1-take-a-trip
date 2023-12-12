using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.TourManagerRequestFeatures.TourManagerRequestDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.TourManagerRequestFeatures.Queries.GetAllTourManagerRequest
{
    public class GetAllTourManagerRequestQueriesHandler : IRequestHandler<GetAllTourManagerRequestQueries, IEnumerable<ReadTourManagerRequestDto>>
    {
        protected readonly IBaseRepository<TourManagerRequest, int>? _tourManagerRequestRepository;
        protected readonly IMapper _mapper;

        public GetAllTourManagerRequestQueriesHandler(
            IBaseRepository<TourManagerRequest, int> tourManagerRequestRepository,
            IMapper mapper)
        {
            (_tourManagerRequestRepository, _mapper) = (tourManagerRequestRepository, mapper);
        }

        public async Task<IEnumerable<ReadTourManagerRequestDto>> Handle(
            GetAllTourManagerRequestQueries request,
            CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<TourManagerRequest>,
                IEnumerable<ReadTourManagerRequestDto>>(await _tourManagerRequestRepository.GetAllAsync());
        }
    }
}
