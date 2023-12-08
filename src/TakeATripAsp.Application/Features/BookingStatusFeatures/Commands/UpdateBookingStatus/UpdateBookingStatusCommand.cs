using MediatR;
using TakeTripAsp.Application.Features.BookingStatusFeatures.BookingStatusDtos;

namespace TakeTripAsp.Application.Features.BookingStatusFeatures.Commands.UpdateBookingStatus
{
    public class UpdateBookingStatusCommand
    : IRequest<ReadBookingStatusDto>
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}

