using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.SelectedTourFeatures.SelectedTourDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.SelectedTourFeatures.Commands.UpdateSelectedTour
{
    public class UpdateSelectedTourCommandHandler
        : IRequestHandler<UpdateSelectedTourCommand, ReadSelectedTourDto>
    {
        private readonly IBaseRepository<SelectedTour, int> _selectedTourRepository;
        private readonly IMapper _mapper;

        public UpdateSelectedTourCommandHandler(
            IBaseRepository<SelectedTour, int> selectedTourRepository,
            IMapper mapper)
        {
            (_selectedTourRepository, _mapper) = (selectedTourRepository, mapper);
        }

        public async Task<ReadSelectedTourDto> Handle(
            UpdateSelectedTourCommand request,
            CancellationToken cancellationToken)
        {
            var selectedTour = await _selectedTourRepository.GetAsync(request.Id);

            selectedTour.TourId = request.TourId;
            selectedTour.UserId = request.UserId;

            await _selectedTourRepository.UpdateAsync(selectedTour);

            return _mapper.Map<SelectedTour, ReadSelectedTourDto>(selectedTour);
        }
    }
}
