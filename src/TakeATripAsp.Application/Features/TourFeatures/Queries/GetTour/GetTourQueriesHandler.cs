using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.TourFeatures.TourDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.TourFeatures.Queries.GetTour
{
    public class GetTourQueriesHandler
       : IRequestHandler<GetTourQueries, UpdateTourDto>
    {
        protected readonly IBaseRepository<Tour, int>? _tourRepository;
        protected readonly IMapper _mapper;
        public GetTourQueriesHandler(
            IBaseRepository<Tour, int>? tourRepository,
            IMapper mapper)
        {
            _tourRepository = tourRepository;
            _mapper = mapper;
        }

        public async Task<UpdateTourDto> Handle(GetTourQueries request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Tour, UpdateTourDto>(await _tourRepository.GetAsync(request.Id));
        }
    }
}
