using MediatR;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.TourManagerRequestFeatures.Commands.DeleteTourManagerRequest
{
    public class DeleteTourManagerRequestCommandHandler : IRequestHandler<DeleteTourManagerRequestCommand, int>
    {
        protected readonly IBaseRepository<TourManagerRequest, int> _tourManagerRequestRepository;

        public DeleteTourManagerRequestCommandHandler(IBaseRepository<TourManagerRequest, int> tourManagerRequestRepository)
        {
            _tourManagerRequestRepository = tourManagerRequestRepository;
        }

        public async Task<int> Handle(
            DeleteTourManagerRequestCommand request,
            CancellationToken cancellationToken)
        {
            var tourManagerRequest = await _tourManagerRequestRepository.GetAsync(request.Id);

            await _tourManagerRequestRepository.DeleteAsync(tourManagerRequest);

            return tourManagerRequest.Id;
        }
    }
}