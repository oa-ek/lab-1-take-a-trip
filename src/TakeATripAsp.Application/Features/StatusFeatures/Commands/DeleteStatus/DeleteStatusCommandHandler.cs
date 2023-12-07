using MediatR;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.StatusFeatures.Commands.DeleteStatus
{
    public class DeleteStatusCommandHandler
        : IRequestHandler<DeleteStatusCommand, int>
    {
        protected readonly IBaseRepository<Status, int> _statusRepository;

        public DeleteStatusCommandHandler(IBaseRepository<Status, int> statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<int> Handle(
            DeleteStatusCommand request,
            CancellationToken cancellationToken)
        {
            var status = await _statusRepository.GetAsync(request.Id);

            await _statusRepository.DeleteAsync(status);

            return status.Id;
        }
    }
}