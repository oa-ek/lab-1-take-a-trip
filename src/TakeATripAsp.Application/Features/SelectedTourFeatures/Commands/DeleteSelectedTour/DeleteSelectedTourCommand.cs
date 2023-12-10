using MediatR;

namespace TakeTripAsp.Application.Features.SelectedTourFeatures.Commands.DeleteSelectedTour
{
    public class DeleteSelectedTourCommand 
        : IRequest<int>
    {
        public int Id { get; set; }
    }
}
