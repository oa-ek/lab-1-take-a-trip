using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.SelectedTourFeatures.SelectedTourDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.SelectedTourFeatures.Queries.GetAllSelectedTour
{
    public class GetAllSelectedTourQueriesHandler
        : IRequestHandler<GetAllSelectedTourQueries, IEnumerable<ReadSelectedTourDto>>
    {
        private readonly IBaseRepository<SelectedTour, int>? _selectedTourRepository;
        private readonly IMapper _mapper;

        public GetAllSelectedTourQueriesHandler(
            IBaseRepository<SelectedTour, int> selectedTourRepository,
            IMapper mapper)
        {
            (_selectedTourRepository, _mapper) = (selectedTourRepository, mapper);
        }

        public async Task<IEnumerable<ReadSelectedTourDto>> Handle(
            GetAllSelectedTourQueries request,
            CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<SelectedTour>,
                IEnumerable<ReadSelectedTourDto>>(await _selectedTourRepository.GetAllAsync());
        }
    }
}
