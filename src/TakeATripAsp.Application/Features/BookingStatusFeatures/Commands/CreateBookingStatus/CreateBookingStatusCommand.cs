using MediatR;
using TakeTripAsp.Application.Features.BookingStatusFeatures.BookingStatusDtos;

namespace TakeTripAsp.Application.Features.BookingStatusFeatures.Commands.CreateBookingStatus
{
    public class CreateBookingStatusCommand
     : IRequest<CreateBookingStatusDto>
    {
        public required string Name { get; set; }
    }
}