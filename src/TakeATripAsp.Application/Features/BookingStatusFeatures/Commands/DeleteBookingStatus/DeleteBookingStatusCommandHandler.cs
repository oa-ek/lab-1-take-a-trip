using MediatR;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.BookingStatusFeatures.Commands.DeleteBookingStatus
{
    public class DeleteBookingStatusCommandHandler
    : IRequestHandler<DeleteBookingStatusCommand, int>
    {
        protected readonly IBaseRepository<BookingStatus, int> _bookingStatusRepository;

        public DeleteBookingStatusCommandHandler(IBaseRepository<BookingStatus, int> bookingStatusRepository)
        {
            _bookingStatusRepository = bookingStatusRepository;
        }

        public async Task<int> Handle(
            DeleteBookingStatusCommand request,
            CancellationToken cancellationToken)
        {
            var bookingStatus = await _bookingStatusRepository.GetAsync(request.Id);

            await _bookingStatusRepository.DeleteAsync(bookingStatus);

            return bookingStatus.Id;
        }
    }
}
