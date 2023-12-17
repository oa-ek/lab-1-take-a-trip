using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.TourFeatures.TourDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.TourFeatures.Queries.GetAllTour
{
    public class GetAllTourQueriesHandler
        : IRequestHandler<GetAllTourQueries, IEnumerable<ReadTourDto>>
    {
        protected readonly IBaseRepository<Tour, int> _tourRepository;
        protected readonly IMapper _mapper;

        public GetAllTourQueriesHandler(IBaseRepository<Tour, int> tourRepository, IMapper mapper)
        {
            (_tourRepository, _mapper) = (tourRepository, mapper);
        }

        public async Task<IEnumerable<ReadTourDto>> Handle(
            GetAllTourQueries request,
            CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Tour>, IEnumerable<ReadTourDto>>(await _tourRepository.GetAllAsync());
        }
    }
}