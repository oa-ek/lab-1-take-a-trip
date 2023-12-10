using MediatR;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.SelectedTourFeatures.Commands.DeleteSelectedTour
{
    public class DeleteSelectedTourCommandHandler
        : IRequestHandler<DeleteSelectedTourCommand, int>
    {
        private readonly IBaseRepository<SelectedTour, int> _selectedTourRepository;

        public DeleteSelectedTourCommandHandler(IBaseRepository<SelectedTour, int> selectedTourRepository)
        {
            _selectedTourRepository = selectedTourRepository;
        }

        public async Task<int> Handle(
            DeleteSelectedTourCommand request,
            CancellationToken cancellationToken)
        {
            var selectedTour = await _selectedTourRepository.GetAsync(request.Id);

            await _selectedTourRepository.DeleteAsync(selectedTour);

            return selectedTour.Id;
        }
    }
}
