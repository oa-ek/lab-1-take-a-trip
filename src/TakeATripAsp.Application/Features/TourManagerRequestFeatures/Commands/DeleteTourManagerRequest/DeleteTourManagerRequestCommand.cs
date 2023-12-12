using MediatR;

namespace TakeTripAsp.Application.Features.TourManagerRequestFeatures.Commands.DeleteTourManagerRequest
{
    public class DeleteTourManagerRequestCommand : IRequest<int>
    {
        public int ClientId { get; set; }
    }
}


