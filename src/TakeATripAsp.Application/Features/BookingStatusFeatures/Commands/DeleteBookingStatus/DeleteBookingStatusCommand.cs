using MediatR;

namespace TakeTripAsp.Application.Features.BookingStatusFeatures.Commands.DeleteBookingStatus
{
    public class DeleteBookingStatusCommand
       : IRequest<int>
    {
        public int Id { get; set; }
    }
}
