using MediatR;
using TakeTripAsp.Application.Features.TourManagerRequestFeatures.TourManagerRequestDtos;

namespace TakeTripAsp.Application.Features.TourManagerRequestFeatures.Commands.CreateTourManagerRequest
{
    public class CreateTourManagerRequestCommand : IRequest<ReadTourManagerRequestDto>
    {
        public string ClientId { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCompanyMember { get; set; }
        public bool IsSeller { get; set; }
    }
}