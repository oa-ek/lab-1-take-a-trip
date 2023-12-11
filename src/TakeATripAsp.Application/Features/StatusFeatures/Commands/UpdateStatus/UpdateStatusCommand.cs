using MediatR;
using TakeTripAsp.Application.Features.StatusFeatures.StatusDtos;

namespace TakeTripAsp.Application.Features.StatusFeatures.Commands.UpdateStatus
{
    public class UpdateStatusCommand
         : IRequest<ReadStatusDto>
    {
        public int Id { get; set; }

        public required string StatusName { get; set; }
    }
}
