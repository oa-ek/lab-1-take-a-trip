using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.SelectedTourFeatures.SelectedTourDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.SelectedTourFeatures.Commands.CreateSelectedTour
{
    public class CreateSelectedTourCommandHandler
      : IRequestHandler<CreateSelectedTourCommand, CreateSelectedTourDto>
    {
        private readonly IBaseRepository<SelectedTour, int> _selectedTourRepository;
        private readonly IMapper _mapper;

        public CreateSelectedTourCommandHandler(
            IBaseRepository<SelectedTour, int> selectedTourRepository,
            IMapper mapper)
        {
            (_selectedTourRepository, _mapper) = (selectedTourRepository, mapper);
        }

        public async Task<CreateSelectedTourDto> Handle(
            CreateSelectedTourCommand request,
            CancellationToken cancellationToken)
        {
            var selectedTour = await _selectedTourRepository.CreateAsync(
                new SelectedTour { TourId = request.TourId, UserId = request.UserId });

            return _mapper.Map<SelectedTour, CreateSelectedTourDto>(selectedTour);
        }
    }
}
