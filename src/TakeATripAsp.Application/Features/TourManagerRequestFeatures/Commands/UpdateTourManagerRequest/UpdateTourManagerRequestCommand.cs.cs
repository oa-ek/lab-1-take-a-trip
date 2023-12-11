using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.TourManagerRequestFeatures.TourManagerRequestDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.TourManagerRequestFeatures.Commands.UpdateTourManagerRequest
{
    public class UpdateTourManagerRequestCommand : IRequest<ReadTourManagerRequestDto>
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCompanyMember { get; set; }
        public bool IsSeller { get; set; }
    }
}

