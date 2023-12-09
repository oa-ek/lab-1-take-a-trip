using MediatR;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.BookingFeatures.Commands.DeleteBookings
{
    public class DeleteBookingsCommandHandler : IRequestHandler<DeleteBookingsCommand, int>
    {
        protected readonly IBaseRepository<Bookings, int> _bookingsRepository;

        public DeleteBookingsCommandHandler(IBaseRepository<Bookings, int> bookingsRepository)
        {
            _bookingsRepository = bookingsRepository;
        }

        public async Task<int> Handle(
            DeleteBookingsCommand request,
            CancellationToken cancellationToken)
        {
            var booking = await _bookingsRepository.GetAsync(request.Id);

            await _bookingsRepository.DeleteAsync(booking);

            return booking.Id;
        }
    }
}
