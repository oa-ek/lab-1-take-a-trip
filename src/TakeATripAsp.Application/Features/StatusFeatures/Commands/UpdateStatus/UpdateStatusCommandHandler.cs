using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.StatusFeatures.StatusDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.StatusFeatures.Commands.UpdateStatus
{
    public class UpdateStatusCommandHandler
        : IRequestHandler<UpdateStatusCommand, ReadStatusDto>
    {
        protected readonly IBaseRepository<Status, int> _statusRepository;
        protected readonly IMapper _mapper;

        public UpdateStatusCommandHandler(
            IBaseRepository<Status, int> statusRepository,
            IMapper mapper)
        {
            (_statusRepository, _mapper) = (statusRepository, mapper);
        }

        public async Task<ReadStatusDto> Handle(
            UpdateStatusCommand request,
            CancellationToken cancellationToken)
        {
            var status = await _statusRepository.GetAsync(request.Id);

            status.StatusName = request.StatusName;

            await _statusRepository.UpdateAsync(status);

            return _mapper.Map<Status, ReadStatusDto>(status);
        }
    }
}
