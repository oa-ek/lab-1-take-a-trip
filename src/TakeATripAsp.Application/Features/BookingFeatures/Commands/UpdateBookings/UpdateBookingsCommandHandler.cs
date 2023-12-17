using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.BookingFeatures.BookingsDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.BookingFeatures.Commands.UpdateBookings
{
    public class UpdateBookingsCommandHandler 
        : IRequestHandler<UpdateBookingsCommand, ReadBookingsDto>
    {
        protected readonly IBaseRepository<Bookings, int> _bookingsRepository;
        protected readonly IMapper _mapper;

        public UpdateBookingsCommandHandler(
            IBaseRepository<Bookings, int> bookingsRepository,
            IMapper mapper)
        {
            (_bookingsRepository, _mapper) = (bookingsRepository, mapper);
        }

        public async Task<ReadBookingsDto> Handle(
            UpdateBookingsCommand request,
            CancellationToken cancellationToken)
        {
            var booking = await _bookingsRepository.GetAsync(request.Id);

            booking.IsFullPayment = request.IsFullPayment;
            booking.Payment = request.IsFullPayment ? booking.Tour.FullPrice : booking.Tour.BookingPrice;
            booking.BookingStatusId = request.BookingStatusId;

            await _bookingsRepository.UpdateAsync(booking);

            return _mapper.Map<Bookings, ReadBookingsDto>(booking);
        }
    }
}
