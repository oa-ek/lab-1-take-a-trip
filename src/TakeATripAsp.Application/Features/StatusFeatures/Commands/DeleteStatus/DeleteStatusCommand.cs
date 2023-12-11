using MediatR;

namespace TakeTripAsp.Application.Features.StatusFeatures.Commands.DeleteStatus
{
    public class DeleteStatusCommand
         : IRequest<int>
    {
        public int Id { get; set; }
    }
}
