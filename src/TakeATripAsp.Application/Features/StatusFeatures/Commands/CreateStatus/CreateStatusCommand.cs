using MediatR;
using TakeTripAsp.Application.Features.StatusFeatures.StatusDtos;

namespace TakeTripAsp.Application.Features.StatusFeatures.Commands.CreateStatus
{
    public class CreateStatusCommand
        : IRequest<CreateStatusDto>
    {
        public required string Name { get; set; }
    }
}