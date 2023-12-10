using MediatR;
using TakeTripAsp.Application.Features.SelectedTourFeatures.SelectedTourDtos;

namespace TakeTripAsp.Application.Features.SelectedTourFeatures.Commands.CreateSelectedTour
{
    public class CreateSelectedTourCommand
        : IRequest<CreateSelectedTourDto>
    {
        public int TourId { get; set; }

        public string UserId { get; set; }
    }
}