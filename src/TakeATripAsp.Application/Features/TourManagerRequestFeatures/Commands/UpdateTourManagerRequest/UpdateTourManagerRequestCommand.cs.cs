using MediatR;
using TakeTripAsp.Application.Features.TourManagerRequestFeatures.TourManagerRequestDtos;

namespace TakeTripAsp.Application.Features.TourManagerRequestFeatures.Commands.UpdateTourManagerRequest
{
    public class UpdateTourManagerRequestCommand : IRequest<ReadTourManagerRequestDto>
    {
        public int Id { get; set; }
        public bool IsCompanyMember { get; set; }
        public bool IsSeller { get; set; }
    }
}

