using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.BookingFeatures.BookingsDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.BookingFeatures.Commands.CreateBookings
{
    public class CreateBookingsCommandHandler : IRequestHandler<CreateBookingsCommand, CreateBookingsDto>
    {
        protected readonly IBaseRepository<Bookings, int>? _bookingsRepository;
        protected readonly IMapper _mapper;

        public CreateBookingsCommandHandler(
            IBaseRepository<Bookings, int> bookingsRepository,
            IMapper mapper)
        {
            (_bookingsRepository, _mapper) = (bookingsRepository, mapper);
        }

        public async Task<CreateBookingsDto> Handle(
            CreateBookingsCommand request,
            CancellationToken cancellationToken)
        {
            var booking = await _bookingsRepository.CreateAsync(new Bookings
            {
                IsFullPayment = request.IsFullPayment,
                Payment = request.Payment,
                ClientId = request.ClientId,
                TourId = request.TourId,
                BookingStatusId = request.BookingStatusId
            });

            return _mapper.Map<Bookings, CreateBookingsDto>(booking);
        }
    }
}
