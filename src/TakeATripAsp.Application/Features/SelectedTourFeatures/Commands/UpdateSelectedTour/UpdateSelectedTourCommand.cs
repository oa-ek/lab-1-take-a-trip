using MediatR;
using TakeTripAsp.Application.Features.SelectedTourFeatures.SelectedTourDtos;

namespace TakeTripAsp.Application.Features.SelectedTourFeatures.Commands.UpdateSelectedTour
{
    public class UpdateSelectedTourCommand 
        : IRequest<ReadSelectedTourDto>
    {
        public int Id { get; set; }

        public int TourId { get; set; }

        public string UserId { get; set; }
    }
}
